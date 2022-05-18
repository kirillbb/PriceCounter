using System;
using System.Collections.Generic;

namespace PriceCounter
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Услуга { get; set; } = null!;
        public decimal Цена { get; set; }
        public double Количество { get; set; }
    }
}
