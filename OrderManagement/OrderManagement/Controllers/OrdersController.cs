using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;
using OrderManagement.DTOs;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Через конструктор внедряем контекст БД (Dependency Injection)
        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            // Валидация: проверяем, что цена и выплата не отрицательные
            if (dto.Price < 0 || dto.Payout < 0)
            {
                return BadRequest("Цена и выплата не могут быть отрицательными.");
            }

            // Маппинг: переносим данные из DTO в доменную модель базы данных
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                TargetExperience = dto.TargetExperience,
                VehicleDetails = dto.VehicleDetails,
                Deadline = dto.Deadline,
                Price = dto.Price,
                Payout = dto.Payout,
                ClientId = dto.ClientId,
                // Status и CreatedAt заполнятся автоматически дефолтными значениями из класса Order
            };

            // Добавляем в локальный набор данных и сохраняем в физическую БД асинхронно
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            // Возвращаем статус 200 OK и данные созданного заказа
            return Ok(newOrder);
        }
    }
}