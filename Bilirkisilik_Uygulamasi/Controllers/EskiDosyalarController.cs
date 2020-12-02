using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bilirkisilik_Uygulamasi.Models.Entity;

namespace Bilirkisilik_Uygulamasi.Controllers
{
    public class EskiDosyalarController : Controller
    {
        // GET: EskiDosyalar
        DBBILIRKISIEntities1 db = new DBBILIRKISIEntities1();
        [Authorize]
        public ActionResult Index(string t)
        {
            return View(db.TBL_BILIRKISILIK.Where(x => x.DOSYANO.StartsWith(t) || t == null && x.UCRETDURUM == false).ToList());
        }
    }
}