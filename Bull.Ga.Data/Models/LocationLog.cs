using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Location_Log")]
public partial class LocationLog
{
    [Key]
    public Guid Id { get; set; }

    [Column("Transcation_No")]
    [StringLength(50)]
    [Unicode(false)]
    public string TranscationNo { get; set; } = null!;

    [Column("Fid_Asset")]
    public Guid? FidAsset { get; set; }

    [Column("Submitted_Date")]
    public DateOnly SubmittedDate { get; set; }

    [Column("Return_Date")]
    public DateOnly? ReturnDate { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Location { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    [Column("Created_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("Created_At", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("Updated_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column("Updated_At", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("FidAsset")]
    [InverseProperty("LocationLogs")]
    public virtual Asset? FidAssetNavigation { get; set; }
}
