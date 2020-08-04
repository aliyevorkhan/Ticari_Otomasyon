using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var departmanlar = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            d.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dprtmn = c.Departmans.Find(id);
            dprtmn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dprtmn = c.Departmans.Find(id);
            return View("DepartmanGetir", dprtmn);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dprtmn = c.Departmans.Find(d.DepartmanID);

            dprtmn.DepartmanAd = d.DepartmanAd;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var personeller = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var dprtmn = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departman = dprtmn;
            return View(personeller);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var satislar = c.SatisHarakets.Where(x => x.PersonelID == id).ToList();
            var prsnl = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personel = prsnl;
            return View(satislar);
        }
        public ActionResult DepartmanListesi()
        {
            var departmanlar = c.Departmans.ToList();
            return View(departmanlar);
        }
    }
}