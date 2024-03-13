using System.ComponentModel.DataAnnotations;

namespace ocian_net.Models
{
    
    public class FormWorkWithUs
    {

        [Required, MinLength(6), MaxLength(50)]
        public required string Name { get; set; }

        [Required, EmailAddress, MinLength(8), MaxLength(50)]
        public required string Email { get; set; }

        [Required, Phone, MinLength(8), MaxLength(20)]
        public required string Phone { get; set; }
        
        [Required]
        public required IFormFile File { get; set; }

        [Required, MinLength(6), MaxLength(50)]
        public required string Subject { get; set; }

        [Required, MinLength(6), MaxLength(500)]
        public required string Message { get; set; } 
    }
}