﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NecessaryDrugs.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy = "InternalOfficials")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
