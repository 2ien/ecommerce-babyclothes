using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Yeu cau nhap ten")]
        [StringLength(100, ErrorMessage = "Toi thieu 3 va toi da 100 ky tu cho phep", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public Nullable<bool> IsAtive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
    public class ProductDetail
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Yeu cau nhap ten san pham")]

        public string ProductName { get; set; }
        [Required]
        [Range(1, 50)]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        [Required]
        [Range(typeof(int), "1", "500", ErrorMessage = "So luong khong hop le")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        public SelectList categories { get; set; }
    }
}