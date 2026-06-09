using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Delivery_Order")]
public partial class DeliveryOrder
{
    [Key]
    public Guid Id { get; set; }

    [Column("Do_No")]
    [StringLength(50)]
    [Unicode(false)]
    public string DoNo { get; set; } = null!;

    [Column("Fid_Po")]
    public Guid FidPo { get; set; }

    [Column("Fid_Company")]
    public Guid FidCompany { get; set; }

    [Column("Fid_Dept")]
    public Guid FidDept { get; set; }

    [Column("Fid_Employee_Recieved")]
    public int FidEmployeeRecieved { get; set; }

    [Column("Fid_Employee_Sent")]
    public int FidEmployeeSent { get; set; }

    [Column("Fid_Employee_Acknowledge")]
    public int FidEmployeeAcknowledge { get; set; }

    [Column("Is_Delete")]
    public bool? IsDelete { get; set; }

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

    [InverseProperty("FidDeliveryOrderNavigation")]
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    [InverseProperty("FidDeliveryOrderNavigation")]
    public virtual ICollection<DeliveryOrderDetail> DeliveryOrderDetails { get; set; } = new List<DeliveryOrderDetail>();

    [ForeignKey("FidCompany")]
    [InverseProperty("DeliveryOrders")]
    public virtual Company FidCompanyNavigation { get; set; } = null!;

    [ForeignKey("FidDept")]
    [InverseProperty("DeliveryOrders")]
    public virtual Department FidDeptNavigation { get; set; } = null!;
}
