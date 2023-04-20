using CarMaintenanceApp.Models;

namespace CarMaintenanceApp.Services
{
    public interface ICarDetailService
    {
        Task<Car> CreateCar(Car car);
        Task<List<CarDetails>> GetCarDetails();
        int GetNumberOfCarsInMaintenance();
        List<CarService> GetCarServices(int carId);
    }
}
