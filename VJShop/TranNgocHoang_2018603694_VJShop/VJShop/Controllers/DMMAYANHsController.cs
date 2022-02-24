using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VJShop.Areas.Admin.Models;

namespace VJShop.Controllers
{
    public class DMMAYANHsController : Controller
    {
        private vjshop_dtb db = new vjshop_dtb();


        // GET: DMMAYANHs
        public ActionResult Index()
        {
            try
            {
                return View(db.DMMAYANHs.ToList());
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi kết nối đến cơ sở dữ liệu" + ex.Message;
                return View();
            }
            
        }

        // GET: DMMAYANHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMMAYANH dMMAYANH = db.DMMAYANHs.Find(id);
            if (dMMAYANH == null)
            {
                return HttpNotFound();
            }
            return View(dMMAYANH);
        }

        // GET: DMMAYANHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DMMAYANHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TieuDe,AnhDaiDien,GiaBan")] DMMAYANH dMMAYANH)
        {
            if (ModelState.IsValid)
            {
                db.DMMAYANHs.Add(dMMAYANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMMAYANH);
        }

        // GET: DMMAYANHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMMAYANH dMMAYANH = db.DMMAYANHs.Find(id);
            if (dMMAYANH == null)
            {
                return HttpNotFound();
            }
            return View(dMMAYANH);
        }

        // POST: DMMAYANHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TieuDe,AnhDaiDien,GiaBan")] DMMAYANH dMMAYANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMMAYANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMMAYANH);
        }

        // GET: DMMAYANHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMMAYANH dMMAYANH = db.DMMAYANHs.Find(id);
            if (dMMAYANH == null)
            {
                return HttpNotFound();
            }
            return View(dMMAYANH);
        }

        // POST: DMMAYANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DMMAYANH dMMAYANH = db.DMMAYANHs.Find(id);
            db.DMMAYANHs.Remove(dMMAYANH);
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
