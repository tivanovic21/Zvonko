using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseLayer {
    public partial class ZvonkoModel : DbContext {
        public ZvonkoModel()
            : base("name=ZvonkoModel1") {
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
                .HasOptional(e => e.Recording)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<Event>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.day_of_the_week)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Recording>()
                .Property(e => e.description)
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
