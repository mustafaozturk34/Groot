﻿//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Groot.DB.Entities;

//#nullable disable

//namespace Groot.DB.Entities.DbContext
//{
//    public partial class GrootContext : DbContext
//    {
//        public GrootContext()
//        {
//        }

//        public GrootContext(DbContextOptions<GrootContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Category> Category { get; set; }
//        public virtual DbSet<Product> Product { get; set; }
//        public virtual DbSet<User> User { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=Groot;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

//            modelBuilder.Entity<Category>(entity =>
//            {
//                entity.Property(e => e.DisplayName)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Idate)
//                    .HasColumnType("datetime")
//                    .HasColumnName("IDate")
//                    .HasDefaultValueSql("(getdate())");

//                entity.Property(e => e.Iuser).HasColumnName("IUser");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Udate)
//                    .HasColumnType("datetime")
//                    .HasColumnName("UDate");

//                entity.Property(e => e.Uuser).HasColumnName("UUser");

//                entity.HasOne(d => d.IuserNavigation)
//                    .WithMany(p => p.Category)
//                    .HasForeignKey(d => d.Iuser)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Category_User");
//            });

//            modelBuilder.Entity<Product>(entity =>
//            {
//                entity.HasNoKey();

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.DisplayName)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Id).ValueGeneratedOnAdd();

//                entity.Property(e => e.Idate)
//                    .HasColumnType("datetime")
//                    .HasColumnName("IDate")
//                    .HasDefaultValueSql("(getdate())");

//                entity.Property(e => e.Iuser).HasColumnName("IUser");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

//                entity.Property(e => e.Udate)
//                    .HasColumnType("datetime")
//                    .HasColumnName("UDate")
//                    .HasDefaultValueSql("(getdate())");

//                entity.Property(e => e.Uuser).HasColumnName("UUSer");

//                entity.HasOne(d => d.Category)
//                    .WithMany()
//                    .HasForeignKey(d => d.CategoryId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Product_Category");

//                entity.HasOne(d => d.IuserNavigation)
//                    .WithMany()
//                    .HasForeignKey(d => d.Iuser)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Product_User");
//            });

//            modelBuilder.Entity<User>(entity =>
//            {
//                entity.Property(e => e.Email)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Idatetime)
//                    .HasColumnType("datetime")
//                    .HasColumnName("IDatetime")
//                    .HasDefaultValueSql("(getdate())");

//                entity.Property(e => e.Iuser).HasColumnName("IUser");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Password)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.UdateTime)
//                    .HasColumnType("datetime")
//                    .HasColumnName("UDateTime")
//                    .HasDefaultValueSql("(getdate())");

//                entity.Property(e => e.UserName)
//                    .IsRequired()
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Uuser).HasColumnName("UUser");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
