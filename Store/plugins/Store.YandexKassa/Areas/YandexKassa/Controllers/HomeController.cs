﻿using Microsoft.AspNetCore.Mvc;
using Store.YandexKassa.Areas.YandexKassa.Models;

namespace Store.YandexKassa.Areas.YandexKassa.Controllers
{
    [Area("YandexKassa")]
    public class HomeController : Controller       //изменено
    {
        public IActionResult Index(int orderId, string returnUri)
        {
            var model = new ExampleModel
            {
                OrderId = orderId,
                ReturnUri = returnUri,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Callback(int orderId, string returnUri)
        {
            var model = new ExampleModel
            {
                OrderId = orderId,
                ReturnUri = returnUri,
            };

            return View("Finish",model);
        }
    }
}
