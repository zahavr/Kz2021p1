using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model;
using WebApplication1.EfStuff.Repositoryies;
using WebApplication1.Models;
using System.IO;
using System.Net;
using System.Threading;

namespace WebApplication1.Controllers
{
    public class SportEventController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private SportEventRepository _SportEventRepository;
        public SportEventController(SportEventRepository sportEventRepository, IWebHostEnvironment hostEnvironment)
        {
            _SportEventRepository = sportEventRepository;
            this._hostEnvironment = hostEnvironment;
        }
        public ActionResult Index()
        {
            var viewModels = _SportEventRepository.GetAll()
                .Select(x => new SportEventViewModel()
                {
                    Id = x.Id,
                    title = x.title,
                    description = x.description,
                    img = x.img,
                    date = x.date
                }).ToList();
            return View(viewModels);
        }

        // GET: SportEventController/Details/5
        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }

        // GET: SportEventController/Create
        [HttpPost]
        public async Task<ActionResult> CreateEvent(SportEventViewModel newEvent)
        {
            if (ModelState.IsValid)
            {
                var fileExtention = Path.GetExtension(newEvent.imagefile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(newEvent.imagefile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtention;
                var path = Path.Combine(
                    _hostEnvironment.WebRootPath,
                    "Image", fileName);
                using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    await newEvent.imagefile.CopyToAsync(fileStream);
                }
                newEvent.img = $"/{fileName}";
            }
            var _event = new SportEvent()
            {
                title = newEvent.title,
                description = newEvent.description,
                date = newEvent.date,  
                img = newEvent.img
            };

            _SportEventRepository.Save(_event);

            return RedirectToAction("Index");
        }
       
        public ActionResult ShowEvent(long? id)
        {
            var _event = _SportEventRepository.Get((long)id);
            var newEvent = new SportEventViewModel();
            newEvent.title = _event.title;
            newEvent.description = _event.description;
            return View(newEvent);
        }
 
        // POST: SportEventController/Create
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

        [HttpGet]
        public ActionResult EditEvent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _event = _SportEventRepository.Get((long)id);
            if (_event == null)
            {
                return NotFound();
            }
            var newEvent = new SportEventViewModel();
            newEvent.Id = _event.Id;
            newEvent.title = _event.title;
            newEvent.description = _event.description;
            return View(newEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(SportEventViewModel model)
        {
            var _event = _SportEventRepository.Get(model.Id);
            _event.title = model.title;
            _event.description = model.description;
            if (ModelState.IsValid)
            {
                _SportEventRepository.Save(_event);    
            }
            return RedirectToAction("Index");
        }

        public JsonResult Remove(long id)
        {
            Thread.Sleep(2000);

            var _event = _SportEventRepository.Get(id);
            if (_event == null)
            {
                return Json(false);
            }

            _SportEventRepository.Remove(_event);

            return Json(true);
        }
        // GET: SportEventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SportEventController/Delete/5
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
