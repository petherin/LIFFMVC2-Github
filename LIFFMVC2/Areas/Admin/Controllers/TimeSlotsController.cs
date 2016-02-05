using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LIFFMVC2.DataContexts;
using LIFFMVC2.Models;

namespace LIFFMVC2.Areas.Admin.Controllers
{
    [Authorize]
    public class TimeSlotsController : Controller
    {
        private FilmsDb db = new FilmsDb();

        // GET: TimeSlots
        public ActionResult Index()
        {
            var slots = db.Slots.Include(t => t.Film).Include(t => t.Venue);
            return View(slots.ToList());
        }

        // GET: TimeSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlot timeSlot = db.Slots.Find(id);
            if (timeSlot == null)
            {
                return HttpNotFound();
            }
            return View(timeSlot);
        }

        // GET: TimeSlots/Create
        public ActionResult Create()
        {
            ViewBag.FilmID = new SelectList(db.Films, "Id", "Title");
            ViewBag.VenueID = new SelectList(db.Venues, "Id", "Name");
            return View();
        }

        // POST: TimeSlots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime,Selected,FilmID,VenueID")] TimeSlot timeSlot)
        {
            if (ModelState.IsValid)
            {
                db.Slots.Add(timeSlot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmID = new SelectList(db.Films, "Id", "Title", timeSlot.FilmID);
            ViewBag.VenueID = new SelectList(db.Venues, "Id", "Name", timeSlot.VenueID);
            return View(timeSlot);
        }

        // GET: TimeSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlot timeSlot = db.Slots.Find(id);
            if (timeSlot == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmID = new SelectList(db.Films, "Id", "Title", timeSlot.FilmID);
            ViewBag.VenueID = new SelectList(db.Venues, "Id", "Name", timeSlot.VenueID);
            return View(timeSlot);
        }

        // POST: TimeSlots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime,Selected,FilmID,VenueID")] TimeSlot timeSlot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSlot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmID = new SelectList(db.Films, "Id", "Title", timeSlot.FilmID);
            ViewBag.VenueID = new SelectList(db.Venues, "Id", "Name", timeSlot.VenueID);
            return View(timeSlot);
        }

        // GET: TimeSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlot timeSlot = db.Slots.Find(id);
            if (timeSlot == null)
            {
                return HttpNotFound();
            }
            return View(timeSlot);
        }

        // POST: TimeSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSlot timeSlot = db.Slots.Find(id);
            db.Slots.Remove(timeSlot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
