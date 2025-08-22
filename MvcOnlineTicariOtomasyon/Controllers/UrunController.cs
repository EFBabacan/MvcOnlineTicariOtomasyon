using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using MvcOnlineTicariOtomasyon.Controllers;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // Veritabanı bağlantısı için Context sınıfından bir nesne oluşturuluyor.
        // Bu 'c' nesnesi üzerinden veritabanı işlemlerini (CRUD) yapacağız.
        Context c = new Context();

        // GET: Urun
        // Ürünleri listelemek için kullanılan ana metot.
        public ActionResult Index()
        {
            // Veritabanındaki 'Uruns' tablosuna sorgu gönderiliyor.
            // Where(x => x.Durum == true) koşulu ile sadece 'Durum' sütunu true olan,
            // yani aktif olan ürünler seçiliyor.
            // .ToList() ile sorgu çalıştırılıp sonuçlar bir listeye çevriliyor.
            var Urunler = c.Uruns.Where(x => x.Durum == true).ToList();

            // Elde edilen 'Urunler' listesi, 'Index.cshtml' adlı View'a model olarak gönderiliyor.
            return View(Urunler);
        }

        // Bu attribute, metodun sadece HTTP GET isteğiyle (yani sayfaya ilk kez girildiğinde)
        // çalışacağını belirtir.
        [HttpGet]
        public ActionResult YeniUrun()
        {
            // Kategorileri bir liste halinde veritabanından çekiyoruz.
            List<SelectListItem> deger1 =
                (from x in c.Kategoris.ToList()
                 select new SelectListItem
                 {
                     // Dropdown menünün görünen metni (örn: "Beyaz Eşya")
                     Text = x.KategoriAd,
                     // Dropdown menüsünün arkaplandaki değeri (örn: "1")
                     Value = x.KategoriId.ToString()
                 }).ToList();
            ViewBag.dgr1 = deger1;

            // Hazırlanan kategori listesi, View'da kullanılmak üzere ViewBag'e atanabilir.
            // Örnek: ViewBag.Kategoriler = deger1;

            // 'YeniUrun.cshtml' adlı View'ı kullanıcıya gösterir.
            return View();
        }

        // Bu attribute, metodun sadece HTTP POST isteğiyle (yani formdaki butona basıldığında)
        // çalışacağını belirtir.
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            // View'daki formdan gelen ve otomatik olarak 'Urun' nesnesine ('p')
            // dönüştürülen veriyi veritabanına eklenmek üzere işaretler.
            c.Uruns.Add(p);

            // Yapılan değişiklikleri veritabanına kalıcı olarak kaydeder (INSERT komutunu çalıştırır).
            c.SaveChanges();

            // İşlem bittikten sonra kullanıcıyı ürünlerin listelendiği 'Index' sayfasına yönlendirir.
            return RedirectToAction("Index");
        }

        // Bu metot, bir ürünü silmek yerine pasif hale getirmek için kullanılır.
        // Parametre olarak pasif hale getirilecek ürünün 'id'sini alır.
        public ActionResult UrunSil(int id)
        {
            // Veritabanında gönderilen 'id'ye sahip ürünü bulur.
            var deger = c.Uruns.Find(id);

            // Bulunan ürünün 'Durum' özelliğini 'false' olarak günceller.
            deger.Durum = false;

            // Yapılan değişikliği veritabanına kaydeder (UPDATE komutunu çalıştırır).
            c.SaveChanges();

            // İşlem bittikten sonra kullanıcıyı 'Index' sayfasına geri yönlendirir.
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id) 
        {
            

            List<SelectListItem> deger1 =
                (from x in c.Kategoris.ToList()
                 select new SelectListItem
                 {
                     Text = x.KategoriAd,

                     Value = x.KategoriId.ToString()
                 }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {

            var urn = c.Uruns.Find(p.UrunId);
            urn.UrunAd = p.UrunAd;
            urn.AlisFiyat = p.AlisFiyat;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Durum = p.Durum;
            urn.KategoriId = p.KategoriId;
            urn.Marka = p.Marka;
            urn.Stok = p.Stok;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}