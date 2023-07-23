using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStoreClient.Models.DTO
{
    public class CartDTO
    {
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
