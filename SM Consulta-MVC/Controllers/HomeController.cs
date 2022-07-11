using System.Collections.Generic;
using Auth_Api.Models;﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SM_Consulta_MVC.Models;
using SM_Consulta_MVC.Models.Entity;
using SM_Consulta_MVC.service;
using System.Diagnostics;

namespace SM_Consulta_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            this._logger = logger;
            this._userService = userService;
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult VuewEmployees()
        {
            List<UserEntity> users = this._userService.PullUsers();

            List<PullUserDataModel> employees = new List<PullUserDataModel>();

            foreach (var row in users)
            {
                employees.Add(new PullUserDataModel
                {
                    Name = row.Name,
                    Salary = row.Salary,
                    IncomeTax = row.IncomeTax,
                    HealthSocialInsurance = row.HealthSocialInsurance,
                    TotalTaxes = row.TotalTaxes,
                    NetSaLary = row.NetSaLary,
                });
            }
            return View(employees);
        }

        [HttpPost]
        public IActionResult SignUp(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                this._userService.AddUser(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
