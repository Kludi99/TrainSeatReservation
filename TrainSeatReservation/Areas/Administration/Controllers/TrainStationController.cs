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
    public class TrainStationController : Controller
    {
        private readonly ITrainStationFcd _trainStationFcd;
        private readonly ITrainFcd _trainFcd;
        private readonly IStationFcd _stationFcd;

        public TrainStationController(ITrainStationFcd trainStationFcd, ITrainFcd trainFcd, IStationFcd stationFcd)
        {
            _trainStationFcd = trainStationFcd;
            _trainFcd = trainFcd;
            _stationFcd = stationFcd;

        }
        // GET: Administration/TrainStation
        public async Task<IActionResult> Index()
        {
           
            return View(_trainStationFcd.GetTrainStations());
        }

        // GET: Administration/TrainStation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainStation = _trainStationFcd.GetTrainStation(id.Value);
            if (trainStation == null)
            {
                return NotFound();
            }

            return View(trainStation);
        }

        // GET: Administration/TrainStation/Create
        public IActionResult Create()
        {
            ViewData["StationId"] = new SelectList(_stationFcd.GetStations(), "Id", "Id");
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Id");
            return View();
        }

        // POST: Administration/TrainStation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrainId,StationId,ArrivalDate,DepartureDate")] TrainStationDto trainStation)
        {
            if (ModelState.IsValid)
            {
                _trainStationFcd.AddTrainStation(trainStation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StationId"] = new SelectList(_stationFcd.GetStations(), "Id", "Id", trainStation.StationId);
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Id", trainStation.TrainId);
            return View(trainStation);
        }

        // GET: Administration/TrainStation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainStation = _trainStationFcd.GetTrainStation(id.Value);
            if (trainStation == null)
            {
                return NotFound();
            }
            ViewData["StationId"] = new SelectList(_stationFcd.GetStations(), "Id", "Id", trainStation.StationId);
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Id", trainStation.TrainId);
            return View(trainStation);
        }

        // POST: Administration/TrainStation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainId,StationId,ArrivalDate,DepartureDate")] TrainStationDto trainStation)
        {
            if (id != trainStation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trainStationFcd.UpdateTrainStation(trainStation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainStationExists(trainStation.Id))
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
            ViewData["StationId"] = new SelectList(_stationFcd.GetStations(), "Id", "Id", trainStation.StationId);
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Id", trainStation.TrainId);
            return View(trainStation);
        }

        // GET: Administration/TrainStation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainStation = _trainStationFcd.GetTrainStation(id.Value);
            if (trainStation == null)
            {
                return NotFound();
            }

            return View(trainStation);
        }

        // POST: Administration/TrainStation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _trainStationFcd.DeleteTrainStation(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrainStationExists(int id)
        {
            return _trainStationFcd.IsTrainStationExists(id);
        }
    }
}
