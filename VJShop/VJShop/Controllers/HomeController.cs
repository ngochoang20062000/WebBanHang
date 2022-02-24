using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VJShop.Areas.Admin.Models;

namespace VJShop.Controllers
{
    public class HomeController : Controller
    {
        private vjshop_dtb db = new vjshop_dtb();

        public ActionResult Index(string id)
        {
            
            List<MAYANH> mayanhs = new List<MAYANH>();
            if (id == null)
            {
                mayanhs = db.MAYANHs.Select(ma => ma).ToList();
            }
            else
            {
                mayanhs = db.MAYANHs.Where(ma => ma.MaDM.Equals(id)).Select(ma => ma).ToList();
            }
            return View(mayanhs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ChiTietMayAnh(string id)
        {
            List<MAYANH> mayanh = new List<MAYANH>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mayanh = db.MAYANHs.Where(h => h.MaAnh == id).ToList();
            if (mayanh == null)
            {
                return HttpNotFound();
            }
            return View(mayanh);


        }
    }
}