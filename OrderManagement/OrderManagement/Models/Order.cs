using System;

namespace OrderManagement.Models
{
    public class Order
    {
        // Системные поля
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // По умолчанию ставим текущее время UTC
        public OrderStatus Status { get; set; } = OrderStatus.Created; // Новый заказ всегда в статусе "Создан"

        // Бизнес-данные заказа
        public int TargetExperience { get; set; }
        public string VehicleDetails { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public decimal Price { get; set; }
        public decimal Payout { get; set; }

        // Связи (Внешние ключи)
        public Guid ClientId { get; set; }
        public Guid? BoosterId { get; set; } // Nullable, так как исполнителя изначально нет
    }
}
