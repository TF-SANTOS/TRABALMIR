﻿using CadastroDeContatos.Filters;
using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroDeContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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