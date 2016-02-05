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
using LIFFMVC2.Repository;

namespace LIFFMVC2.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminFilmsController : Controller
    {
        private IFilmRepository repository = new SQLFilmRepository();

        // GET: Films
        public ActionResult Index()
        {
            return View(repository.GetAllFilms().ToList());
        }

        // GET: Films/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var film = repository.GetFilmById(id).FirstOrDefault();

            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Year,Description,TrailerURL,RunningTime,Subtitles")] Film film)
        {
            if (ModelState.IsValid)
            {
                repository.AddFilm(film);
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Films/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = (Film)repository.GetFilmById(id).FirstOrDefault();
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Year,Description,TrailerURL,RunningTime,Subtitles")] Film film)
        {
            if (ModelState.IsValid)
            {
                repository.ModifyFilmState(film, EntityState.Modified);
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = (Film)repository.GetFilmById(id).FirstOrDefault();
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = (Film)repository.GetFilmById(id);
            repository.DeleteFilm(film);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (repository != null)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
