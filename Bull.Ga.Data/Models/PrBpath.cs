using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Pr_Bpath")]
public partial class PrBpath
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [Column("Pr_No")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PrNo { get; set; }

    [Column("Emp_Id")]
    public int? EmpId { get; set; }

    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Company { get; set; }

    [Column("Dept_Id")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DeptId { get; set; }

    [Unicode(false)]
    public string? Dept { get; set; }

    [Unicode(false)]
    public string? Remarks { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Currency { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Tax { get; set; }

    [Column("Total_Amount")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TotalAmount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("Created_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column("Created_Date", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("Modified_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [Column("Modified_Date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
