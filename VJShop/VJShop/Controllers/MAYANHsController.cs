using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using VJShop.Areas.Admin.Models;

namespace VJShop.Controllers
{
    public class MAYANHsController : Controller
    {
        private vjshop_dtb db = new vjshop_dtb();

        // GET: MAYANHs
        public ActionResult Index()
        {
            var mAYANHs = db.MAYANHs.Include(m => m.DMMAYANH);
            return View(mAYANHs.ToList());
        }

        // GET: MAYANHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYANH mAYANH = db.MAYANHs.Find(id);
            if (mAYANH == null)
            {
                return HttpNotFound();
            }
            return View(mAYANH);
        }

        // GET: MAYANHs/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DMMAYANHs, "MaDM", "TieuDe");
            return View();
        }

        // POST: MAYANHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaAnh,TieuDe,AnhDaiDien,GiaBan,SoLuong,MoTa,MaDM")] MAYANH mAYANH)
        {
            if (ModelState.IsValid)
            {
                db.MAYANHs.Add(mAYANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DMMAYANHs, "MaDM", "TieuDe", mAYANH.MaDM);
            return View(mAYANH);
        }

        // GET: MAYANHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYANH mAYANH = db.MAYANHs.Find(id);
            if (mAYANH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DMMAYANHs, "MaDM", "TieuDe", mAYANH.MaDM);
            return View(mAYANH);
        }

        // POST: MAYANHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaAnh,TieuDe,AnhDaiDien,GiaBan,SoLuong,MoTa,MaDM")] MAYANH mAYANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAYANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DMMAYANHs, "MaDM", "TieuDe", mAYANH.MaDM);
            return View(mAYANH);
        }

        // GET: MAYANHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYANH mAYANH = db.MAYANHs.Find(id);
            if (mAYANH == null)
            {
                return HttpNotFound();
            }
            return View(mAYANH);
        }

        // POST: MAYANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MAYANH mAYANH = db.MAYANHs.Find(id);
            db.MAYANHs.Remove(mAYANH);
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
