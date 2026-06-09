using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bull.Ga.Common.DtoModels
{
    public class AssetInputRequest
    {
        public Guid? Id { get; set; }
        public required string AssetNo { get; set; }
        public Guid FidItem { get; set; }
        public string Merk { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public Guid FidCompany { get; set; }
        public Guid FidDepartment { get; set; }
        public Guid FidDeliveryOrder { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public int PurchaseAmount { get; set; }
        public string Remark { get; set; } = string.Empty;
    }
}
