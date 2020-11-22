using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public JsonResult Index()
        {
            return Json("text");
        }

        // GET: ConveyorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConveyorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConveyorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConveyorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConveyorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConveyorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConveyorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
