using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ocian_net.Models
{
    
    public class FormProposal
    {

        public int Id { get; private set; } 

        [Required, MinLength(6), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(8), MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(20)]
        public string Phone { get; set; }

        [Required, MinLength(6), MaxLength(50)]
        public string Subject { get; set; }

        [Required, MinLength(6), MaxLength(500)]
        public string Message { get; set; } 

        public FormProposal(string name, string email, string phone, string subject, string message)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Subject = subject;
            Message = message;
        }
    }
}