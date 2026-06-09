using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bull.Ga.Data.Models;

[Table("Depreciation_Log")]
public partial class DepreciationLog
{
    [Key]
    public Guid Id { get; set; }

    [Column("Fid_Asset")]
    public Guid FidAsset { get; set; }

    [Column("Period_Date")]
    public DateOnly? PeriodDate { get; set; }

    [Column("Depreciation_Amount")]
    public int? DepreciationAmount { get; set; }

    [Column("Book_Value")]
    public int? BookValue { get; set; }

    [ForeignKey("FidAsset")]
    [InverseProperty("DepreciationLogs")]
    public virtual Asset FidAssetNavigation { get; set; } = null!;
}
