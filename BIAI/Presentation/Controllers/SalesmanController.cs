using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
   
    public class SalesmanController : Controller
    {
        public SalesmanController()
        {

        }

        [HttpGet]
        public IActionResult MainPage()
        {
            return View();

        }

        [HttpPost]
        public IActionResult MainPage(FileViewModel file)
        {
            var name = file.File.OpenReadStream();
            StreamReader stream = new StreamReader(name);
            
            return View();
        }
    }
}
