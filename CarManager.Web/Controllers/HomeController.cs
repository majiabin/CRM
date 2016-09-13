using System;
using System.Collections.Generic;
using System.Dynamic;
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
            dynamic model = new ExpandoObject();//动态类型
            model.Id = 12345;
            model.Name = "张三";
            model.Age = "11";

            return View(carService.GetCars());//

        }

    }
}