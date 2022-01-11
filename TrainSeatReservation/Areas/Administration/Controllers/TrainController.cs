//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainSeatReservation.Areas.Administration.Models;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;
using TrainSeatReservation.Interfaces.Facades;

namespace TrainSeatReservation.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class TrainController : Controller
    {
        private readonly ITrainFcd _trainFcd;
        private readonly IDictionaryFcd _dictionaryFcd;

        public TrainController(ITrainFcd trainFcd, IDictionaryFcd dictionaryFcd)
        {
            _trainFcd = trainFcd;
            _dictionaryFcd = dictionaryFcd;
        }

        // GET: Administration/Train
        public async Task<IActionResult> Index(int page =1)
        {
            var trains = _trainFcd.GetTrains();
            var trainsView = new TrainViewModel
            {
                TrainsPerPage = 10,
                Trains = trains.OrderBy(x => x.Name),
                CurrentPage = page
            };
            return View(trainsView);
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
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(1), "Id", "Name");
            return View();
        }

        // POST: Administration/Train/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,TypeId,IsActive")] TrainDto train)
        {
            if (ModelState.IsValid)
            {
                train.IsActive = true;
                _trainFcd.AddTrain(train);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(1), "Id", "Name", train.TypeId);
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
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(1), "Id", "Name", train.TypeId);
            return View(train);
        }

        // POST: Administration/Train/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Name,TypeId,IsActive")] TrainDto train)
        {
            if (id != train.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    train.IsActive = true;
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
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(1), "Id", "Name", train.TypeId);
            return View(train);
        }

        // GET: Administration/Train/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Administration/Train/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _trainFcd.DeleteTrain(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrainExists(int id)
        {
            return _trainFcd.IsTrainExists(id);
        }
    }
}
