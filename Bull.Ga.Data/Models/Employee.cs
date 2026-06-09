using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Keyless]
[Table("Employee")]
public partial class Employee
{
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nik { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? NickName { get; set; }

    [Column("Created_By")]
    [StringLength(100)]
    public string CreatedBy { get; set; } = null!;

    [Column("Created_Date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("Modified_By")]
    [StringLength(100)]
    public string ModifiedBy { get; set; } = null!;

    [Column("Modified_Date", TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [Column("Is_Deleted")]
    public bool? IsDeleted { get; set; }
}
