using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.EfStuff.Model;
using WebApplication1.EfStuff.Repositoryies;
using WebApplication1.Models;

namespace WebApplication1.Controllers.BusSystem
{
    public class OrderController : Controller
    {
        private OrderRepository _orderRepository;
        private IMapper _mapper { get; set; }

        public OrderController(OrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var viewModels = _orderRepository.GetAll()
                .Select(x => new OrderViewModel()
                {
                    Name = x.Name,
                    Model = x.Model,
                    Period = x.Period,                    
                }).ToList();
            return View(viewModels);
        }


        [HttpGet]
        public IActionResult MakeOrder()
        {
            return View();
        }


        [HttpGet]
        public IActionResult OrderList()
        {
            var order = new OrderViewModel()
            {
                Name = "admin",
                Model = "ikar",
                Period = 10
            };

            return View(order);
        }


        public IActionResult CheckOrder()
        {
            return View();
        }


        [HttpPost]
        public IActionResult MakeOrder(OrderViewModel newOrder)
        {
            var order = new Order()
            {
                Name = newOrder.Name,
                Model = newOrder.Model,
                Period = newOrder.Period
            };

            _orderRepository.Save(order);

            return RedirectToAction("Index");
        }

        public JsonResult Remove(string name)
        {


            var order = _orderRepository.GetByName(name);
            if (order == null)
            {
                return Json(false);
            }

            _orderRepository.Remove(order);

            return Json(true);
        }

    }
}
