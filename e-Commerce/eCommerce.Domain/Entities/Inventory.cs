using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Description")]
        public string? Description { get; set; }
        
        [Required]
        [Column("Quantity")]
        public int Quantity { get; set; }
        
        [Required]
        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }
        
        [Column("LastUpdated")]
        public DateTime LastUpdated { get; set; }
        
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
} 