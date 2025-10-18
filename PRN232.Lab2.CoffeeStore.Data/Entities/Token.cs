using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Data.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public string TokenValue { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; 
        public bool IsRevoked { get; set; } = false; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }

}
