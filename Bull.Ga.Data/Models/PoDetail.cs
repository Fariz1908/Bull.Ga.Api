using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Po_Detail")]
public partial class PoDetail
{
    [Key]
    public Guid Id { get; set; }

    [Column("Fid_Pr_Detail_Id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FidPrDetailId { get; set; }

    [Column("Fid_Po")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FidPo { get; set; }

    [Unicode(false)]
    public string? Item { get; set; }

    [Column("Requested_By")]
    [StringLength(500)]
    [Unicode(false)]
    public string? RequestedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Quantity { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Unit { get; set; }

    [Column("Required_Date", TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column("Unit_Price")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UnitPrice { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Discount { get; set; }

    [Column("Is_Deleted")]
    public int? IsDeleted { get; set; }
}
