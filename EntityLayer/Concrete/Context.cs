using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL("server=localhost;username=root;password=sonel.1234;database=eticaret;port=3306");
        }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Referanslar> Referanslars { get; set; }
        public DbSet<AdminMesaj> AdminMesajs { get; set; }
        public DbSet<UserMesaj> UserMesajs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Urun> Uruns { get; set; }
    }
}
