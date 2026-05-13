using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Depreciation_Methods")]
public partial class DepreciationMethod
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Description { get; set; }

    [InverseProperty("FidDepreciationMethodNavigation")]
    public virtual ICollection<AssetCategory> AssetCategories { get; set; } = new List<AssetCategory>();
}
