using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using Bilirkisilik_Uygulamasi.Models.Entity;
using Rotativa;


namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class UcretYazilmamisDefaultController : Controller
    {
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();

        // GET: UcretYazilmamisDefault
        [Authorize]
        public ActionResult Index(string t)
        {
            return View(db.TBL_BILIRKISILIK.Where(x => x.DOSYANO.StartsWith(t) || t == null && x.DOSYADURUMU == false && x.DURUM == true).OrderBy(x => x.TESLIMTARIHI).ToList());
        }

        public ActionResult DosyaDetayGetir(int id)
        {

            var deger = db.TBL_BILIRKISILIK.Find(id);

            //Birimler tablosundan Birim adını çekme yöntemi

            List<SelectListItem> deger1 = (from i in db.TBL_BIRIMLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.BIRIMAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            //Rapor Türü tablosundan rapor türlerini çekme yöntemi

            List<SelectListItem> deger2 = (from i in db.TBL_RAPORTURU.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.RAPORTURU,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            //Bilirkişi  tablosundan bilirkişileri çekme yöntemi

            List<SelectListItem> deger3 = (from i in db.TBL_BILIRKISILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ADSOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            return View("DosyaDetayGetir", deger);
        }

        public ActionResult DosyaGuncelle(TBL_BILIRKISILIK b)
        {
            var degerler = db.TBL_BILIRKISILIK.Find(b.ID);


            degerler.DOSYANO = b.DOSYANO;
            degerler.GELISTARIHI = b.GELISTARIHI;
            degerler.TESLIMTARIHI = b.TESLIMTARIHI;
            degerler.UCRET = b.UCRET;

            var birimler = db.TBL_BIRIMLER.Where(k => k.ID == b.TBL_BIRIMLER.ID).FirstOrDefault();
            var raportur = db.TBL_RAPORTURU.Where(k => k.ID == b.TBL_RAPORTURU.ID).FirstOrDefault();
            var bilirkisi = db.TBL_BILIRKISILER.Where(k => k.ID == b.TBL_BILIRKISILER.ID).FirstOrDefault();

            degerler.BIRIM_ID = birimler.ID;
            degerler.RAPORTURU_ID = raportur.ID;
            degerler.BILIRKISI_ID = bilirkisi.ID;


            if (degerler.UCRET > 0)
            {
                degerler.DOSYADURUMU = false;
                degerler.DURUM = false;
                degerler.UCRETDURUM = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotDuzenleDetayGetir(int id)
        {
            var deger = db.TBL_BILIRKISILIK.Find(id);

            //Birimler tablosundan Birim adını çekme yöntemi

            List<SelectListItem> deger1 = (from i in db.TBL_BIRIMLER.ToList()
                select new SelectListItem
                {
                    Text = i.BIRIMAD,
                    Value = i.ID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;

            //Rapor Türü tablosundan rapor türlerini çekme yöntemi

            List<SelectListItem> deger2 = (from i in db.TBL_RAPORTURU.ToList()
                select new SelectListItem
                {
                    Text = i.RAPORTURU,
                    Value = i.ID.ToString()
                }).ToList();
            ViewBag.dgr2 = deger2;

            //Bilirkişi  tablosundan bilirkişileri çekme yöntemi

            List<SelectListItem> deger3 = (from i in db.TBL_BILIRKISILER.ToList()
                select new SelectListItem
                {
                    Text = i.ADSOYAD,
                    Value = i.ID.ToString()
                }).ToList();
            ViewBag.dgr3 = deger3;

            return View("NotDuzenleDetayGetir", deger);
        }

        public ActionResult NotDosyaGuncelle(TBL_BILIRKISILIK b)
        {
            var degerler = db.TBL_BILIRKISILIK.Find(b.ID);

            degerler.NOTLAR = b.NOTLAR;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult GetAll(string t)
        {
            
            return View(db.TBL_BILIRKISILIK.Where(x => x.DOSYANO.StartsWith(t) || t == null && x.DOSYADURUMU == false && x.DURUM == true).OrderBy(x=>x.TESLIMTARIHI).ToList());
        }

        public ActionResult Yazdir1()
        {
            var q = new ActionAsPdf("GetAll");
            return q;
        }
    }
}