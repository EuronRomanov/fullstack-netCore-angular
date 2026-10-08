using System.ComponentModel.DataAnnotations;

namespace server.Entities
{

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } = "";
        public string Password { get; set; }
      
        // Navegación para Refresh Tokens
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    }
}
