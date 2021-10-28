using Microsoft.EntityFrameworkCore;
using PrototypePrjEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePrjEntityFramework.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base (opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasKey(m => new { m.RistoranteId, m.PiattoId });


            modelBuilder.Entity<Preavvisi>().HasKey(pre => new { pre.PiattoId, pre.AllergeneId });
            modelBuilder.Entity<Procedimenti>().HasKey(pro => new { pro.PiattoId, pro.IngredienteId });
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<Ristorante> Ristoranti { get; set; }
        public DbSet<Preavvisi> Preavvisi { get; set; }
        public DbSet<Procedimenti> Procedimenti { get; set; }
        public DbSet<Allergene> Allergeni { get; set; }
        public DbSet<Ingrediente> Ingredienti { get; set; }
    }
}
