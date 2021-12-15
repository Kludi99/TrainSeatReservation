using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;

namespace TrainSeatReservation.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class TrainStationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainStationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administration/TrainStation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrainStations.Include(t => t.Route).Include(t => t.Station).Include(t => t.Train).Include(t => t.TrainTimeTable);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/TrainStation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainStation = await _context.TrainStations
                .Include(t => t.Route)
                .Include(t => t.Station)
                .Include(t => t.Train)
                .Include(t => t.TrainTimeTable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainStation == null)
            {
                return NotFound();
            }

            return View(trainStation);
        }

        // GET: Administration/TrainStation/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Name");
            ViewData["StationId"] = new SelectList(_context.Stations, "Id", "Name");
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Name");
            ViewData["TrainTimeTableId"] = new SelectList(_context.TrainTimeTables, "Id", "Id");
            return View();
        }

        // POST: Administration/TrainStation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrainId,StationId,RouteId,TrainTimeTableId")] TrainStation trainStation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", trainStation.RouteId);
            ViewData["StationId"] = new SelectList(_context.Stations, "Id", "Id", trainStation.StationId);
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Id", trainStation.TrainId);
            ViewData["TrainTimeTableId"] = new SelectList(_context.TrainTimeTables, "Id", "Id", trainStation.TrainTimeTableId);
            return View(trainStation);
        }

        // GET: Administration/TrainStation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainStation = await _context.TrainStations.FindAsync(id);
            if (trainStation == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", trainStation.RouteId);
            ViewData["StationId"] = new SelectList(_context.Stations, "Id", "Id", trainStation.StationId);
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Id", trainStation.TrainId);
            ViewData["TrainTimeTableId"] = new SelectList(_context.TrainTimeTables, "Id", "Id", trainStation.TrainTimeTableId);
            return View(trainStation);
        }

        // POST: Administration/TrainStation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainId,StationId,RouteId,TrainTimeTableId")] TrainStation trainStation)
        {
            if (id != trainStation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainStation);
                    await _context.SaveChangesAsync();
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
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", trainStation.RouteId);
            ViewData["StationId"] = new SelectList(_context.Stations, "Id", "Id", trainStation.StationId);
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Id", trainStation.TrainId);
            ViewData["TrainTimeTableId"] = new SelectList(_context.TrainTimeTables, "Id", "Id", trainStation.TrainTimeTableId);
            return View(trainStation);
        }

        // GET: Administration/TrainStation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainStation = await _context.TrainStations
                .Include(t => t.Route)
                .Include(t => t.Station)
                .Include(t => t.Train)
                .Include(t => t.TrainTimeTable)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var trainStation = await _context.TrainStations.FindAsync(id);
            _context.TrainStations.Remove(trainStation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainStationExists(int id)
        {
            return _context.TrainStations.Any(e => e.Id == id);
        }
    }
}
