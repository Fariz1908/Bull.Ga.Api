using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

public partial class Asset
{
    [Key]
    public Guid Id { get; set; }

    [Column("Fid_Item")]
    public Guid? FidItem { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Merk { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Model { get; set; }

    [Column("Serial_Number")]
    [StringLength(150)]
    [Unicode(false)]
    public string? SerialNumber { get; set; }

    [Column("Fid_Location")]
    public Guid? FidLocation { get; set; }

    [Column("Fid_Delivery_Order")]
    public Guid? FidDeliveryOrder { get; set; }

    [Column("Purchase_Date")]
    public DateOnly? PurchaseDate { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Supplier { get; set; }

    [Column("Purchase_Amount")]
    public int? PurchaseAmount { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Remark { get; set; }

    [Column("Created_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column("Created_At", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("Updated_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column("Updated_At", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("FidAssetNavigation")]
    public virtual ICollection<DepreciationLog> DepreciationLogs { get; set; } = new List<DepreciationLog>();

    [ForeignKey("FidDeliveryOrder")]
    [InverseProperty("Assets")]
    public virtual DeliveryOrder? FidDeliveryOrderNavigation { get; set; }

    [ForeignKey("FidItem")]
    [InverseProperty("Assets")]
    public virtual Item? FidItemNavigation { get; set; }

    [InverseProperty("FidAssetNavigation")]
    public virtual ICollection<LocationLog> LocationLogs { get; set; } = new List<LocationLog>();

    [InverseProperty("FidAssetNavigation")]
    public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
}
