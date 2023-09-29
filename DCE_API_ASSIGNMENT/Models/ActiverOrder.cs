using System;
using System.ComponentModel.DataAnnotations;

namespace DCE_API_ASSIGNMENT.Models
{
    public class ActiverOrder
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderBy { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
