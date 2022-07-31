using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScadaProject.Models
{
    public class SettingPLC
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TocDoChuan { get; set; }

        [Required]
        public int ThoiGianTinhDungMay { get; set; }

        [Required]
        public int ThoiGianChapNhanGoi { get; set; }

        [Required]
        public int ThoiGianTinhGoiCan { get; set; }


        [Required]
        public int ThoiGianDayGoiCan { get; set; }


        [Required]
        public int ThoiGianCapNhap { get; set; }


        [Required]
        public int ThoiGianDayGoi { get; set; }


        [Required]
        public int DayChuyen { get; set; }
    }
}
