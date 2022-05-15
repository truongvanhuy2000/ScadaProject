using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScadaProject.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("UserName: ")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Password:  ")]
        public string Password { get; set; }
    }
}
