using System;

namespace OrderManagement.DTOs
{
    public class CreateOrderDto
    {
        public int TargetExperience { get; set; }
        public string VehicleDetails { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public decimal Price { get; set; }
        public decimal Payout { get; set; }
        public Guid ClientId { get; set; }
    }
}
