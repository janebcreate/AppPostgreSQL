using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AppPostgreSQL
{
    public partial class testdb3Context : DbContext
    {
        public testdb3Context()
        {
        }
        public testdb3Context(DbContextOptions<testdb3Context> options)
        : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost; " +
                "Port=5432; Database=testdb3; " +
                "Username=postgres; " +
                "Password=1488");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("firstname");
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Createdat)
                .HasColumnType("date")
                .HasColumnName("createdat");
                entity.Property(e => e.Customerid).HasColumnName("customerid");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Productcount)
                .HasColumnName("productcount")
                .HasDefaultValueSql("1");
                entity.Property(e => e.Productid).HasColumnName("productid");
                entity.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("orders_customerid_fkey");
                entity.HasOne(d => d.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("orders_productid_fkey");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Company)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("company");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Productcount)
                .HasColumnName("productcount")
                .HasDefaultValueSql("0");
                entity.Property(e => e.Productname)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("productname");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModuleBuilder modelBuilder);
    }
}
