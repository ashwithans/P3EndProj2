using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentLaptopsController : Controller
    {
        private PHASE3ENDPROJ2Entities db = new PHASE3ENDPROJ2Entities();

        // GET: StudentLaptops
        public ActionResult Index()
        {
            return View(db.StudentLaptops.ToList());
        }

        // GET: StudentLaptops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLaptop studentLaptop = db.StudentLaptops.Find(id);
            if (studentLaptop == null)
            {
                return HttpNotFound();
            }
            return View(studentLaptop);
        }

        // GET: StudentLaptops/Create
        public ActionResult Create()
        {
            return View(new StudentLaptop());
        }

        // POST: StudentLaptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price")] StudentLaptop studentLaptop)
        {
            if (ModelState.IsValid)
            {
                db.StudentLaptops.Add(studentLaptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentLaptop);
        }

        // GET: StudentLaptops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLaptop studentLaptop = db.StudentLaptops.Find(id);
            if (studentLaptop == null)
            {
                return HttpNotFound();
            }
            return View(studentLaptop);
        }

        // POST: StudentLaptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")] StudentLaptop studentLaptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentLaptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentLaptop);
        }

        // GET: StudentLaptops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLaptop studentLaptop = db.StudentLaptops.Find(id);
            if (studentLaptop == null)
            {
                return HttpNotFound();
            }
            return View(studentLaptop);
        }

        // POST: StudentLaptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentLaptop studentLaptop = db.StudentLaptops.Find(id);
            db.StudentLaptops.Remove(studentLaptop);
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
