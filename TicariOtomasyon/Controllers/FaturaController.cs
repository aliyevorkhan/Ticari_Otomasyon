using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var faturalar = c.Faturas.ToList();
            return View(faturalar);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = c.Faturas.Find(f.FaturaID);

            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.Tarih = f.Tarih;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.Saat= f.Saat;
            fatura.TeslimAlan= f.TeslimAlan;
            fatura.TeslimEden= f.TeslimEden;
            fatura.Toplam= f.Toplam;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaListesi()
        {
            var faturalar = c.Faturas.ToList();
            return View(faturalar);
        }

        public ActionResult FaturaDetay(int id)
        {
            var kalemler = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            
            return View(kalemler);

        }

        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}