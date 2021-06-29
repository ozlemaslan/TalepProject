using ProjectApp.DataAccess.Interfaces;
using ProjectApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        TalepContext _context;
        public UserRepository(TalepContext context)
        {
            _context = context;
        }
        public User Delete(User user)
        {
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUserId(int id)
        {
            return _context.Users.Find(id);
        }

        public User Add(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public User Update(User user)
        {
            try
            {
                User u = new User();
                u.passwordSalt = user.passwordSalt;
                u.passwordHash = user.passwordHash;
                u.Email = user.Email;
                u.IsActive = user.IsActive;
                u.IsAdmin = user.IsAdmin;
                u.Phone = user.Phone;
                u.CreatedDate = user.CreatedDate;


                _context.Entry(u).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
