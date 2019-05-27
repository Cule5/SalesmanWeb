﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Calculator;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
   
    public class SalesmanController : Controller
    {
        private readonly ICalculator _calculator = null;
        public SalesmanController(ICalculator calculator)
        {
            _calculator = calculator;
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
