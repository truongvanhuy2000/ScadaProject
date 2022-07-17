using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScadaProject.Models
{
    public class SetGeneralInformation
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string NameTruongCa { get; set; }

        [Required]
        public string NameProduct { get; set; }
    }
}


