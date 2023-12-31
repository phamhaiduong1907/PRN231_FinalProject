﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eStoreClient.Models
{
    public class Cart
    {
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [JsonPropertyName("Product")]
        public Product ProductRef { get; set; }
    }
}
