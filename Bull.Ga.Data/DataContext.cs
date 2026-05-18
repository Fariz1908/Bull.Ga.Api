using Bull.Ga.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetCategory> AssetCategories { get; set; }

    public virtual DbSet<DeliveryOrder> DeliveryOrders { get; set; }

    public virtual DbSet<DeliveryOrderDetail> DeliveryOrderDetails { get; set; }

    public virtual DbSet<DepreciationLog> DepreciationLogs { get; set; }

    public virtual DbSet<DepreciationMethod> DepreciationMethods { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<LocationLog> LocationLogs { get; set; }

    public virtual DbSet<MaintenanceLog> MaintenanceLogs { get; set; }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<PoDetail> PoDetails { get; set; }

    public virtual DbSet<Pr> Prs { get; set; }

    public virtual DbSet<PrDetail> PrDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Assets");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidDeliveryOrderNavigation).WithMany(p => p.Assets).HasConstraintName("FK_Assets_Delivery_Order");

            entity.HasOne(d => d.FidItemNavigation).WithMany(p => p.Assets).HasConstraintName("FK_Assets_Items");
        });

        modelBuilder.Entity<AssetCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Asset_Categories");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidDepreciationMethodNavigation).WithMany(p => p.AssetCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asset_Categories_Depreciation_Methods");
        });

        modelBuilder.Entity<DeliveryOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Delivery_Order");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DeliveryOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Delivery_Order_Detail");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidDeliveryOrderNavigation).WithMany(p => p.DeliveryOrderDetails).HasConstraintName("FK_Delivery_Order_Detail_Delivery_Order");
        });

        modelBuilder.Entity<DepreciationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Depreciation_Log");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidAssetNavigation).WithMany(p => p.DepreciationLogs).HasConstraintName("FK_Depreciation_Log_Assets");
        });

        modelBuilder.Entity<DepreciationMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Depreciation_Methods");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Items");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidAssetCategoryNavigation).WithMany(p => p.Items).HasConstraintName("FK_Items_Asset_Categories");
        });

        modelBuilder.Entity<LocationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Location_Log");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidAssetNavigation).WithMany(p => p.LocationLogs).HasConstraintName("FK_Location_Log_Assets");
        });

        modelBuilder.Entity<MaintenanceLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Maintenance_Log");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidAssetNavigation).WithMany(p => p.MaintenanceLogs).HasConstraintName("FK_Maintenance_Log_Assets");
        });

        modelBuilder.Entity<Po>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_M_Po");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PoDetail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Pr>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())", "DF_Pr_Id");
        });

        modelBuilder.Entity<PrDetail>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())", "DF_Pr_Detail_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
