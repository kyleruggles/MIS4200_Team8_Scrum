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
    public class coreValuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: coreValues
        public ActionResult Index()
        {
            return View(db.coreValues.ToList());
        }

        // GET: coreValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coreValues coreValues = db.coreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            return View(coreValues);
        }

        // GET: coreValues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: coreValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coreValuesId,coreValue")] coreValues coreValues)
        {
            if (ModelState.IsValid)
            {
                db.coreValues.Add(coreValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coreValues);
        }

        // GET: coreValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coreValues coreValues = db.coreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            return View(coreValues);
        }

        // POST: coreValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coreValuesId,coreValue")] coreValues coreValues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coreValues);
        }

        // GET: coreValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coreValues coreValues = db.coreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            return View(coreValues);
        }

        // POST: coreValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            coreValues coreValues = db.coreValues.Find(id);
            db.coreValues.Remove(coreValues);
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
