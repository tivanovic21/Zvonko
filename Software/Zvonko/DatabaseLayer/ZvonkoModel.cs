using EntitiesLayer;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseLayer
{
    public partial class ZvonkoModel : DbContext
    {
        public ZvonkoModel()
            : base("name=ZvonkoConnectionString")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Recording> Recordings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.schoolName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.macAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.Recording)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<Recording>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.timeCreated)
                .IsUnicode(false);
        }
    }
}
