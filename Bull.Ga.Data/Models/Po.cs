using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Po")]
public partial class Po
{
    [Key]
    public Guid Id { get; set; }

    [Column("Fid_PR")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FidPr { get; set; }

    [Column("Po_No")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PoNo { get; set; }

    [Column("Po_IdNo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PoIdNo { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Currency { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Subtotal { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Tax { get; set; }

    [Column("Total_Amount")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TotalAmount { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Company { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Dept { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Partner { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Attn { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Fax { get; set; }

    [Column("Delivered_Date", TypeName = "datetime")]
    public DateTime? DeliveredDate { get; set; }

    [Column("Due_Date", TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [Column("Created_Date", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("Created_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column("Modified_Date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("Modified_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("Is_Delete")]
    [StringLength(50)]
    [Unicode(false)]
    public string? IsDelete { get; set; }

    [Column("Po_Attachment")]
    [Unicode(false)]
    public string? PoAttachment { get; set; }
}
