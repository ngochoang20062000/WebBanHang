using System;
using System.Linq;
using System.Web.Mvc;
using VJShop.Areas.Admin.Models;

namespace VJShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Login(string username, string password)
        {
            try
            {
                using (var db = new vjshop_dtb())
                {

                    var user = db.taikhoans.FirstOrDefault(u => u.TenDN == username);
                    string rs = "";
                    if (user == null)
                    {
                        rs = "Không tồn tại tài khoản";
                    }
                    else if (user.MatKhau == password)
                    {
                        if (user.Quyen == "admin")
                        {
                            rs = "Login...";
                        }
                        else
                        {
                            rs = "Tài khoản không có quyền truy cập vào trang này. Vui lòng liên hệ quản trị viên";
                        }
                    }
                    else
                    {
                        rs = "Sai tài khoản hoặc mật khẩu";
                    }

                    return rs;
                }
            }
            catch (Exception ex)
            {
                string rs = "Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message;
                return rs;
            }
            
        }
    }
}