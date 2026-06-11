using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Location_Logs")]
public partial class LocationLog
{
    [Key]
    public Guid Id { get; set; }

    [Column("Transcation_No")]
    [StringLength(50)]
    [Unicode(false)]
    public string TranscationNo { get; set; } = null!;

    [Column("Fid_Asset")]
    public Guid FidAsset { get; set; }

    [Column("Submitted_Date")]
    public DateOnly SubmittedDate { get; set; }

    [Column("Return_Date")]
    public DateOnly? ReturnDate { get; set; }

    [Column("Fid_Location")]
    public Guid FidLocation { get; set; }

    [Column("Fid_Employee")]
    public int? FidEmployee { get; set; }

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

    [Column("Is_Delete")]
    public bool? IsDelete { get; set; }

    [ForeignKey("FidAsset")]
    [InverseProperty("LocationLogs")]
    public virtual Asset FidAssetNavigation { get; set; } = null!;

    [ForeignKey("FidEmployee")]
    [InverseProperty("LocationLogs")]
    public virtual Employee? FidEmployeeNavigation { get; set; }

    [ForeignKey("FidLocation")]
    [InverseProperty("LocationLogs")]
    public virtual Location FidLocationNavigation { get; set; } = null!;
}
