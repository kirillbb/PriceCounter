using System;
using System.Collections.Generic;

namespace PriceCounter
{
    public partial class Work
    {
        public int Id { get; set; }
        public string TheWork { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
