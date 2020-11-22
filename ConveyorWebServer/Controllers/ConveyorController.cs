﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ConveyorWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConveyorController : Controller
    {
        [HttpPost("state")]
        public JsonResult GetState([FromServices] IConveyor conveyor)
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
        [HttpPost("add", Name ="type")]
        public IActionResult AddProduct(string type, [FromServices] IConveyor conveyor)
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
        [HttpPost("push")]
        public IActionResult PushProduct([FromServices] IConveyor conveyor)
        {
            conveyor.PushProdcut();
            return StatusCode(200);
        }


    }
}
