using ModelEF.Dao;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchString, int page = 1, int pagesize = 20)
        {

            var user = new SanPhamDao();
            var model = user.ListAll(searchString);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
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
    }
}