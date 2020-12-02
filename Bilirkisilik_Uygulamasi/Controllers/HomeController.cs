using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bilirkisilik_Uygulamasi.Models.Entity;

namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class HomeController : Controller
    {
        DBBILIRKISIEntities1 db=new DBBILIRKISIEntities1();

        [Authorize]
        public ActionResult Index()
        {
            //GELEN DOSYA SAYISI
            var deger1 = db.TBL_BILIRKISILIK.Where(x=>x.DOSYADURUMU == true).Count();
            ViewBag.dgr1 = deger1;

            //TESLİM EDİLEN DOSYA SAYISI
            var deger2 = db.TBL_BILIRKISILIK.Where(x => x.DOSYADURUMU == false).Count();
            ViewBag.dgr2 = deger2;

            //BEKLEYEN DOSYA SAYISI
            var deger3 = deger1-deger2;
            ViewBag.dgr3 = deger3;

            ////BEKLEYEN ÖDEME TOPLAMI
            var deger4 = db.TBL_BILIRKISILIK.Where(x=>x.UCRETDURUM == true).
                Sum(x => x.UCRET);
            ViewBag.dgr4 = deger4;

            //KESİNTİLER HESAPLA


            //dynamic deger5 = Convert.ToDecimal(Convert.ToDouble(((deger4 * 15) / 100) + ((deger4 * 759) / 100000)).ToString("#.##"));

            var hesapla = Convert.ToDouble((deger4 * 15) / 100) + Convert.ToDouble((deger4 * 759) / 100000);
            var deger5 = Math.Round(hesapla, 2);
            ViewBag.dgr5 = deger5;

            //NET ÖDENECEK HESAPLA
            var deger6 = Convert.ToDouble(deger4) - deger5;
            ViewBag.dgr6 = deger6;

            //KİŞİ BAŞINA ÖDENECEK MİKTAR
            var hesapla1 = Convert.ToDouble(deger6 / 3);
            var deger7 = Math.Round(hesapla1, 2);
            ViewBag.dgr7 = deger7;
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }

    }
}