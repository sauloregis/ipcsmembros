﻿using Microsoft.AspNetCore.Mvc;

namespace ipcsmembros.Controllers
{
    public class MembrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
