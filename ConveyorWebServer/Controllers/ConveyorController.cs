using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConveyorWebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConveyorController : Controller
    {
        [HttpPost("getstate")]
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
        /// </summary>1
        /// <param name="type">Тип нового продукта, который надо добавить</param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult AddProduct([FromServices] IConveyor conveyor)
        {
            //Получение типа, который надо добавить
            var body = Request.BodyReader;
            var result = body.ReadAsync();
            var text2 = result.Result.Buffer;
            string type = Encoding.UTF8.GetString(text2);
            if (type == "good") 
                conveyor.AddProduct(1);
            else if (type == "defective") 
                conveyor.AddProduct(2);
            else
                throw new Exception("Передан не правильный продукт");
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
