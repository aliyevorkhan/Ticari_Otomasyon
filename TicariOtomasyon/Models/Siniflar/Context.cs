using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaKalem> FaturaKalems{ get; set; }
        public DbSet<Kategori> Kategoris{ get; set; }
        public DbSet<Personel> Personels{ get; set; }
        public DbSet<SatisHaraket> SatisHarakets{ get; set; }
        public DbSet<Urun> Uruns{ get; set; }
    }
}