using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VJShop.Areas.Admin.Models
{
    public partial class vjshop_dtb : DbContext
    {
        public vjshop_dtb()
            : base("name=vjshop_dtb")
        {
        }

        public virtual DbSet<DMMAYANH> DMMAYANHs { get; set; }
        public virtual DbSet<MAYANH> MAYANHs { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DMMAYANH>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<MAYANH>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);
        }
    }
}
