using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        TinTucDaiHocVinhEntities9 objTinTucDaiHocVinhEntities = new TinTucDaiHocVinhEntities9();
        // GET: Admin/Product
        public ActionResult Index(string SearchString)
        {
            if (SearchString != null) {
                var listProduct = objTinTucDaiHocVinhEntities.BlogNews.Where(n => n.Title.Contains(SearchString)).ToList();
                return View(listProduct);
            }
            else
            {
                var listProduct = objTinTucDaiHocVinhEntities.BlogNews.ToList();
                return View(listProduct);
            }
        }
        public ActionResult Details(int Id)
        {
            var objProduct = objTinTucDaiHocVinhEntities.BlogNews.Where(n => n.BlogId == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "BlogId,CategoryId,Image,Title,Description,Content,ModifiedBy,IsNew,Highlights")] BlogNew objProduct)
        {
            if (ModelState.IsValid)
            {
                objTinTucDaiHocVinhEntities.BlogNews.Add(objProduct);
                objTinTucDaiHocVinhEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogNew tb_Menu = objTinTucDaiHocVinhEntities.BlogNews.Find(id);
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
            BlogNew tb_Menu = objTinTucDaiHocVinhEntities.BlogNews.Find(id);
            objTinTucDaiHocVinhEntities.BlogNews.Remove(tb_Menu);
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
            BlogNew tb_Menu = objTinTucDaiHocVinhEntities.BlogNews.Find(id);
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
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "BlogId,CategoryId,Image,Title,Description,Detail,Content,ModifiedDate,ModifiedBy,IsNew,Highlights")] BlogNew tb_Menu)
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