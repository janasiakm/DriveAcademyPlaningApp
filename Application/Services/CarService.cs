using Application.Interfaces;
using Application.Command.Cars;
using Domain.Entities;
using System.Globalization;
using Application.DTO.Cars;
using Domain.Interfaces;

namespace Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCars()
        {
            var data =  await _repository.GetAllAsync();
            List<CarDTO> result = new List<CarDTO>();

            foreach (var item in data)
            {
                result.Add(new CarDTO
                {   
                    CarId = item.CarId,
                    Mark = item.Mark,
                    Model = item.Model,
                    RejestractionNumber = item.RejestractionNumber
                });
            }
            return result;
        }

        public async Task<CarFullDTO> GetCarById(int carId)
        {
            var data = await _repository.GetByIdAsync(carId);
            var result = new CarFullDTO
            {
                CarId = data.CarId,
                Mark = data.Mark,
                Model = data.Model,
                RejestractionNumber = data.RejestractionNumber,
                ProductionYear = data.ProductionYear,
                Modyfication =data.Modification
              
            };
            return result;
        }

        public async Task<int> AddCar(CreateCarCommand body, CancellationToken cancellationToken)
        {
            var car = new Car
            {                
                Mark = body.Mark,
                Model = body.Model,
                RejestractionNumber = body.RejestractionNumber,
                ProductionYear = body.ProductionYear
            };
            return  await _repository.AddAsync(car, cancellationToken);        
        }

        public async Task<int> UpdateCar(UpdateCarCommand body, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                CarId = body.CarId,
                Mark = body.Mark,
                Model = body.Model,
                RejestractionNumber = body.RejestractionNumber,
                ProductionYear = body.ProductionYear
            };
            return await _repository.UpdateAsync(car, cancellationToken);
        }

        public async Task<int> DeleteCar(DeleteCarCommand body, CancellationToken cancellationToken)
        {
            var CarId = body.CarId;            
            return await _repository.DeleteAsync(CarId, cancellationToken);
        }

        
    }
}
