using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int NumberOfBottles { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int CustomerId { get; set; }
    }
}