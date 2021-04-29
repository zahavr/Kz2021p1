using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model;
using WebApplication1.EfStuff.Repositoryies;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ScheduleController : Controller
    {
        private ScheduleRepository _scheduleRepository;
        private SportComplexRepository _SportComplexRepository;
        public ScheduleController(ScheduleRepository scheduleRepository, SportComplexRepository sportComplexRepository)
        {
            _scheduleRepository = scheduleRepository;
            _SportComplexRepository = sportComplexRepository;
        }
        
        public ActionResult Index(long id)
        {
            var viewModels = _scheduleRepository.GetAll();
            viewModels
            .Select(x => new ScheduleViewModel()
            {
                //days = x.days,
                //count = x.count,
                days = x.days
            }).ToList();
            return View();
        }
        [HttpGet]
        // GET: ScheduleController/Details/5
        public ActionResult AddSchedule()
        {
            var monday = new dayOfWeek
            {
                name = "Monday"
            };
            var tuesday = new dayOfWeek
            {
                name = "Tuesday"
            };
            var wednesday = new dayOfWeek
            {
                name = "Wednesday"
            };
            var thursday = new dayOfWeek
            {
                name = "Thursday"
            };
            var friday = new dayOfWeek
            {
                name = "Friday"
            };
            var schedule = new ScheduleViewModel();
            schedule.days.Add(monday);
            schedule.days.Add(tuesday);
            schedule.days.Add(wednesday);
            schedule.days.Add(thursday);
            schedule.days.Add(friday);
            return View(schedule);
        }

        // GET: ScheduleController/Create
        public ActionResult Create(ScheduleViewModel newSchedule)
        {
            var schedule = new Schedule()
            {
                
            };

            _scheduleRepository.Save(schedule);
            return View();
        }

        // POST: ScheduleController/Create
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

        // GET: ScheduleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScheduleController/Edit/5
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

        // GET: ScheduleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScheduleController/Delete/5
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
