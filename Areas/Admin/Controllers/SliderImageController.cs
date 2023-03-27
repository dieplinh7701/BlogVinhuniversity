using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class SliderImageController : Controller
    {
        TinTucDaiHocVinhEntities9 objTinTucDaiHocVinhEntities = new TinTucDaiHocVinhEntities9();
        // GET: Admin/SliderImage
        public ActionResult Index(string SearchString)
        {
            if (SearchString != null)
            {
                var listProduct = objTinTucDaiHocVinhEntities.Banners.Where(n => n.Title.Contains(SearchString)).ToList();
                return View(listProduct);
            }
            else
            {
                var listProduct = objTinTucDaiHocVinhEntities.Banners.ToList();
                return View(listProduct);
            }
        }
        public ActionResult Details(int Id)
        {
            var objProduct = objTinTucDaiHocVinhEntities.Banners.Where(n => n.BannerId == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "BannerId,Image,Title,Thumbnail,Description")] Banner objBanner)
        {
            if (ModelState.IsValid)
            {
                objTinTucDaiHocVinhEntities.Banners.Add(objBanner);
                objTinTucDaiHocVinhEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objBanner);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner tb_Menu = objTinTucDaiHocVinhEntities.Banners.Find(id);
            if (tb_Menu == null)
            {
                return HttpNotFound();
            }
            return View(tb_Menu);
        }

        // POST: Admin/tb_Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner tb_Menu = objTinTucDaiHocVinhEntities.Banners.Find(id);
            objTinTucDaiHocVinhEntities.Banners.Remove(tb_Menu);
            objTinTucDaiHocVinhEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Admin/tb_Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner tb_Menu = objTinTucDaiHocVinhEntities.Banners.Find(id);
            var cate = objTinTucDaiHocVinhEntities.Categories.ToList();
            ViewBag.catelist = cate;
            if (tb_Menu == null)
            {
                return HttpNotFound();
            }
            return View(tb_Menu);
        }

        // POST: Admin/tb_Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Banner tb_Menu)
        {
            if (ModelState.IsValid)
            {
                objTinTucDaiHocVinhEntities.Entry(tb_Menu).State = EntityState.Modified;
                objTinTucDaiHocVinhEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Menu);
        }

    }
}