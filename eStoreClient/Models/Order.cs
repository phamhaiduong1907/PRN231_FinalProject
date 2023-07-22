namespace eStoreClient.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public class Order
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Order()
        //{
        //    OrderDetails = new HashSet<OrderDetail>();
        //}

        public int OrderId { get; set; }

        public int? MemberId { get; set; }

        public string OrderDate { get; set; }

        public string Required { get; set; }

        public string ShippedDate { get; set; }

        public decimal? Freight { get; set; }

        //public virtual Member Member { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
