using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]//üzerinde bulunduğu değişkeni birincil anahtar olarak kabul etmesini sağlar.
        public int KategoriId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }

        //ICollection: içindeki eleman sayısı bilinen ve eleman ekleme, çıkarma, temizleme gibi temel işlemlere izin veren bir koleksiyon
        //Urunler ile iliskisi 
        public ICollection<Urun> Uruns { get; set; }

    }
}