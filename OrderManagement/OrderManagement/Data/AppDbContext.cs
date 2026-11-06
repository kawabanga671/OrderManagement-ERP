using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Data
{
    public class AppDbContext : DbContext
    {
        // Конструктор передает настройки подключения (строку подключения) в базовый класс DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Эти свойства сообщают EF Core, какие таблицы нужно создать в базе данных
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
