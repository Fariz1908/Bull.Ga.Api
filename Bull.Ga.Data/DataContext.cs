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

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<DeliveryOrder> DeliveryOrders { get; set; }

    public virtual DbSet<DeliveryOrderDetail> DeliveryOrderDetails { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepreciationLog> DepreciationLogs { get; set; }

    public virtual DbSet<DepreciationMethod> DepreciationMethods { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationLog> LocationLogs { get; set; }

    public virtual DbSet<MaintenanceLog> MaintenanceLogs { get; set; }

    public virtual DbSet<PoBpath> PoBpaths { get; set; }

    public virtual DbSet<PoDetailBpath> PoDetailBpaths { get; set; }

    public virtual DbSet<PrBpath> PrBpaths { get; set; }

    public virtual DbSet<PrDetailBpath> PrDetailBpaths { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Assets");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidCompanyNavigation).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_Companies");

            entity.HasOne(d => d.FidDeliveryOrderNavigation).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_Delivery_Order");

            entity.HasOne(d => d.FidDepartmentNavigation).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_Departments");

            entity.HasOne(d => d.FidItemNavigation).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_Items");

            entity.HasOne(d => d.FidLocationNavigation).WithMany(p => p.Assets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assets_Locations");
        });

        modelBuilder.Entity<AssetCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Asset_Categories");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidDepreciationMethodNavigation).WithMany(p => p.AssetCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asset_Categories_Depreciation_Methods");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Companies");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DeliveryOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Delivery_Order");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidCompanyNavigation).WithMany(p => p.DeliveryOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Order_Companies");

            entity.HasOne(d => d.FidDeptNavigation).WithMany(p => p.DeliveryOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Order_Departments");
        });

        modelBuilder.Entity<DeliveryOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Delivery_Order_Detail");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidDeliveryOrderNavigation).WithMany(p => p.DeliveryOrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Order_Detail_Delivery_Order");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Departments");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DepreciationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Depreciation_Log");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidAssetNavigation).WithMany(p => p.DepreciationLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Depreciation_Log_Assets");
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

            entity.HasOne(d => d.FidAssetCategoryNavigation).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_Asset_Categories");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Locations");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<LocationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Location_Log");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidAssetNavigation).WithMany(p => p.LocationLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_Log_Assets");
        });

        modelBuilder.Entity<MaintenanceLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pkey_Maintenance_Log");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FidAssetNavigation).WithMany(p => p.MaintenanceLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maintenance_Log_Assets");
        });

        modelBuilder.Entity<PoBpath>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PoDetailBpath>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Po_Detail");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PrBpath>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())", "DF_Pr_Id");
        });

        modelBuilder.Entity<PrDetailBpath>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())", "DF_Pr_Detail_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
