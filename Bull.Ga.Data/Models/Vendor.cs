using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

public partial class Vendor
{
    [Key]
    [StringLength(7)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? City { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Country { get; set; }

    [Column("Zip_Code")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ZipCode { get; set; }

    [Column("Phone_1")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Phone1 { get; set; }

    [Column("Phone_2")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Phone2 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Fax { get; set; }

    [Column("Contact_Person")]
    [StringLength(150)]
    [Unicode(false)]
    public string? ContactPerson { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("Created_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column("Created_Date", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("Modified_By")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ModifiedBy { get; set; }

    [Column("Modified_Date", TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("Is_Active")]
    public bool? IsActive { get; set; }
}
