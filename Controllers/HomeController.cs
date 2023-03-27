using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        TinTucDaiHocVinhEntities9 objTinTucDaiHocVinhEntities = new TinTucDaiHocVinhEntities9();
        // GET: Home
        public ActionResult Index()
        {   
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListCategory = objTinTucDaiHocVinhEntities.Categories.ToList();
            objHomeModel.ListBlogNew = objTinTucDaiHocVinhEntities.BlogNews.ToList();
            objHomeModel.ListBanner = objTinTucDaiHocVinhEntities.Banners.ToList();

            return View(objHomeModel);
        }
       /* public ActionResult About()
        {
            return View();
        }*/
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Contact([Bind(Include = "ContactId,Name,Email,Description,ModifiedBy")] Contact objContact)
        {
            if (ModelState.IsValid)
            {
                objTinTucDaiHocVinhEntities.Contacts.Add(objContact);
                objTinTucDaiHocVinhEntities.SaveChanges();
                return RedirectToAction("Contact");
            }

            return View(objContact);
        }
        public ActionResult Tintuc()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListCategory = objTinTucDaiHocVinhEntities.Categories.ToList();
            objHomeModel.ListBlogNew = objTinTucDaiHocVinhEntities.BlogNews.ToList();
            objHomeModel.ListBanner = objTinTucDaiHocVinhEntities.Banners.ToList();
            return View(objHomeModel);
        }

        public ActionResult ChuongTrinhDaoTao()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListCategory = objTinTucDaiHocVinhEntities.Categories.ToList();
            objHomeModel.ListBlogNew = objTinTucDaiHocVinhEntities.BlogNews.ToList();
            objHomeModel.ListBanner = objTinTucDaiHocVinhEntities.Banners.ToList();
            return View(objHomeModel);
        }
        public ActionResult GioiThieu()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListCategory = objTinTucDaiHocVinhEntities.Categories.ToList();
            objHomeModel.ListBlogNew = objTinTucDaiHocVinhEntities.BlogNews.ToList();
            objHomeModel.ListBanner = objTinTucDaiHocVinhEntities.Banners.ToList();
            return View(objHomeModel);
        }

        TinTucDaiHocVinhEntities9 objTinTucDaiHocVinhEntities1 = new TinTucDaiHocVinhEntities9();
        public ActionResult Single(int Id)
        {
            var objSingle = objTinTucDaiHocVinhEntities1.BlogNews.Where(n => n.BlogId == Id).FirstOrDefault();
            return View(objSingle);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User _urser)
        {
            if (ModelState.IsValid)
            {
                var check = objTinTucDaiHocVinhEntities1.Users.FirstOrDefault(s => s.UserName == _urser.UserName);
                if (check == null)
                {
                    _urser.Password = GetMD5(_urser.Password);
                    objTinTucDaiHocVinhEntities1.Configuration.ValidateOnSaveEnabled = false;
                    objTinTucDaiHocVinhEntities1.Users.Add(_urser);
                    objTinTucDaiHocVinhEntities1.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = objTinTucDaiHocVinhEntities1.Users.Where(s => s.UserName.Equals(username) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().UserName;
                    Session["UserId"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
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