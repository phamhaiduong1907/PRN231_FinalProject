﻿using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Cart
    {
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
