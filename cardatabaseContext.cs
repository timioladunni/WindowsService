using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WindowService2
{
    public partial class cardatabaseContext : DbContext
    {
        public cardatabaseContext()
        {
        }

        public cardatabaseContext(DbContextOptions<cardatabaseContext> options)
            : base(options)
        {
        }

        public  DbSet<CarValueApi> CarValueApis { get; set; }
        public  DbSet<UserMaster> UserMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=COSMOS\\SQLEXPRESS; Initial Catalog=cardatabase; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CarValueApi>(entity =>
            {
                entity.ToTable("carValueAPI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarCurrentPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserMast__1788CCACCF95C3AB");

                entity.ToTable("UserMaster");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.UserEmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserEmailID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoles)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
