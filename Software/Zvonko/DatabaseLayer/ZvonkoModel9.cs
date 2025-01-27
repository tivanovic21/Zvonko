using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseLayer {
    public partial class ZvonkoModel9 : DbContext {
        public ZvonkoModel9()
            : base("name=ZvonkoModel9") {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Recording> Recordings { get; set; }
        public virtual DbSet<TypeOfEvent> TypeOfEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
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
                .HasMany(e => e.Recordings)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.AccountId);

            modelBuilder.Entity<Event>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.storedFile)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.timeCreated)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfEvent>()
                .Property(e => e.typeName)
                .IsUnicode(false);
        }
    }
}
