using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Domain;

namespace CarManager.Service.Cars
{
    public interface ICarService
    {
        int CreateCar(Car car);
        int UpdateCar(Car car);
        int DeleteCar(Car car);
        List<Car> GetCars();
    }
}
