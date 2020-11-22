using ConveyorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConveyorWeb.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;

        IConveyor conveyor = null;

        public MainController(ILogger<MainController> logger, IConveyor conveyor)
        {
            _logger = logger;
           this.conveyor = conveyor;
        }

        [HttpPost]
        public JsonResult State()
        {
            //Получение состояния
            List<int> states = conveyor.State;
            List<string> strState = new List<string>();
            foreach (int type in states) 
            {
                if (type == 1)
                    strState.Add("good");
                else if (type == 2)
                    strState.Add("defective");
                else;
                    //Тут происходит обработка ошибки
            }
            //Сериализация и ответ серверу
            return Json(strState);
        }

        /// <summary>
        /// Добавление новго продукта
        /// </summary>
        /// <param name="type">Тип нового продукта, который надо добавить</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddProduct(string type)
        {

            if (type == "good")
                conveyor.AddProduct(1);
            else if (type == "defective")
                conveyor.AddProduct(2);
            else
                throw new Exception("Передан не правильный продукт");
            //Добавление, в зависимости от типа
            return StatusCode(200);
        }

        /// <summary>
        /// Обработка запросы на выкидывания продутка из конвера
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PushProduct()
        {
            conveyor.PushProdcut();
            return StatusCode(200);
        }

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
