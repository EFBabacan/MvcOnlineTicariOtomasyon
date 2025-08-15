using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }


        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        //Fatura Kalem ile olan iliski 
        //ICollection: içindeki eleman sayısı bilinen ve eleman ekleme, çıkarma, temizleme gibi temel işlemlere izin veren bir koleksiyon"
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}