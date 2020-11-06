using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200_Team8_Scrum.DAL;
using MIS4200_Team8_Scrum.Models;

namespace MIS4200_Team8_Scrum.Controllers
{
    public class CoreValueRecognitionsController : Controller
    {
        private MIS4200_Team8_Scrum_Context db = new MIS4200_Team8_Scrum_Context();

        // GET: CoreValueRecognitions
        public ActionResult Index()
        {
            var coreValueRecognitions = db.CoreValueRecognitions.Include(c => c.personRecognized).Include(c => c.personRecognizor);
            return View(coreValueRecognitions.ToList());
        }

        // GET: CoreValueRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValueRecognitions coreValueRecognitions = db.CoreValueRecognitions.Find(id);
            if (coreValueRecognitions == null)
            {
                return HttpNotFound();
            }
            return View(coreValueRecognitions);
        }

        // GET: CoreValueRecognitions/Create
        public ActionResult Create()
        {
            ViewBag.recognized = new SelectList(db.Profiles, "ProfileId", "fullName");
            ViewBag.recognizor = new SelectList(db.Profiles, "ProfileId", "fullName");
            return View();
        }

        // POST: CoreValueRecognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,recognized,recognizor,award,recognizationDate,Comments")] CoreValueRecognitions coreValueRecognitions)
        {
            if (ModelState.IsValid)
            {
                db.CoreValueRecognitions.Add(coreValueRecognitions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recognized = new SelectList(db.Profiles, "ProfileId", "fullName", coreValueRecognitions.recognized);
            ViewBag.recognizor = new SelectList(db.Profiles, "ProfileId", "fullName", coreValueRecognitions.recognizor);
            return View(coreValueRecognitions);
        }

        // GET: CoreValueRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValueRecognitions coreValueRecognitions = db.CoreValueRecognitions.Find(id);
            if (coreValueRecognitions == null)
            {
                return HttpNotFound();
            }
            ViewBag.recognized = new SelectList(db.Profiles, "ProfileId", "fullName", coreValueRecognitions.recognized);
            ViewBag.recognizor = new SelectList(db.Profiles, "ProfileId", "fullName", coreValueRecognitions.recognizor);
            return View(coreValueRecognitions);
        }

        // POST: CoreValueRecognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,recognized,recognizor,award,recognizationDate,Comments")] CoreValueRecognitions coreValueRecognitions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValueRecognitions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recognized = new SelectList(db.Profiles, "ProfileId", "fullName", coreValueRecognitions.recognized);
            ViewBag.recognizor = new SelectList(db.Profiles, "ProfileId", "fullName", coreValueRecognitions.recognizor);
            return View(coreValueRecognitions);
        }

        // GET: CoreValueRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValueRecognitions coreValueRecognitions = db.CoreValueRecognitions.Find(id);
            if (coreValueRecognitions == null)
            {
                return HttpNotFound();
            }
            return View(coreValueRecognitions);
        }

        // POST: CoreValueRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoreValueRecognitions coreValueRecognitions = db.CoreValueRecognitions.Find(id);
            db.CoreValueRecognitions.Remove(coreValueRecognitions);
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
