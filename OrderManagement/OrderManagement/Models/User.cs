namespace OrderManagement.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;

        // В базе данных мы никогда не храним пароли в чистом виде — только их зашифрованный хэш
        public string PasswordHash { get; set; } = string.Empty;

        // Наша созданная ранее роль (Admin, Booster, Client)
        public UserRole Role { get; set; }
    }
}
