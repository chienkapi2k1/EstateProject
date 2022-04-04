using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EstateProject.Models
{
    public partial class EstateDbContext : DbContext
    {
        public EstateDbContext()
            : base("name=EstateDBContext")
        {
        }

        public virtual DbSet<building> building { get; set; }
        public virtual DbSet<building_images> building_images { get; set; }
        public virtual DbSet<contacts> contacts { get; set; }
        public virtual DbSet<rentarea> rentarea { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<building>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.ward)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.district)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.structure)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.direction)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.levels)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.rentpricedescription)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.servicefee)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.carfee)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.motofee)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.overtimefee)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.waterfee)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.electricityfee)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.deposit)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.payment)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.renttime)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.decorationtime)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.brokeragetee)
                .HasPrecision(13, 2);

            modelBuilder.Entity<building>()
                .Property(e => e.typess)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.linkofbuilding)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.map)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.createdby)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .Property(e => e.modifiedby)
                .IsUnicode(false);

            modelBuilder.Entity<building>()
                .HasMany(e => e.building_images)
                .WithOptional(e => e.building)
                .HasForeignKey(e => e.building_id);

            modelBuilder.Entity<building_images>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<contacts>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<contacts>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<contacts>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<contacts>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<contacts>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<contacts>()
                .Property(e => e.messages)
                .IsUnicode(false);

            modelBuilder.Entity<rentarea>()
                .Property(e => e.createdby)
                .IsUnicode(false);

            modelBuilder.Entity<rentarea>()
                .Property(e => e.modifiedby)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.createdby)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.modifiedby)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.building)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.contacts)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.user_id);
        }
    }
}
