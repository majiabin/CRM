using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Cache;
using CarManager.Core.Data;
using CarManager.Core.Domain;

namespace CarManager.Service.Cars
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> carRepository;
        private readonly ICacheManager cacheManager;
        private const string CarsCacheKey = nameof(CarService) + nameof(Car);

        public CarService(IRepository<Car> carRepository, ICacheManager cacheManager)
        {
            this.carRepository = carRepository;
            this.cacheManager = cacheManager;
        }

        public int CreateCar(Car car)
        {
            return carRepository.Insert(car);
        }

        public int UpdateCar(Car car)
        {
            return carRepository.Update(car);
        }

        public int DeleteCar(Car car)
        {
            return carRepository.Delete(car);
        }

        public List<Car> GetCars()
        {
            List<Car> cars = null;
            if (cacheManager.Contains(CarsCacheKey))
            {
                cars = cacheManager.Get<List<Car>>(CarsCacheKey);
            }
            else
            {
                cars = carRepository.Table.ToList();
                cacheManager.Set(CarsCacheKey, cars, TimeSpan.FromHours(1));
            }
            return cars;
        }



    }
}
