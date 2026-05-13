using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Asset_Categories")]
public partial class AssetCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("Useful_Life_Year")]
    public int? UsefulLifeYear { get; set; }

    [Column("Fid_Depreciation_Method")]
    public int? FidDepreciationMethod { get; set; }

    [Column("Residual_Value")]
    public int? ResidualValue { get; set; }

    [Column("Is_Active")]
    public bool? IsActive { get; set; }

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

    [ForeignKey("FidDepreciationMethod")]
    [InverseProperty("AssetCategories")]
    public virtual DepreciationMethod? FidDepreciationMethodNavigation { get; set; }

    [InverseProperty("FidAssetCategoryNavigation")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
