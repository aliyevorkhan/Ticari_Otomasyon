using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var satislar = c.SatisHarakets.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd +" "+x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAd +" "+x.PersonelSoyad,
                                                Value = x.PersonelID.ToString()
                                            }).ToList();
            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;

            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(SatisHaraket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarakets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            var satis = c.SatisHarakets.Find(id);

            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();
            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;


            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHaraket s)
        {
            var sts = c.SatisHarakets.Find(s.SatisID);

            sts.CariID = s.CariID;
            sts.PersonelID = s.PersonelID;
            sts.UrunID = s.UrunID ;
            sts.Adet = s.Adet;
            sts.Fiyat = s.Fiyat;
            sts.ToplamTutar = s.ToplamTutar;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var satis = c.SatisHarakets.Where(x => x.SatisID == id).ToList();
            return View(satis);
        }

        public ActionResult SatisListesi()
        {
            var satislar = c.SatisHarakets.ToList();
            return View(satislar);
        }
    }
}