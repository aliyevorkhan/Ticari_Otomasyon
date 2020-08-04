using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var personeller = c.Personels.Where(x => x.Durum == true).ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanlar = (from x in c.Departmans.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.DepartmanAd,
                                                    Value = x.DepartmanID.ToString()
                                                }).ToList();
            ViewBag.dprtmn = departmanlar;

            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            p.Durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = c.Personels.Find(id);
            personel.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departmanlar = (from x in c.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanID.ToString()
                                                 }).ToList();
            ViewBag.dprtmn = departmanlar;

            var personel = c.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var personel = c.Personels.Find(p.PersonelID);

            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.PersonelGorsel = p.PersonelGorsel;
            personel.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListesi()
        {
            var personeller = c.Personels.ToList();
            return View(personeller);
        }

    }

}