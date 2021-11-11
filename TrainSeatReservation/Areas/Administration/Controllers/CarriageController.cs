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
        //private readonly ApplicationDbContext _context;
        private readonly ICarriageFcd _carriageFcd;
        private readonly IDictionaryFcd _dictionaryFcd;
        private readonly INotificationFcd _notificationFcd;
        public CarriageController(ICarriageFcd carriageFcd, IDictionaryFcd dictionaryFcd, INotificationFcd notificationFcd)
        {
            _carriageFcd = carriageFcd;
            _dictionaryFcd = dictionaryFcd;
            _notificationFcd = notificationFcd;
        }

        // GET: Administration/Carriage
        public async Task<IActionResult> Index()
        {
            // var applicationDbContext = _context.Carriages.Include(c => c.CarriageClass).Include(c => c.Type);
            var carriages = _carriageFcd.GetCarriages();
            return View(carriages);
        }

        // GET: Administration/Carriage/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Administration/Carriage/Create
        public IActionResult Create()
        {
            ViewData["CarriageClassId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(), "Id", "Name");
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(), "Id", "Name");
            return View();
        }

        // POST: Administration/Carriage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,TypeId,CarriageClassId,IsActive,EletricalOutlet,CateringCar,BicyclePlace")] CarriageDto carriage)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(carriage);
                //await _context.SaveChangesAsync();
                _carriageFcd.AddCarriage(carriage);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarriageClassId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(3), "Id", "Name", carriage.CarriageClassId);
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(2), "Id", "Name", carriage.TypeId);
            return View(carriage);
        }

        // GET: Administration/Carriage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriage = _carriageFcd.GetCarriage(id.Value); //await _context.Carriages.FindAsync(id);
            if (carriage == null)
            {
                return NotFound();
            }
            ViewData["CarriageClassId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(3), "Id", "Name", carriage.CarriageClassId);
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(2), "Id", "Name", carriage.TypeId);
            return View(carriage);
        }

        // POST: Administration/Carriage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,TypeId,CarriageClassId,IsActive,EletricalOutlet,CateringCar,BicyclePlace")] CarriageDto carriage)
        {
            if (id != carriage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(carriage);
                    //await _context.SaveChangesAsync();
                    var oldCarriage = _carriageFcd.GetCarriage(carriage.Id);
                    _carriageFcd.UpdateCarriage(carriage);
                    var newCarriage = _carriageFcd.GetCarriage(carriage.Id);
                    var message = MessageContent(oldCarriage, newCarriage);
                    if(message != string.Empty)
                    {
                        _notificationFcd.SendCarriageChangeMesssage(id, message);
                    }
                    
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
            ViewData["CarriageClassId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(3), "Id", "Name", carriage.CarriageClassId);
            ViewData["TypeId"] = new SelectList(_dictionaryFcd.GetDictionaryItems(2), "Id", "Name", carriage.TypeId);
            return View(carriage);
        }

        // GET: Administration/Carriage/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Administration/Carriage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _carriageFcd.DeleteCarriage(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CarriageExists(int id)
        {
            return _carriageFcd.IsCarriageExists(id);
        }
        private string MessageContent(CarriageDto oldCarriage, CarriageDto updatedCarriage)
        {
            var message = string.Empty;
            if(oldCarriage.BicyclePlace != updatedCarriage.BicyclePlace)
            {
                if(updatedCarriage.BicyclePlace == true)
                {
                    message+= "W Twoim wagonie pojawiło się miejsce na rowery. \n";
                }
                else
                message += "W wagonie nie ma miejsc na rowery. \n";
            }
            if (oldCarriage.EletricalOutlet != updatedCarriage.EletricalOutlet)
            {
                if (updatedCarriage.EletricalOutlet == true)
                {
                    message += "W Twoim wagonie pojawiło się kontakty \n";
                }
                message += "W wagonie nie ma kontaktów \n";
            }
            if(oldCarriage.CarriageClassId != updatedCarriage.CarriageClassId)
            {
                message += "Zmieniono rodzaj klasy wagonu na " + updatedCarriage.CarriageClass.Name  + '\n';
            }
            if (oldCarriage.TypeId != updatedCarriage.TypeId)
            {
                message += "Zmieniono rodzaj wagonu na " + updatedCarriage.Type.Name;
            }
            return message;

        }
    }
}
