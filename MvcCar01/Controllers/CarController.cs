using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCar01.Models;

namespace MvcCar01.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> _cars = new List<Car>();
        private static int nextId = 0;

        // GET: Car
        public ActionResult Index()
        {
           
            return View(_cars);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            var car = _cars.Find(c => c.Id == id);
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car newCar, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                newCar.Id = nextId++;
                _cars.Add(newCar);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            var car = _cars.Find(c => c.Id == id);
            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car editCar, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var originalCar = _cars.Find(c => c.Id == id);
                _cars.Remove(originalCar);

                _cars.Add(editCar);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editCar);
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            var car = _cars.Find(c => c.Id == id);
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _cars.Remove( _cars.Find(c => c.Id == id));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var car = _cars.Find(c => c.Id == id);
                return View(car);
            }
        }
    }
}