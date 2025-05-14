using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Users")]
    public class ApplicationUser
    {
        [Column("Id")]
        public int Id { get; set; }
        
        [Column("Email")]
        public string Email { get; set; }
        
        [Column("Password")]
        public string Password { get; set; }
        
        [Column("Role")]
        public string Role { get; set; }
        
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [Column("LastLogin")]
        public DateTime? LastLogin { get; set; }
    }
}
