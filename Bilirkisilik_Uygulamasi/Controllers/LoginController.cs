using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilirkisilik_Uygulamasi.Models.Entity;
using System.Web.Security;


namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBL_BILIRKISILER p)
        {
            var bilgiler =
                db.TBL_BILIRKISILER.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICIADI, false);
                Session["KULLANICIADI"] = bilgiler.KULLANICIADI.ToString();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}