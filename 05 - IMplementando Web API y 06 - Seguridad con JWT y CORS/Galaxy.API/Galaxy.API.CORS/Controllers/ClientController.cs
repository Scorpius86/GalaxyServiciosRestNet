using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.API.CORS.Controllers
{
    [Route("[controller]/[action]")]
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}