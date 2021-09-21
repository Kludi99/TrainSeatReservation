using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Interfaces.Facades;

namespace TrainSeatReservation.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class TrainController : Controller
    {
        private readonly ITrainFcd _trainFcd;

        public TrainController(ITrainFcd trainFcd)
        {
            _trainFcd = trainFcd;
        }

        // GET: Administration/Train
        public async Task<IActionResult> Index()
        {
            return View(_trainFcd.GetTrains());
        }

        // GET: Administration/Train/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = _trainFcd.GetTrain(id.Value);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // GET: Administration/Train/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateTrainWithCarriages()
        {
            return View();
        }

        // POST: Administration/Train/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainDto train)
        {
            if (ModelState.IsValid)
            {
                _trainFcd.AddTrain(train);
                return RedirectToAction(nameof(Index));
            }
            return View(train);
        }

        // GET: Administration/Train/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = _trainFcd.GetTrain(id.Value);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // POST: Administration/Train/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TrainDto train)
        {
            if (id != train.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trainFcd.UpdateTrain(train);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainExists(train.Id))
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
            return View(train);
        }

        // GET: Administration/Train/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train =_trainFcd.GetTrain(id.Value);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }
    

        // POST: Administration/Train/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var train = _trainFcd.GetTrain(id);
            _trainFcd.DeleteTrain(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrainExists(int id)
        {
            return _trainFcd.IsTrainExists(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void CreateTrainWithCarriages(TrainDto train, int compartmentless, int compartmental)
        {
            var i = 1;
        }
    }
}
