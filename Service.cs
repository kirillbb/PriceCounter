using System;
using System.Collections.Generic;

namespace PriceCounter
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Work { get; set; } = null!;
        public decimal Price { get; set; }
        public double Count { get; set; }
    }
}
