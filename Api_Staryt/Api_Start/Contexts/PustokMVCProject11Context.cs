using System;
using System.Collections.Generic;
using Api_Start.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_Start.Contexts
{
    public partial class PustokMVCProject11Context : DbContext
    {
        public PustokMVCProject11Context()
        {
        }

        public PustokMVCProject11Context(DbContextOptions<PustokMVCProject11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<Slider> Sliders { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<TagBlog> TagBlogs { get; set; } = null!;
        public virtual DbSet<TagProduct> TagProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:MSSQL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Name).HasMaxLength(32);

                entity.Property(e => e.Surname).HasMaxLength(32);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.HasIndex(e => e.AuthorId, "IX_Blog_AuthorId");

                entity.Property(e => e.Description).HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(64);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AuthorId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(16);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryId");

                entity.Property(e => e.About).HasMaxLength(128);

                entity.Property(e => e.CostPrice).HasColumnType("smallmoney");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.ProductCode).HasMaxLength(16);

                entity.Property(e => e.SellPrice).HasColumnType("smallmoney");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_ProductImages_ProductId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.Property(e => e.ImageUrl).HasMaxLength(256);

                entity.Property(e => e.Text).HasMaxLength(64);

                entity.Property(e => e.Title).HasMaxLength(64);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Title).HasMaxLength(64);
            });

            modelBuilder.Entity<TagBlog>(entity =>
            {
                entity.ToTable("TagBlog");

                entity.HasIndex(e => e.BlogId, "IX_TagBlog_BlogId");

                entity.HasIndex(e => e.TagId, "IX_TagBlog_TagId");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.TagBlogs)
                    .HasForeignKey(d => d.BlogId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagBlogs)
                    .HasForeignKey(d => d.TagId);
            });

            modelBuilder.Entity<TagProduct>(entity =>
            {
                entity.ToTable("TagProduct");

                entity.HasIndex(e => e.ProductId, "IX_TagProduct_ProductId");

                entity.HasIndex(e => e.TagId, "IX_TagProduct_TagId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TagProducts)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagProducts)
                    .HasForeignKey(d => d.TagId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
