using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

public partial class Asset
{
    [Key]
    public Guid Id { get; set; }

    [Column("Asset_No")]
    [StringLength(25)]
    [Unicode(false)]
    public string AssetNo { get; set; } = null!;

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

    [ForeignKey("FidDeliveryOrder")]
    [InverseProperty("Assets")]
    public virtual DeliveryOrder? FidDeliveryOrderNavigation { get; set; }
}
