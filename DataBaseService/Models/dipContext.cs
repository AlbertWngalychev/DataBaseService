using Microsoft.EntityFrameworkCore;

namespace DataBaseService.Models
{
    public partial class dipContext : DbContext
    {
        public dipContext()
        {
        }

        public dipContext(DbContextOptions<dipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authentication> Authentications { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CharacteristicsModification> CharacteristicsModifications { get; set; } = null!;
        public virtual DbSet<Chatacteristic> Chatacteristics { get; set; } = null!;
        public virtual DbSet<ChatacteristicsValue> ChatacteristicsValues { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Cloth> Cloths { get; set; } = null!;
        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Mdification> Mdifications { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderElement> OrderElements { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<Price> Prices { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<ShopingCart> ShopingCarts { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<Value> Values { get; set; } = null!;
        public virtual DbSet<Сlothe> Сlothes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=dip;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentication>(entity =>
            {
                entity.ToTable("Authentication");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.HashedPass)
                    .HasMaxLength(255)
                    .HasColumnName("hashed_pass")
                    .IsFixedLength();

                entity.Property(e => e.Salt)
                    .HasMaxLength(1024)
                    .HasColumnName("salt")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CharacteristicsModification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacteristicsValueId).HasColumnName("characteristics_value_id");

                entity.Property(e => e.ModificationId).HasColumnName("modification_id");

                entity.HasOne(d => d.CharacteristicsValue)
                    .WithMany(p => p.CharacteristicsModifications)
                    .HasForeignKey(d => d.CharacteristicsValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacteristicsModifications_ChatacteristicsValue");

                entity.HasOne(d => d.Modification)
                    .WithMany(p => p.CharacteristicsModifications)
                    .HasForeignKey(d => d.ModificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacteristicsModifications_Mdification");
            });

            modelBuilder.Entity<Chatacteristic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ChatacteristicsValue>(entity =>
            {
                entity.ToTable("ChatacteristicsValue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacteristicsId).HasColumnName("characteristics_id");

                entity.Property(e => e.ValueId).HasColumnName("value_id");

                entity.HasOne(d => d.Characteristics)
                    .WithMany(p => p.ChatacteristicsValues)
                    .HasForeignKey(d => d.CharacteristicsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChatacteristicsValue_fk0");

                entity.HasOne(d => d.Value)
                    .WithMany(p => p.ChatacteristicsValues)
                    .HasForeignKey(d => d.ValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChatacteristicsValue_fk1");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.Id, "UQ__Client__3213E83E74BB8AD6")
                    .IsUnique();

                entity.HasIndex(e => e.Tel, "UQ__Client__7838F27273E569D2")
                    .IsUnique();

                entity.HasIndex(e => e.EMail, "UQ__Client__B58D51493AE0D7E6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthId).HasColumnName("auth_id");

                entity.Property(e => e.EMail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("e_mail");

                entity.Property(e => e.Fname)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tel");

                entity.HasOne(d => d.Auth)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AuthId)
                    .HasConstraintName("FK_Client_Authentication");
            });

            modelBuilder.Entity<Cloth>(entity =>
            {
                entity.ToTable("Cloth");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DeliveryAddress>(entity =>
            {
                entity.ToTable("DeliveryAddress");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Flat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("flat");

                entity.Property(e => e.House)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("house");

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("region");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DeliveryAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryAddress_Client");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClothId).HasColumnName("cloth_id");

                entity.Property(e => e.ClothesId).HasColumnName("clothes_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.HasOne(d => d.Cloth)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.ClothId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Material_fk1");

                entity.HasOne(d => d.Clothes)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.ClothesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Material_fk0");
            });

            modelBuilder.Entity<Mdification>(entity =>
            {
                entity.ToTable("Mdification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClothesId).HasColumnName("clothes_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PriceFactor)
                    .HasColumnType("decimal(1, 1)")
                    .HasColumnName("price_factor")
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.Clothes)
                    .WithMany(p => p.Mdifications)
                    .HasForeignKey(d => d.ClothesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mdification_fk0");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.DeliveryAddressId).HasColumnName("delivery_address_id");

                entity.Property(e => e.Promo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("promo");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.DeliveryAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_DeliveryAddress");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_fk1");
            });

            modelBuilder.Entity<OrderElement>(entity =>
            {
                entity.ToTable("OrderElement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.ModificationId).HasColumnName("modification_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.Modification)
                    .WithMany(p => p.OrderElements)
                    .HasForeignKey(d => d.ModificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderElement_Mdification");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderElements)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderElement_Order");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModificationId).HasColumnName("modification_id");

                entity.Property(e => e.Path)
                    .IsUnicode(false)
                    .HasColumnName("path");

                entity.Property(e => e.Priopity).HasColumnName("priopity");

                entity.HasOne(d => d.Modification)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.ModificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Mdification");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClothesId).HasColumnName("clothes_id");

                entity.Property(e => e.DataFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("data_from");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(2, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.FullPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("full_price");

                entity.HasOne(d => d.Clothes)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ClothesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Price_fk0");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Advantages)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("advantages");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Limitations)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("limitations");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.ModificatonId).HasColumnName("modificaton_id");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Review_Client");

                entity.HasOne(d => d.Modificaton)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ModificatonId)
                    .HasConstraintName("FK_Review_Mdification");
            });

            modelBuilder.Entity<ShopingCart>(entity =>
            {
                entity.ToTable("ShopingCart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateAdd)
                    .HasColumnType("datetime")
                    .HasColumnName("date_add");

                entity.Property(e => e.ModificationId).HasColumnName("modification_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ShopingCarts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopingCart_Client");

                entity.HasOne(d => d.Modification)
                    .WithMany(p => p.ShopingCarts)
                    .HasForeignKey(d => d.ModificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopingCart_Mdification");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.HasIndex(e => e.Name, "UQ__Status__72E12F1B1C11DF8D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatagoryId).HasColumnName("catagory_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_Category");
            });

            modelBuilder.Entity<Value>(entity =>
            {
                entity.ToTable("Value");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Value1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Сlothe>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Discription)
                    .HasColumnType("text")
                    .HasColumnName("discription");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.VendorCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vendor_code");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Сlothes)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Сlothes_Gender");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Сlothes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Сlothes_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
