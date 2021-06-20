using ModelEF.Dao;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index(string searchString, int page = 1, int pagesize = 20)
        {

            var user = new SanPhamDao();
            var model = user.ListAll(searchString);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult Detais(string id)
        {
            var dao = new SanPhamDao();
            var rs = dao.Find(id);

            return View(rs);

        }
    }
}