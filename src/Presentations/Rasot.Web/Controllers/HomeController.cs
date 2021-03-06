﻿using Microsoft.AspNetCore.Mvc;
using Rasot.Core.Caching;
using Rasot.Web.Factories;
using Rasot.Web.Framework.Controllers;
using Rasot.Web.Models;
using System.Diagnostics;

namespace Rasot.Web.Controllers
{

    public class HomeController : BaseController
    {


        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly ICacheManager _cacheManager;
        public HomeController(ICustomerModelFactory customerModelFactory,ICacheManager cacheManager)
        {
            _customerModelFactory = customerModelFactory;
            _cacheManager = cacheManager;
        }
        public IActionResult Index()
        {
           
            var model= _customerModelFactory.PrepareCustomerShortModel(1);
             

            return View();
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
