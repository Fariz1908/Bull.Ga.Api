using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Keyless]
[Table("Pr_Detail")]
public partial class PrDetail
{
    public Guid? Id { get; set; }

    [Column("Fid_Pr")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FidPr { get; set; }

    [Column("Item_Id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ItemId { get; set; }

    [Unicode(false)]
    public string? Item { get; set; }

    [Column("Requested_By")]
    [Unicode(false)]
    public string? RequestedBy { get; set; }

    public double? Quantity { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Unit { get; set; }

    [Column("Required_Date", TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column("Unit_Price")]
    public double? UnitPrice { get; set; }

    [Column("Fid_Type")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FidType { get; set; }

    [Column("Is_Deleted")]
    public int? IsDeleted { get; set; }

    [Column("Is_Processed_Po")]
    public int? IsProcessedPo { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Currency { get; set; }
}
