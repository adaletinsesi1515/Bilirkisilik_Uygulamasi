using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilirkisilik_Uygulamasi.Models.Entity;

namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class BirimlerController : Controller
    {
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();

        // GET: Birimler
        [Authorize]
        public ActionResult Index()
        {
            var listeleme = db.TBL_BIRIMLER.Where(x => x.DURUM == true).ToList();
            return View(listeleme);
        }

        [HttpGet]
        public ActionResult BirimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BirimEkle(TBL_BIRIMLER b)
        {
            if (!ModelState.IsValid)
            {
                //Şartı sağlamadıysam
                return View("BirimEkle");
            }
            db.TBL_BIRIMLER.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult BirimPasifEt(TBL_BIRIMLER b)
        {
            var pasif = db.TBL_BIRIMLER.Find(b.ID);
            pasif.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult BirimBilgileriGetir(int id)
        {
            var deger2 = db.TBL_BIRIMLER.Find(id);
            return View("BirimBilgileriGetir", deger2);
        }

        public ActionResult BirimGuncelle(TBL_BIRIMLER b)
        {
            var degerler = db.TBL_BIRIMLER.Find(b.ID);
            degerler.BIRIMAD = b.BIRIMAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}