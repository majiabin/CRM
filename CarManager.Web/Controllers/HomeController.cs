using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.Service.Cars;

namespace CarManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public ActionResult Index()
        {
            return View(carService.GetCars());//zaaaaaaa
        }

    }
}