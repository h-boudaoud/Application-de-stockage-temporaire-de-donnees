namespace DataGridSample.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataGridSample.Models;

    public partial class EFContexte : DbContext
    {
        public EFContexte()
            : base("name=EFContexte")
        {
            Database.SetInitializer<EFContexte>(new Initializor());
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAdress> UserAdresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Genre);

            modelBuilder.Entity<User>()
                .Property(e => e.Profession)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdress>()
                .Property(e => e.Voie)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdress>()
                .Property(e => e.CodePostal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserAdress>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdress>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserAdress)
                .HasForeignKey(e => e.Adress_Id);
        }
    }
}
