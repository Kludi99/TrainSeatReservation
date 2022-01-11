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
    public class RouteController : Controller
    {
        private readonly IRouteFcd _routeFcd;
        private readonly ITrainFcd _trainFcd;


        public RouteController(IRouteFcd routeFcd, ITrainFcd trainFcd)
        {
            _routeFcd = routeFcd;
            _trainFcd = trainFcd;
        }

        // GET: Administration/Route
        public async Task<IActionResult> Index(int page =1)
        {
            var routes = _routeFcd.GetRoutes();

            var routesView = new RouteViewModel
            {
                RoutesPerPage = 10,
                Routes = routes.OrderBy(x => x.Name),
                CurrentPage = page
            };
            return View(routesView);
        }

        // GET: Administration/Route/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Administration/Route/Create
        public IActionResult Create()
        {
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Name");
            return View();
        }

        // POST: Administration/Route/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TrainId")] RouteDto route)
        {
            if (ModelState.IsValid)
            {
                _routeFcd.AddRoute(route);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Name", route.TrainId);
            return View(route);
        }

        // GET: Administration/Route/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Name", route.TrainId);
            return View(route);
        }

        // POST: Administration/Route/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TrainId")] RouteDto route)
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
            ViewData["TrainId"] = new SelectList(_trainFcd.GetTrains(), "Id", "Name", route.TrainId);
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
            var route = _routeFcd.GetRoute(id);
            _routeFcd.DeleteRoute(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return _routeFcd.IsRouteExists(id);
        }
    }
}
