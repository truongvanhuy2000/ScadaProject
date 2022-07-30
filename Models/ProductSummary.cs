using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScadaProject.Models
{
    public class ProductSummary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String ProductName { get; set; }

        [Required]
        public int TotalAmounts { get; set; }
        [Required]
        public int TotalDamaged { get; set; }
        [Required]
        public int TotalEmpry { get; set; }
    }
}
