﻿namespace Server.Models.DTO
{
    public class ResponseOrderDetailDTO
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int? Discount { get; set; }
    }
}
