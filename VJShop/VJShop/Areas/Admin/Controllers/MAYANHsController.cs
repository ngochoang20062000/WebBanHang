using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VJShop.Areas.Admin.Models;

namespace VJShop.Areas.Admin.Controllers
{
    public class MAYANHsController : Controller
    {
        private vjshop_dtb db = new vjshop_dtb();


        // GET: Admin/MAYANHs
        public ActionResult Index()
        {
            try
            {
                var mAYANHs = db.MAYANHs.Include(m => m.DMMAYANH);
                return View(mAYANHs.ToList());
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi kết nối đến cơ sở dữ liệu" + ex.Message;
                return View();
            }
            
        }

        // GET: Admin/MAYANHs/Details/5
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

        // GET: Admin/MAYANHs/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DMMAYANHs, "MaDM", "TieuDe");
            return View();
        }

        // POST: Admin/MAYANHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaAnh,TieuDe,AnhDaiDien,GiaBan,SoLuong,MoTa,MaDM")] MAYANH mAYANH)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mAYANH.AnhDaiDien = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {

                        string FileName = System.IO.Path.GetFileName(f.FileName);

                        string UploadPath = Server.MapPath("~/Content/image/" + FileName);

                        f.SaveAs(UploadPath);

                        mAYANH.AnhDaiDien = FileName;
                    }
                    db.MAYANHs.Add(mAYANH);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;

            }
            ViewBag.MaDM = new SelectList(db.DMMAYANHs, "MaDM", "TieuDe", mAYANH.MaDM);
            return View(mAYANH);
        }

        // GET: Admin/MAYANHs/Edit/5
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

        // POST: Admin/MAYANHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaAnh,TieuDe,AnhDaiDien,GiaBan,SoLuong,MoTa,MaDM")] MAYANH mAYANH)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        
                        string UploadPath = Server.MapPath("~/Content/image/" + FileName);
                        
                        f.SaveAs(UploadPath);
                        
                        mAYANH.AnhDaiDien = FileName;
                    }
                    db.Entry(mAYANH).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi hãy nhập dữ liệu!" + ex.Message;

            }
            
                ViewBag.MaDM = new SelectList(db.DMMAYANHs, "MaDM", "TieuDe", mAYANH.MaDM);
                return View(mAYANH);
            
            
        }

        // GET: Admin/MAYANHs/Delete/5
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

        // POST: Admin/MAYANHs/Delete/5
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
