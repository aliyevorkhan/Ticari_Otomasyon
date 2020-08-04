using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }
        public int Miktar{ get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama{ get; set; }
        public decimal BirimFiyat{ get; set; }
        public decimal Tutar{ get; set; }
        public int FaturaID{ get; set; }
        public virtual Fatura Fatura{ get; set; }
    }
}