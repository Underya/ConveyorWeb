using ConveyorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;

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
            WebRequest request = WebRequest.Create("http://localhost:60156/Conveyor/getstate");
            request.Method = "POST";
            string res = "";
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    res = reader.ReadToEnd();
                }
            }
            //Десериализация
            string[] jsonRes = JsonSerializer.Deserialize<string[]>(res);
            response.Close();
            return Json(jsonRes);
        }

        /// <summary>
        /// Добавление новго продукта
        /// </summary>
        /// <param name="type">Тип нового продукта, который надо добавить</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProduct(string type)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:60156/Conveyor/add"),
                Method = HttpMethod.Post,
                Content = new StringContent(type)
            };
            var post = client.PostAsync(request.RequestUri, request.Content);
            post.Wait();
            HttpResponseMessage response = post.Result;
            if (!response.IsSuccessStatusCode)
            {
                string responseText = response.Content.ReadAsStringAsync().Result;
                throw new Exception(responseText);
            }
            /*HttpWebRequest request =  (HttpWebRequest)HttpWebRequest.Create("http://localhost:60156/Conveyor/AddProduct");
            request.Method = "POST";
            //request.ContentType = "application / x - www - form - urlencoded";
            string text_param = "type=" + type;
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(text_param);
            request.ContentLength = byteArray.Length;
            //Запись данных в поток
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            //Получение ответа
            string responseText = "";
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseText = reader.ReadToEnd();
                }
            }
            if(responseText == "200")
                return StatusCode(200);
            return StatusCode(int.Parse(responseText));*/
            return StatusCode(200);
        }

        /// <summary>
        /// Обработка запросы на выкидывания продутка из конвера
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PushProduct()
        {
            //Получение состояния
            WebRequest request = WebRequest.Create("http://localhost:60156/Conveyor/push");
            request.Method = "POST";
            string res = "";
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    res = reader.ReadToEnd();
                }
            }
            if (res != "200")
                throw new Exception(res);
            //Десериализация
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
