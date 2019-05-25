using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB_First_Demo.Models;

namespace DB_First_Demo.Controllers
{
    public class DBOperationsController : Controller
    {
        private DBFirstEntities db = new DBFirstEntities();

        // GET: DBOperations
        public ActionResult Index()
        {
            return View(db.DemoTables.ToList());
        }

        // GET: DBOperations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTable demoTable = db.DemoTables.Find(id);
            if (demoTable == null)
            {
                return HttpNotFound();
            }
            return View(demoTable);
        }

        // GET: DBOperations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DBOperations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,Age")] DemoTable demoTable)
        {
            if (ModelState.IsValid)
            {
                db.DemoTables.Add(demoTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demoTable);
        }

        // GET: DBOperations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTable demoTable = db.DemoTables.Find(id);
            if (demoTable == null)
            {
                return HttpNotFound();
            }
            return View(demoTable);
        }

        // POST: DBOperations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,Age")] DemoTable demoTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demoTable);
        }

        // GET: DBOperations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTable demoTable = db.DemoTables.Find(id);
            if (demoTable == null)
            {
                return HttpNotFound();
            }
            return View(demoTable);
        }

        // POST: DBOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemoTable demoTable = db.DemoTables.Find(id);
            db.DemoTables.Remove(demoTable);
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
