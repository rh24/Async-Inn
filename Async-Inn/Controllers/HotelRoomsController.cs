using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.ViewModels;

namespace AsyncInn.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? HotelID, int? RoomID)
        {
            if (HotelID == null || RoomID == null)
            {
                return NotFound();
            }

            var hotelRooms = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomID == RoomID);
            if (hotelRooms == null)
            {
                return NotFound();
            }

            return View(hotelRooms);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRooms hotelRooms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(hotelRooms);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(DisplayError));
                }
            }

            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRooms.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRooms.RoomID);
            return View(hotelRooms);
        }

        // Display view model data saying it's a duplicate room
        public ViewResult DisplayError()
        {
            DuplicateObject dup = new DuplicateObject
            {
                ErrorMessage = "I'm sorry. You're trying to create a hotel room that already exists in the database. This is not allowed."
            };
            ViewBag.dup = dup;
            return View("../Home/Index");
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? HotelID, int? RoomID)
        {
            if (HotelID == null && RoomID == null)
            {
                return NotFound();
            }
            var hotelRoom = await _context.HotelRooms.FindAsync(HotelID, RoomID);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int HotelID, int RoomID, [Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRooms hotelRooms)
        {
            if (HotelID != hotelRooms.HotelID && RoomID != hotelRooms.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomsExists(hotelRooms.HotelID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRooms.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRooms.RoomID);
            return View(hotelRooms);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? HotelID, int? RoomID)
        {
            if (HotelID == null || RoomID == null)
            {
                return NotFound();
            }

            var hotelRooms = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomID == RoomID);
            if (hotelRooms == null)
            {
                return NotFound();
            }

            return View(hotelRooms);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRooms = await _context.HotelRooms.FindAsync(id);
            _context.HotelRooms.Remove(hotelRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomsExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
