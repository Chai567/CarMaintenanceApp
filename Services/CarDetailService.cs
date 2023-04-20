using CarMaintenanceApp.Constants;
using CarMaintenanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarMaintenanceApp.Services
{
    public class CarDetailService : ICarDetailService
    {
        private readonly ApplicationDbContext _context;

        public CarDetailService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Car> CreateCar(Car car)
        {
            //method to create new car object
            try
            {
                int numberOfCarsInMaintenance = GetNumberOfCarsInMaintenance();
                car.CarMaintenanceStatus.CarMaintenanceStatusId = numberOfCarsInMaintenance > 10 ? ((int)Constant.CarMaintenanceStatus.Waiting) : ((int)Constant.CarMaintenanceStatus.InProgress);
                car.CarMaintenanceStatus.CarMaintenanceStatusName = Enum.GetName(typeof(Constant.CarMaintenanceStatus), car.CarMaintenanceStatus.CarMaintenanceStatusId);
                _context.Car.Add(car);
                _context.Entry(car.CarMaintenanceStatus).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<List<CarDetails>> GetCarDetails()
        {
            //return details of all cars including maintenance status, car services
            var allCarDetails = await _context.Car.Include(c => c.CarMaintenanceStatus).ToListAsync();
            List<CarDetails> viewCarDetail = new List<CarDetails>();
            foreach (var carDetail in allCarDetails)
            {
                viewCarDetail.Add(new CarDetails
                {
                    CarId = carDetail.CarId,
                    CarMaintenanceStatus = carDetail.CarMaintenanceStatus,
                    CarService = GetCarServices(carDetail.CarId),
                    Make = carDetail.Make,
                    Model = carDetail.Model,
                    OwnerName = carDetail.OwnerName,
                    RegistrationNumber = carDetail.RegistrationNumber
                });
            }
            return viewCarDetail;
        }

        public int GetNumberOfCarsInMaintenance()
        {
            return _context.Car
                .Where(c => c.CarMaintenanceStatus.CarMaintenanceStatusId == ((int)Constant.CarMaintenanceStatus.InProgress))
                .Count();
        }
        public List<CarService> GetCarServices(int carId)
        {
            //get all car services based on car Id
            return _context.CarService
                .Where(y => y.CarId == carId)
                .Select(c => c)
                .ToList();
        }
    }
}
