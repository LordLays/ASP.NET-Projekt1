﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class TripController : Controller
    {
        private readonly ILogger<TripController> _logger;
        // GET: TripController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TripController/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: TripController/Customer/Create
        public ActionResult CustomerShow(CustomerService service)
        {
            var list = service.GetAll();
            return View("Customer/Show", list);
        }

    }
}
