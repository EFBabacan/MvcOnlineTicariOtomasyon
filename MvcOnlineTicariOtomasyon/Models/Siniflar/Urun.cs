using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column (TypeName ="Varchar" )]
        [StringLength (30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        //Kategoriler ile olan iliskisi
        // Bu 'virtual' kelimesi Lazy Loading'i aktif eder.
        // Lazy Loading kullanışlı olsa da, özellikle listeleme sayfalarında
        // performans sorunlarına yol açabilir (N+1 problemi).
        // Çünkü her bir satır için ayrı bir veritabanı sorgusu gönderir.

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}