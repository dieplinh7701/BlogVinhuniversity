using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        TinTucDaiHocVinhEntities9 objTinTucDaiHocVinhEntities1 = new TinTucDaiHocVinhEntities9();
        // GET: Contact/Contact
        public ActionResult Index(string SearchString)
        {
            if (SearchString != null)
            {
                var listProduct = objTinTucDaiHocVinhEntities1.Contacts.Where(n => n.Email.Contains(SearchString)).ToList();
                return View(listProduct);
            }
            else
            {
                var listProduct = objTinTucDaiHocVinhEntities1.Contacts.ToList();
                return View(listProduct);
            }
        }
        public ActionResult Details(int Id)
        {
            var objProduct = objTinTucDaiHocVinhEntities1.Contacts.Where(n => n.ContactId == Id).FirstOrDefault();
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogNew tb_Menu = objTinTucDaiHocVinhEntities1.BlogNews.Find(id);
            if (tb_Menu == null)
            {
                return HttpNotFound();
            }
            return View(tb_Menu);
        }
    }
}