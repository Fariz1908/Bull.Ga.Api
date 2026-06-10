using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Maintenance_Log")]
public partial class MaintenanceLog
{
    [Key]
    public Guid Id { get; set; }

    [Column("Fid_Asset")]
    public Guid FidAsset { get; set; }

    [Column("Maintenance_Date")]
    public DateOnly? MaintenanceDate { get; set; }

    [Column("Maintenance_Type")]
    public int? MaintenanceType { get; set; }

    public int? Cost { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Notes { get; set; }

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
}
