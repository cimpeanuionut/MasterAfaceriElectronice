using Microsoft.EntityFrameworkCore;
using ProiectMaster.Models.Entites;

namespace ProiectMaster.DataAccess
{
    public partial class MagazinVirtualContext : DbContext
    {
        public MagazinVirtualContext(DbContextOptions<MagazinVirtualContext> options)
            : base(options)
        {
        }
      
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProductsSpecialTag> ProductsSpecialTags { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SpecialTag> SpecialTags { get; set; }
        public virtual DbSet<User> Users { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");           

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CommentTitle)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Feedback_Users");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrdersProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId });

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrdersProducts_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersProducts_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ImagePath).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Price).HasColumnType("numeric(20, 2)");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductTypes");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ProductsSpecialTag>(entity =>
            {
                entity.HasKey(e => new { e.SpecialTagId, e.ProductId })
                    .HasName("PK_ProductSpecialTag");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsSpecialTags)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductsSpecialTags_Products");

                entity.HasOne(d => d.SpecialTag)
                    .WithMany(p => p.ProductsSpecialTags)
                    .HasForeignKey(d => d.SpecialTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsSpecialTags_SpecialTags");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SpecialTag>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UK_UserName")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IsActiv)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
