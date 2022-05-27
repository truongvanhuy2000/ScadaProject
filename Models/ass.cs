using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ScadaProject.Models
{
    public class ass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name: ")]
        public string ProductName { get; set; }
        public int EmptyPackage { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
