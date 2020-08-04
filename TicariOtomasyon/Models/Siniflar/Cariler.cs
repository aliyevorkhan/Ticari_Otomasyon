using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(15)]
        public string CariSehir { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }

    }
}