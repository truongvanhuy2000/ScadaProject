using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ScadaProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name: ")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Production Shift: ")]
        public int ProductionShift { get; set; }
        [Required]
        [DisplayName("Production Line:  ")]
        public int ProductionLine { get; set; }
        [Required]
        [DisplayName("Machine Number: ")]
        public int MachineNumber { get; set; }
        [DisplayName("Total Packages: ")]
        public int TotalPackage { get; set; }
        [DisplayName("Damaged package: ")]
        public int DamagedPackage { get; set; }
        [DisplayName("Empty Packages: ")]
        public int EmptyPackage { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
