using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TCYDMWebApp.Controllers
{
    public class ActionsController : Controller
    {
        [HttpGet]
        public IActionResult OnlineTurn()
        {
            return View();
        }
    }
}
