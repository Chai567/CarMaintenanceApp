using System.ComponentModel.DataAnnotations;

namespace CarMaintenanceApp.Models
{
    public class CarMaintenanceStatus
    {
        [Key]
        public int CarMaintenanceStatusId { get; set; }
        public string CarMaintenanceStatusName { get; set; }
    }
}
