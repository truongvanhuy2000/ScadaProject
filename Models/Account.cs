using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScadaProject.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Full Name: ")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("UserName: ")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Password:  ")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Email: ")]
        public string Email { get; set; }
        [DisplayName("Phone: ")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Gender: ")]
        public string Gender { get; set; }
        
    }
}
