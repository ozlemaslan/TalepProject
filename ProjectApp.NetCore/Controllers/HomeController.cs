using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.DataAccess.Interfaces;

namespace ProjectApp.NetCore.Controllers
{
    public class HomeController : Controller
    {
        ITalepRepository _talepRepository;
        IUserRepository _userRepository;
        public HomeController(ITalepRepository talepRepository, IUserRepository userRepository)
        {
            _talepRepository = talepRepository;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
