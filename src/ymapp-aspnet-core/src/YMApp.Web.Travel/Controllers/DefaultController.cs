﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YMApp.Controllers;

namespace YMApp.Web.Travel.Controllers
{
    public class DefaultController : YMAppControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}