using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

public partial class Location
{
    [Key]
    public Guid Id { get; set; }

    [Column("Work_Location")]
    [StringLength(50)]
    [Unicode(false)]
    public string WorkLocation { get; set; } = null!;

    [StringLength(75)]
    [Unicode(false)]
    public string Floor { get; set; } = null!;

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

    [InverseProperty("FidLocationNavigation")]
    public virtual ICollection<LocationLog> LocationLogs { get; set; } = new List<LocationLog>();
}
