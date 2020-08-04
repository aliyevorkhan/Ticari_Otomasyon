using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> kategoriler = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.ktgr  = kategoriler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            u.Durum = true;
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = c.Uruns.Find(id);
            urn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kategoriler = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.ktgr = kategoriler;

            var urn = c.Uruns.Find(id);
            return View("UrunGetir", urn);
        }

        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunID);

            urn.UrunAd = u.UrunAd;
            urn.Marka = u.Marka;
            urn.Stok = u.Stok;
            urn.AlisFiyat = u.AlisFiyat;
            urn.SatisFiyat = u.SatisFiyat;
            urn.Durum = true;
            urn.UrunGorsel = u.UrunGorsel;
            urn.KategoriID = u.KategoriID;

            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var urunler = c.Uruns.ToList();
            return View(urunler);
        }

    }

}