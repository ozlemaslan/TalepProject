using ProjectApp.DataAccess.Interfaces;
using ProjectApp.DataAccess.Repository;
using ProjectApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectApp.UI.Models;
using System.IO;

namespace ProjectApp.UI.Controllers
{
    public class HomeController : Controller
    {
        //ITalepRepository _talepRepository;
        //IUserRepository _userRepository;
        //TalepRepository _talepRepository;
        //UserRepository _userRepository;
        //public HomeController(TalepRepository talepRepository, UserRepository userRepository)
        //{
        //    _talepRepository = talepRepository;
        //    _userRepository = userRepository;
        //}

        DataAccess.TalepContext db;
        public HomeController()
        {
            db = new DataAccess.TalepContext();
        }
        public ActionResult Index()
        {
            Talep talep = new Talep();
            return View(talep);
        }

        [HttpPost]
        public ActionResult Index(Talep talep)
        {
            try
            {
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {

                    Talep t = new Talep();
                    t.Aciklama = talep.Aciklama;
                    t.Ad = talep.Ad;
                    t.CreatedDate = talep.CreatedDate;
                    t.Dosya = binaryReader.ReadBytes(Request.Files[0].ContentLength); ;
                    t.IsActive = talep.IsActive;
                    t.Soyad = talep.Soyad;
                    t.IsOlumlu = talep.IsOlumlu;
                    t.UserID = (int)Session["UserId"];
                    t.DegerlendirmeZamani = DateTime.Now;




                    db.Taleps.Add(t);
                    db.SaveChanges();
                    return View(t);
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            if (Request.Cookies["login"] != null)
            {
                HttpCookie login = Request.Cookies["login"];
                Login user = new Login();
                user.Email = login["mail"];
                user.Password = login["sifre"];

                return View(user);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            
            Session["email"] = login.Email;
            if (login.RememberMe)
            {
                HttpCookie loginCookie = new HttpCookie("login");
                loginCookie.Values.Add("mail", login.Email);
                loginCookie.Values.Add("sifre", login.Password);
                loginCookie.Expires = DateTime.Now.AddDays(15);

                Response.Cookies.Add(loginCookie);
            }

            User users = db.Users.FirstOrDefault(a => a.Email == login.Email);
            Session["Kullanici"] = users;
            Session["UserId"] = users.Id;
            if (users == null)
            {
                return View(login);
            }


            if (VerifyPasswordHash(login.Password, users.passwordHash, users.passwordSalt))
            {

                if (users.IsAdmin == true)
                {
                    return RedirectToAction("TalepList", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Hata = "Giriş Bilgilerinizi Kontrol Ediniz.";
                return View(login);
            }
        }


        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        #region Create Account
        public ActionResult CreateAccount()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(UserViewModel user)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            var check = db.Users.FirstOrDefault(s => s.Email == user.Email);
            if (check == null)
            {
                User model = new User();
                model.Phone = user.Phone;
                model.passwordHash = passwordHash;
                model.passwordSalt = passwordSalt;
                model.Email = user.Email;
                try
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                    ViewBag.Basarili = "Kayıt başarılı";
                    return RedirectToAction("Login", "Home");


                }
                catch (Exception ex)
                {
                    ViewBag.Basarisiz = "Kayıt başarısız";
                    return View();
                }
            }
            else
            {
                ViewBag.error = "Bu mail adresi zaten var";
                return View();
            }


        }
        #endregion
    }
}