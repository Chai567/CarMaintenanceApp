using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMaintenanceApp.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public CarMaintenanceStatus CarMaintenanceStatus { get; set; }
    }
}
