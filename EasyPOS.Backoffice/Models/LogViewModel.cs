using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class LogViewModel
    {
        [Display(Name = "Fecha Inicial")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Fecha Final")]
        public DateTime EndDate { get; set; } = DateTime.Now;
        public List<Log> LogList { get; set; } = new List<Log>();
    }
}
