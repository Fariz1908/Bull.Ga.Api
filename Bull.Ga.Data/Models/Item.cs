using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

public partial class Item
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("Fid_Asset_Category")]
    public int FidAssetCategory { get; set; }

    [Column("Is_Active")]
    public bool? IsActive { get; set; }

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

    [InverseProperty("FidItemNavigation")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [ForeignKey("FidAssetCategory")]
    [InverseProperty("Items")]
    public virtual AssetCategory FidAssetCategoryNavigation { get; set; } = null!;
}
