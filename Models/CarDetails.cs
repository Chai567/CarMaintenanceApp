namespace CarMaintenanceApp.Models
{
    public class CarDetails
    {
        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string OwnerName { get; set; }
        public CarMaintenanceStatus CarMaintenanceStatus { get; set; }
        public List<CarService> CarService { get; set; }
    }
}
