using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cariler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(cariler);
        }


        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler c_)
        {
            c_.Durum = true;
            c.Carilers.Add(c_);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler c_)
        {
            var cari = c.Carilers.Find(c_.CariID);

            cari.CariAd = c_.CariAd;
            cari.CariSoyad = c_.CariSoyad;
            cari.CariSehir = c_.CariSehir;
            cari.CariMail = c_.CariMail;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGecmisi(int id)
        {
            var satislar = c.SatisHarakets.Where(x => x.CariID == id).ToList();
            var cr = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;

            return View(satislar);
        }

        public ActionResult CariListesi()
        {
            var cariler = c.Carilers.ToList();
            return View(cariler);
        }
    }
}