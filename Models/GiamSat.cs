using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScadaProject.Models
{
    public class GiamSat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String ProductName { get; set; }

        [Required]
        public int TotalAmounts { get; set; }

        [Required]
        public int TocDoChuan { get; set; }

        [Required]
        public int HieuSuat { get; set; }

        [Required]
        public int SanLuongGoi { get; set; }

        [Required]
        public int TotalDamaged { get; set; }
        
        [Required]
        public int TotalEmpry { get; set; }

        [Required]
        public float PerDamaged { get; set; }

        [Required]
        public float PerEmpry { get; set; }

        [Required]
        public int DayChuyen { get; set; }
    }
}
