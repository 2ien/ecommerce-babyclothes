using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce_shop.Models
{
    public class ShippingDetails
    {
        public int ShippingDetailId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public string PaymentType { get; set; }

        public virtual Tbl_Members Tbl_Members { get; set; }
    }
}