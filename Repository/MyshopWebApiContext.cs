using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class MyshopWebApiContext : DbContext
{
    public MyshopWebApiContext()
    {
    }

    public MyshopWebApiContext(DbContextOptions<MyshopWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=MYSHOP_webApi;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("CATEGORIES");

            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CATEGORY_NAME");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("ORDERS");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("ORDER_DATE");
            entity.Property(e => e.OrderSum).HasColumnName("ORDER_SUM");
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERS_USERS");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("ORDER_ITEM");

            entity.Property(e => e.OrderItemId).HasColumnName("ORDER_ITEM_ID");
            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Quentity).HasColumnName("QUENTITY");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_ITEM_ORDERS");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_ITEM_PRODUCTS");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(70)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IMAGE");
            entity.Property(e => e.Price).HasColumnName("PRICE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRODUCT_NAME");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTS_PRODUCTS");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("RATING");

            entity.Property(e => e.RatingId).HasColumnName("RATING_ID");
            entity.Property(e => e.Host)
                .HasMaxLength(50)
                .HasColumnName("HOST");
            entity.Property(e => e.Method)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("METHOD");
            entity.Property(e => e.Path)
                .HasMaxLength(50)
                .HasColumnName("PATH");
            entity.Property(e => e.RecordDate)
                .HasColumnType("datetime")
                .HasColumnName("Record_Date");
            entity.Property(e => e.Referer)
                .HasMaxLength(100)
                .HasColumnName("REFERER");
            entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
