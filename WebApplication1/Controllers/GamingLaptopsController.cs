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
    public class GamingLaptopsController : Controller
    {
        private PHASE3ENDPROJ2Entities db = new PHASE3ENDPROJ2Entities();

        // GET: GamingLaptops
        public ActionResult Index()
        {
            return View(db.GamingLaptops.ToList());
        }

        // GET: GamingLaptops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamingLaptop gamingLaptop = db.GamingLaptops.Find(id);
            if (gamingLaptop == null)
            {
                return HttpNotFound();
            }
            return View(gamingLaptop);
        }

        // GET: GamingLaptops/Create
        public ActionResult Create()
        {
            return View(new GamingLaptop());
        }

        // POST: GamingLaptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price")] GamingLaptop gamingLaptop)
        {
            if (ModelState.IsValid)
            {
                db.GamingLaptops.Add(gamingLaptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gamingLaptop);
        }

        // GET: GamingLaptops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamingLaptop gamingLaptop = db.GamingLaptops.Find(id);
            if (gamingLaptop == null)
            {
                return HttpNotFound();
            }
            return View(gamingLaptop);
        }

        // POST: GamingLaptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")] GamingLaptop gamingLaptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamingLaptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gamingLaptop);
        }

        // GET: GamingLaptops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamingLaptop gamingLaptop = db.GamingLaptops.Find(id);
            if (gamingLaptop == null)
            {
                return HttpNotFound();
            }
            return View(gamingLaptop);
        }

        // POST: GamingLaptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GamingLaptop gamingLaptop = db.GamingLaptops.Find(id);
            db.GamingLaptops.Remove(gamingLaptop);
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
