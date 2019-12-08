using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galaxy.API.Token.Models;
using System.IdentityModel.Tokens.Jwt;
using Galaxy.API.Token.Security;
using Galaxy.API.Token.Model;
using Microsoft.AspNetCore.Authorization;

namespace Galaxy.API.Token.Controllers
{
    public class HomeController : Controller
    {
        private JwtSettings _settings;
        public HomeController(JwtSettings settings)
        {
            _settings = settings;
        }
        public IActionResult Index()
        {
            SecurityManager mgr = new SecurityManager(_settings);

            AppUserAuth auth = mgr.ValidateUser();
            return View(auth);
        }

        [Authorize]
        public string APITest()
        {
            return "test";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
