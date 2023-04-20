using System.ComponentModel.DataAnnotations;

namespace CarMaintenanceApp.Models
{
    public class CarService
    {
        [Key]
        public int CarServiceId { get; set; }
        public string CarServiceName { get; set; }
        public int CarId { get; set; }
    }
}
