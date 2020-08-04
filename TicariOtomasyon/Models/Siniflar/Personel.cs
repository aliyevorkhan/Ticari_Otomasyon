using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelAd{ get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelSoyad{ get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string PersonelGorsel{ get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }
    }
}