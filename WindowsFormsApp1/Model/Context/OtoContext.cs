using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model.Entity;

namespace WindowsFormsApp1.Model.Context
{
    public class OtoContext:DbContext
    {
        public OtoContext():base("OtoContext")
        {
           Database.SetInitializer<OtoContext>(new OtoDBInitializer<OtoContext>());
        }
        public DbSet<UrunDetay> UrunDetay { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<Cari> Cari { get; set; }
        public DbSet<FaturaFis> FaturaFis { get; set; }
        public DbSet<FaturaTip> FaturaTip { get; set; }
        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Servis> Servis { get; set; }
        public DbSet<Durum> Durum { get; set; }
        public DbSet<Arac> Arac { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<AracModel> AracModel { get; set; }
        public DbSet<Vites> Vites { get; set; }
        public DbSet<Yakit> Yakit { get; set; }
    }
}
