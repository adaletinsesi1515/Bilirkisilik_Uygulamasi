using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilirkisilik_Uygulamasi.Models.Entity;


namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class BilirkisilerController : Controller
    {
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();

        // GET: Bilirkisiler
        [Authorize]
        public ActionResult Index()
        {
            var listeleme = db.TBL_BILIRKISILER.Where(x=>x.DURUM == true).ToList();
            return View(listeleme);
        }

        [HttpGet]
        public ActionResult BilirkisiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BilirkisiEkle(TBL_BILIRKISILER b)
        {
            if (!ModelState.IsValid)
            {
                //Şartı sağlamadıysam
                return View("BilirkisiEkle");
            }
            db.TBL_BILIRKISILER.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult BilirkisiPasifEt(TBL_BILIRKISILER b)
        {
            var pasif = db.TBL_BILIRKISILER.Find(b.ID);
            pasif.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult BilirkisiBilgileriGetir(int id)
        {
            var deger2 = db.TBL_BILIRKISILER.Find(id);
            return View("BilirkisiBilgileriGetir", deger2);
        }

        public ActionResult BilirkisiGuncelle(TBL_BILIRKISILER b)
        {
            var degerler = db.TBL_BILIRKISILER.Find(b.ID);
            degerler.ADSOYAD = b.ADSOYAD;
            degerler.SICIL = b.SICIL;
            degerler.EMAIL = b.EMAIL;
            degerler.KULLANICIADI = b.KULLANICIADI;
            degerler.SIFRE = b.SIFRE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}