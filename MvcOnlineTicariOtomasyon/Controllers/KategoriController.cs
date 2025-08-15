using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        //var butun değişkenlerin değerini alır
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        //form viwev yuklendiği zaman
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        //etkileşim kurulduğu zaman (buton vesaire)
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k); //viwe tarafına gondereceği parametrelin tutulduğu yer
            c.SaveChanges(); //Değişkenleri kaydet
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int? id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir" , kategori);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        { 
            var ktg = c.Kategoris.Find(k.KategoriId);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}