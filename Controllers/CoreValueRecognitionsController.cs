using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
            return View(db.CoreValueRecognitions.ToList());
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
            ViewBag.recognized = new SelectList(db.Profiles, "ProfileID", "fullName");
            return View();
        }

        // POST: CoreValueRecognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,award,recognizor,recognized,recognizationDate")] CoreValueRecognitions coreValueRecognitions)
        {
            if (ModelState.IsValid)
            {
                Guid localRecognition;
                Guid.TryParse(User.Identity.GetUserId(), out localRecognition);
                coreValueRecognitions.recognizor = localRecognition;
                db.CoreValueRecognitions.Add(coreValueRecognitions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.recognized = new SelectList(db.Profiles, "ProfileID", "fullName");
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
            return View(coreValueRecognitions);
        }

        // POST: CoreValueRecognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,award,recognizor,recognized,recognizationDate")] CoreValueRecognitions coreValueRecognitions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValueRecognitions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
