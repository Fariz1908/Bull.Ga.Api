using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

public partial class Item
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("Fid_Asset_Category")]
    public int? FidAssetCategory { get; set; }

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

    [InverseProperty("FidItemNavigation")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [ForeignKey("FidAssetCategory")]
    [InverseProperty("Items")]
    public virtual AssetCategory? FidAssetCategoryNavigation { get; set; }
}
