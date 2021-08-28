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
    public class RouteController : Controller
    {
        private readonly IRouteFcd _routeFcd;

        public RouteController(IRouteFcd routeFcd)
        {
            _routeFcd = routeFcd;
        }

        // GET: Administration/Route
        public async Task<IActionResult> Index()
        {
            return View(_routeFcd.GetRoutes());
        }

        // GET: Administration/Route/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Route = _routeFcd.GetRoute(id.Value);
            if (Route == null)
            {
                return NotFound();
            }

            return View(Route);
        }

        // GET: Administration/Route/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/Route/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Type")] RouteDto route)
        {
            if (ModelState.IsValid)
            {
                _routeFcd.AddRoute(route);
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // GET: Administration/Route/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Route = _routeFcd.GetRoute(id.Value);
            if (Route == null)
            {
                return NotFound();
            }
            return View(Route);
        }

        // POST: Administration/Route/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Name,Type")] RouteDto route)
        {
            if (id != route.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _routeFcd.UpdateRoute(route);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.Id))
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
            return View(route);
        }

        // GET: Administration/Route/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = _routeFcd.GetRoute(id.Value);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Administration/Route/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var Route = _RouteFcd.GetRoute(id);
            _routeFcd.DeleteRoute(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return _routeFcd.IsRouteExists(id);
        }
    }
}
