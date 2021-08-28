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
    public class StationController : Controller
    {
        private readonly IStationFcd _stationFcd;

        public StationController(IStationFcd stationFcd)
        {
            _stationFcd = stationFcd;
        }

        // GET: Administration/Station
        public async Task<IActionResult> Index()
        {
            return View(_stationFcd.GetStations());
        }

        // GET: Administration/Station/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Station = _stationFcd.GetStation(id.Value);
            if (Station == null)
            {
                return NotFound();
            }

            return View(Station);
        }

        // GET: Administration/Station/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/Station/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Type")] StationDto station)
        {
            if (ModelState.IsValid)
            {
                _stationFcd.AddStation(station);
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        // GET: Administration/Station/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = _stationFcd.GetStation(id.Value);
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }

        // POST: Administration/Station/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Name,Type")] StationDto station)
        {
            if (id != station.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _stationFcd.UpdateStation(station);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.Id))
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
            return View(station);
        }

        // GET: Administration/Station/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = _stationFcd.GetStation(id.Value);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Administration/Station/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var Station = _StationFcd.GetStation(id);
            _stationFcd.DeleteStation(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(int id)
        {
            return _stationFcd.IsStationExists(id);
        }
    }
}
