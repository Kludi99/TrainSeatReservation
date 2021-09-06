using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;
using TrainSeatReservation.Interfaces.Facades;

namespace TrainSeatReservation.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CarriageController : Controller
    {
        private readonly ICarriageFcd _carriageFcd;

        public CarriageController(ICarriageFcd carriageFcd)
        {
            _carriageFcd = carriageFcd;
        }

        // GET: Administration/Carriage
        public async Task<IActionResult> Index()
        {
            var carriages = _carriageFcd.GetCarriages();
            return View(_carriageFcd.GetCarriages());
        }

        // GET: Administration/Carriage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Carriage = _carriageFcd.GetCarriage(id.Value);
            if (Carriage == null)
            {
                return NotFound();
            }

            return View(Carriage);
        }

        // GET: Administration/Carriage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/Carriage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarriageDto carriage)
        {
            if (ModelState.IsValid)
            {
                _carriageFcd.AddCarriage(carriage);
                return RedirectToAction(nameof(Index));
            }
            return View(carriage);
        }

        // GET: Administration/Carriage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriage = _carriageFcd.GetCarriage(id.Value);
            if (carriage == null)
            {
                return NotFound();
            }
            return View(carriage);
        }

        // POST: Administration/Carriage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarriageDto carriage)
        {
            if (id != carriage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carriageFcd.UpdateCarriage(carriage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarriageExists(carriage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carriage);
        }

        // GET: Administration/Carriage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Carriage = _carriageFcd.GetCarriage(id.Value);
            if (Carriage == null)
            {
                return NotFound();
            }

            return View(Carriage);
        }

        // POST: Administration/Carriage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var Carriage = _CarriageFcd.GetCarriage(id);
            _carriageFcd.DeleteCarriage(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CarriageExists(int id)
        {
            return _carriageFcd.IsCarriageExists(id);
        }
    }
}
