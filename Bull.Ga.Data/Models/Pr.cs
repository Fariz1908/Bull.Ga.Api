using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bull.Ga.Data.Models;

[Table("Pr")]
public partial class Pr
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [Column("Pr_No")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PrNo { get; set; }

    [Column("Emp_Id")]
    public int? EmpId { get; set; }

    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Company { get; set; }

    [Column("Dept_Id")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DeptId { get; set; }

    [Unicode(false)]
    public string? Dept { get; set; }

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

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Unicode(false)]
    public string? Remarks { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Currency { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Tax { get; set; }

    [Column("Total_Amount")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TotalAmount { get; set; }

    [Column("Name_On_Passport")]
    [Unicode(false)]
    public string? NameOnPassport { get; set; }

    [Column("Departure_Date")]
    [Unicode(false)]
    public string? DepartureDate { get; set; }

    [Column("Arrival_Date")]
    [Unicode(false)]
    public string? ArrivalDate { get; set; }

    [Column("Departure_Time")]
    [Unicode(false)]
    public string? DepartureTime { get; set; }

    [Column("Arrival_Time")]
    [Unicode(false)]
    public string? ArrivalTime { get; set; }

    [Column("Dest_Depart_From")]
    [Unicode(false)]
    public string? DestDepartFrom { get; set; }

    [Column("Dest_Depart_To")]
    [Unicode(false)]
    public string? DestDepartTo { get; set; }

    [Unicode(false)]
    public string? Destination { get; set; }

    [Column("Dest_Return_To")]
    [Unicode(false)]
    public string? DestReturnTo { get; set; }

    [Column("Dest_Addr")]
    [Unicode(false)]
    public string? DestAddr { get; set; }

    [Column("Beneficiary_Name")]
    [Unicode(false)]
    public string? BeneficiaryName { get; set; }

    [Unicode(false)]
    public string? Relationship { get; set; }

    [Column("Emp_Address")]
    [Unicode(false)]
    public string? EmpAddress { get; set; }

    [Unicode(false)]
    public string? Notes { get; set; }

    [Column("Departure_Flight_No")]
    [Unicode(false)]
    public string? DepartureFlightNo { get; set; }

    [Column("Flight_No")]
    [Unicode(false)]
    public string? FlightNo { get; set; }

    [Column("Travel_Agent_1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TravelAgent1 { get; set; }

    [Column("Currency_Agent_1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CurrencyAgent1 { get; set; }

    [Column("Price_Agent_1")]
    [Unicode(false)]
    public string? PriceAgent1 { get; set; }

    [Column("Travel_Agent_2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TravelAgent2 { get; set; }

    [Column("Currency_Agent_2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CurrencyAgent2 { get; set; }

    [Column("Price_Agent_2")]
    [Unicode(false)]
    public string? PriceAgent2 { get; set; }

    [Column("Travel_Agent_3")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TravelAgent3 { get; set; }

    [Column("Currency_Agent_3")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CurrencyAgent3 { get; set; }

    [Column("Price_Agent_3")]
    [Unicode(false)]
    public string? PriceAgent3 { get; set; }

    [Column("Travel_Ticket_Issued")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TravelTicketIssued { get; set; }

    [Column("Ticket_Class")]
    [Unicode(false)]
    public string? TicketClass { get; set; }

    [Column("Ticket_Cond_1")]
    [Unicode(false)]
    public string? TicketCond1 { get; set; }

    [Column("Ticket_Cond_2")]
    [Unicode(false)]
    public string? TicketCond2 { get; set; }

    [Column("Cost_Person")]
    [Unicode(false)]
    public string? CostPerson { get; set; }

    [Column("Currency_Cost_Person")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CurrencyCostPerson { get; set; }

    [Column("Cost_Dept")]
    [Unicode(false)]
    public string? CostDept { get; set; }

    [Column("Currency_Cost_Dept")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CurrencyCostDept { get; set; }

    [Column("Remarks_Travel")]
    [Unicode(false)]
    public string? RemarksTravel { get; set; }

    [Unicode(false)]
    public string? Refund { get; set; }

    [Column("Currency_Refund")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CurrencyRefund { get; set; }

    [Column("Comp_Or_Dept")]
    [Unicode(false)]
    public string? CompOrDept { get; set; }

    [Column("Vessel_Name")]
    [Unicode(false)]
    public string? VesselName { get; set; }

    [Column("Pay_Voucher")]
    [Unicode(false)]
    public string? PayVoucher { get; set; }

    [Column("Refund_Tick")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RefundTick { get; set; }

    [Column("Refund_Num")]
    [Unicode(false)]
    public string? RefundNum { get; set; }

    [Column("Refund_Remark")]
    [Unicode(false)]
    public string? RefundRemark { get; set; }

    [Column("Refund_Date")]
    [Unicode(false)]
    public string? RefundDate { get; set; }

    [Column("Refund_Voucher")]
    [Unicode(false)]
    public string? RefundVoucher { get; set; }

    [Column("Ticket_Hotel_Options")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TicketHotelOptions { get; set; }

    [Column("Check_In_Date", TypeName = "datetime")]
    public DateTime? CheckInDate { get; set; }

    [Column("Check_In_Time")]
    [Unicode(false)]
    public string? CheckInTime { get; set; }

    [Column("Check_Out_Date", TypeName = "datetime")]
    public DateTime? CheckOutDate { get; set; }

    [Column("Check_Out_Time")]
    [Unicode(false)]
    public string? CheckOutTime { get; set; }

    [Column("Dept_Comp")]
    [Unicode(false)]
    public string? DeptComp { get; set; }

    [Column("Hotel_Name")]
    [Unicode(false)]
    public string? HotelName { get; set; }

    [Column("Hotel_City")]
    [Unicode(false)]
    public string? HotelCity { get; set; }

    [Column("Hotel_Travel_Issued")]
    [Unicode(false)]
    public string? HotelTravelIssued { get; set; }

    [Column("Travel_Others_1")]
    [Unicode(false)]
    public string? TravelOthers1 { get; set; }

    [Column("Travel_Others_2")]
    [Unicode(false)]
    public string? TravelOthers2 { get; set; }

    [Column("Travel_Others_3")]
    [Unicode(false)]
    public string? TravelOthers3 { get; set; }

    [Column("Travel_Others_Issued")]
    [Unicode(false)]
    public string? TravelOthersIssued { get; set; }

    [Column("General_Pr")]
    [StringLength(2)]
    [Unicode(false)]
    public string? GeneralPr { get; set; }

    [Column("Pr_Ticket")]
    [StringLength(2)]
    [Unicode(false)]
    public string? PrTicket { get; set; }

    [Column("Pr_Hotel")]
    [StringLength(2)]
    [Unicode(false)]
    public string? PrHotel { get; set; }

    [Column("Check_Route")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CheckRoute { get; set; }

    [Unicode(false)]
    public string? Specifications { get; set; }

    [Column("Is_Delete")]
    public int IsDelete { get; set; }

    [Unicode(false)]
    public string? Attachment { get; set; }
}
