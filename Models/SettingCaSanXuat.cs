using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScadaProject.Models
{
    public class SettingCaSanXuat
    {
        [Key]
        public int Id { get; set; }
        public int TimeStartHour { get; set; }

        public int TimeStarMinute { get; set; }

        [Required]
        [MaxLength(10)]
        public string NameTruongCa { get; set; }

    }
}


