using System;
using System.Collections.Generic;

#nullable disable

namespace WindowService2
{
    public partial class CarValueApi
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int YearOfPurchase { get; set; }
        public int Mileage { get; set; }
        public string PlateNumber { get; set; }
        public decimal CarCurrentPrice { get; set; }
    }
}
