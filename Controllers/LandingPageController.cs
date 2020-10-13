using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200_Team8_Scrum.Models;

namespace MIS4200_Team8_Scrum.Controllers
{
    public class LandingPageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LandingPage
        public ActionResult Index()
        {
            return View(db.LandingPages.ToList());
        }

        // GET: LandingPage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandingPage landingPage = db.LandingPages.Find(id);
            if (landingPage == null)
            {
                return HttpNotFound();
            }
            return View(landingPage);
        }

        // GET: LandingPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandingPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "landingPageID")] LandingPage landingPage)
        {
            if (ModelState.IsValid)
            {
                db.LandingPages.Add(landingPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(landingPage);
        }

        // GET: LandingPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandingPage landingPage = db.LandingPages.Find(id);
            if (landingPage == null)
            {
                return HttpNotFound();
            }
            return View(landingPage);
        }

        // POST: LandingPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "landingPageID")] LandingPage landingPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(landingPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(landingPage);
        }

        // GET: LandingPage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandingPage landingPage = db.LandingPages.Find(id);
            if (landingPage == null)
            {
                return HttpNotFound();
            }
            return View(landingPage);
        }

        // POST: LandingPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LandingPage landingPage = db.LandingPages.Find(id);
            db.LandingPages.Remove(landingPage);
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
