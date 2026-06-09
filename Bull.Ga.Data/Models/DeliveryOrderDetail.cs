using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Delivery_Order_Detail")]
public partial class DeliveryOrderDetail
{
    [Key]
    public Guid Id { get; set; }

    [Column("Fid_Delivery_Order")]
    public Guid FidDeliveryOrder { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Item { get; set; }

    public int? Qty { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Unit { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    [ForeignKey("FidDeliveryOrder")]
    [InverseProperty("DeliveryOrderDetails")]
    public virtual DeliveryOrder FidDeliveryOrderNavigation { get; set; } = null!;
}
