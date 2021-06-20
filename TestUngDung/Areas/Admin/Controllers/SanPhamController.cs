using ModelEF.Dao;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: Admin/QLSanPham

        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new SanPhamDao();
            var model = user.ListSP(searchString);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Detais(string id)
        {
            var dao = new SanPhamDao();
            var rs = dao.Find(id);

            return View(rs);

        }
        public string SlugName(string text)
        {
            for (int i = 32; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), " ");
            }
            text = text.ToLower();
            text = text.Replace(".", "-");
            text = text.Replace(" ", "-");
            text = text.Replace(",", "-");
            text = text.Replace(";", "-");
            text = text.Replace(":", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string SlugName = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(SlugName, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        [HttpGet]
        public ActionResult Create(string id)
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(san_pham Entity, HttpPostedFileBase Image)
        {
            SetViewBag();
            if (ModelState.IsValid)
            {
                if (Image != null && Image.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Image.FileName);
                    string path = Server.MapPath("~/Areas/Admin/Images/" + filename);
                    Entity.Image = "Images/" + filename;
                    Image.SaveAs(path);
                }
                var dao = new SanPhamDao();
                string rs = dao.Insert(Entity);
                if (!string.IsNullOrEmpty(rs))
                {

                    return RedirectToAction("Index", "SanPham");
                }

                return View();
            }
            else
            {

                return View();
            }

        }



        [HttpGet]
        public ActionResult Update(string id)
        {

            var dao = new SanPhamDao();
            var rs = dao.Find(id.Trim());
            SetViewBag(rs.ID_l);
            return View(rs);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(san_pham Entity, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Image.FileName);
                    string path = Server.MapPath("~/Areas/Admin/Images/" + filename);
                    Entity.Image = "Images/" + filename;
                    Image.SaveAs(path);
                }

                Entity.ID = SlugName(Entity.ID);

                if (new SanPhamDao().Update(Entity))
                {

                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Không thể cập nhật thông tin! Vui lòng kiểm tra lại!");
                }
            }
            return View(Entity);
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var dao = new SanPhamDao().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(string selectedid = null)
        {
            var dao = new MenuTypeDao();
            ViewBag.MenuCategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedid);
        }


    }
}