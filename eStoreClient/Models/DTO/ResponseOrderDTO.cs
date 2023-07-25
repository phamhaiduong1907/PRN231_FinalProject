using System;
using System.Collections.Generic;

namespace Server.Models.DTO
{
    public class ResponseOrderDTO
    {
        public int OrderId { get; set; }
        public string MemberName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Total { get; set; }
        public List<ResponseOrderDetailDTO> OrderDetails { get; set; } = new List<ResponseOrderDetailDTO>();
    }
}
