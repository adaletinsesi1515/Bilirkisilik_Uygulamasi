using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilirkisilik_Uygulamasi.Models.Entity;


namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class OdeneceklerController : Controller
    {
        // GET: Odenecekler
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();
        [Authorize]
        public ActionResult Index(string t)
        {
            return View(db.TBL_BILIRKISILIK.Where(x => x.DOSYANO.StartsWith(t) || t == null && x.UCRETDURUM==true).ToList());
        }

        public ActionResult OdemePasifEt(TBL_BILIRKISILIK b)
        {
            var pasif = db.TBL_BILIRKISILIK.Find(b.ID);
            pasif.UCRETDURUM= false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}