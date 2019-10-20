using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //跳转到Swagger来调试
            return new RedirectResult("~/swagger");
        }
    }
}