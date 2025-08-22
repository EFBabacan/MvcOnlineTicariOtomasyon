using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        //prop yazıp tab yazınca otomatik geliyor 
        // ürün cari personel  
        [Key] 
        public  int  SatisId { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        // İlişkiler için gerekli olan ID alanları
        public int UrunId { get; set; }
        public int PersonelId { get; set; }
        public int CariId { get; set; }
        // Navigation Properties (İlişkili tablolara erişim için)
        public virtual Urun Urun { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Cariler Cariler { get; set; }
    }
}