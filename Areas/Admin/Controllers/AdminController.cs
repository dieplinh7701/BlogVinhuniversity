using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        TinTucDaiHocVinhEntities9 objTinTucDaiHocVinhEntities1 = new TinTucDaiHocVinhEntities9();
        // GET: Admin/Admin
        public ActionResult Index(string SearchString)
        {
            if (SearchString != null)
            {
                var listProduct = objTinTucDaiHocVinhEntities1.Users.Where(n => n.UserName.Contains(SearchString)).ToList();
                return View(listProduct);
            }
            else
            {
                var listProduct = objTinTucDaiHocVinhEntities1.Users.ToList();
                return View(listProduct);
            }
        }
        public ActionResult Details(int Id)
        {
            var objProduct = objTinTucDaiHocVinhEntities1.Users.Where(n => n.UserId == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User objProduct)
        {
            try
            {
                objProduct.Password = GetMD5(objProduct.Password);
                objTinTucDaiHocVinhEntities1.Configuration.ValidateOnSaveEnabled = false;
                objTinTucDaiHocVinhEntities1.Users.Add(objProduct);
                objTinTucDaiHocVinhEntities1.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User tb_Menu = objTinTucDaiHocVinhEntities1.Users.Find(id);
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
            User tb_Menu = objTinTucDaiHocVinhEntities1.Users.Find(id);
            objTinTucDaiHocVinhEntities1.Users.Remove(tb_Menu);
            objTinTucDaiHocVinhEntities1.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Admin/tb_Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User tb_Menu = objTinTucDaiHocVinhEntities1.Users.Find(id);
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
        public ActionResult Edit(User tb_Menu)
        {
            if (ModelState.IsValid)
            {
                objTinTucDaiHocVinhEntities1.Entry(tb_Menu).State = EntityState.Modified;
                objTinTucDaiHocVinhEntities1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Menu);
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}