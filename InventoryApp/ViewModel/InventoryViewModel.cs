using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryApp.ViewModel
{
    public class InventoryViewModel
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public string Sku { get; set; }

        public int Qty { get; set; }

        public string Store { get; set; }

        //[Range(0, 999)]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }
    }
}