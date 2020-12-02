using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilirkisilik_Uygulamasi.Models.Entity;


namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class RaporTurleriController : Controller
    {
        // GET: RaporTurleri
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();
        [Authorize]
        public ActionResult Index()
        {
            var listeleme = db.TBL_RAPORTURU.Where(x => x.DURUM == true).ToList();
            return View(listeleme);
        }

        [HttpGet]
        public ActionResult RaporTuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RaporTuruEkle(TBL_RAPORTURU b)
        {
            if (!ModelState.IsValid)
            {
                //Şartı sağlamadıysam
                return View("RaporTuruEkle");
            }
            db.TBL_RAPORTURU.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult RaporTuruPasifEt(TBL_RAPORTURU b)
        {
            var pasif = db.TBL_RAPORTURU.Find(b.ID);
            pasif.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult RaporTuruBilgileriGetir(int id)
        {
            var deger2 = db.TBL_RAPORTURU.Find(id);
            return View("RaporTuruBilgileriGetir", deger2);
        }

        public ActionResult RaporTuruGuncelle(TBL_RAPORTURU b)
        {
            var degerler = db.TBL_RAPORTURU.Find(b.ID);
            degerler.RAPORTURU = b.RAPORTURU;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}