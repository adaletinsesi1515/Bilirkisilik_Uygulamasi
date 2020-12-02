using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilirkisilik_Uygulamasi.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class BilirkisiDosyaController : Controller
    {
        
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();

        // GET: BilirkisiDosya
        [Authorize]
        public ActionResult Index(string t)
        {
            List<TBL_BILIRKISILIK> listemp = db.TBL_BILIRKISILIK.Where(x=>x.DOSYADURUMU==true).ToList();
            return View(db.TBL_BILIRKISILIK.Where(x => x.DOSYANO.StartsWith(t) || t == null && x.DOSYADURUMU==true).OrderBy(x => x.GELISTARIHI).ToList());


        }

        [HttpGet]
        public ActionResult DosyaEkle()
        {
            
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
            return View();
        }

        [HttpPost]
        public ActionResult DosyaEkle(TBL_BILIRKISILIK b)
        {
            var birim = db.TBL_BIRIMLER.Where(k => k.ID == b.TBL_BIRIMLER.ID).FirstOrDefault();
            var raptur = db.TBL_RAPORTURU.Where(y => y.ID == b.TBL_RAPORTURU.ID).FirstOrDefault();
            b.TBL_BIRIMLER= birim;
            b.TBL_RAPORTURU= raptur;

            db.TBL_BILIRKISILIK.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            var bilirkisi= db.TBL_BILIRKISILER.Where(k => k.ID == b.TBL_BILIRKISILER.ID).FirstOrDefault();

            degerler.BIRIM_ID= birimler.ID;
            degerler.RAPORTURU_ID= raportur.ID;
            degerler.BILIRKISI_ID= bilirkisi.ID;
            degerler.NOTLAR = b.NOTLAR;


            if (degerler.UCRET>0)
            {
                degerler.DOSYADURUMU = false;
                degerler.DURUM = true; 
            }
            else
            {
                degerler.DOSYADURUMU = true;
                degerler.DURUM = false;

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

       
    }
}
