using Domain.Entities;
using Infrastructure.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dapper;
using AutoMapper;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly dbContext _context;       

        public CarRepository(dbContext context)
        {
            _context = context;           
        }

        public Car GetCarById(int carId)
        {
            var result = _context.Cars.FirstOrDefault(x => x.CarId == carId);
            return result;
        }
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var result = _context.Cars.ToList<Car>();
            return result;
        }

        public async Task<Car> GetByIdAsync(int carId)
        {   
            var car = _context.Cars.FirstOrDefault(x => x.CarId == carId);
            var result = new Car
            {
                  CarId = carId,
                  Mark = car.Mark,
                  Model = car.Model,
                  RejestractionNumber = car.RejestractionNumber,
                  ProductionYear = car.ProductionYear,
                  Modification = car.Modification
            };

            return result;
        }

        public async Task<int> AddAsync(Car car, CancellationToken cancellationToken)
        {
            await _context.Cars.AddAsync(new Car
            {
                Mark = car.Mark,
                Model = car.Model,
                RejestractionNumber = car.RejestractionNumber,
                ProductionYear = car.ProductionYear,
                Created = DateTime.Now,
                Modification = DateTime.Now
            },
                 cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            var carId = _context.Cars.Max(i => i.CarId);
            
            return carId;
        }

        public async Task<int> UpdateAsync(Car car, CancellationToken cancellationToken)
        {
            var db = _context.Cars.FirstOrDefault(x => x.CarId == car.CarId);
            if (db != null)
            {
                db.Mark = car.Mark;
                db.Model = car.Model;
                db.RejestractionNumber = car.RejestractionNumber;
                db.ProductionYear = car.ProductionYear;
                db.Modification = DateTime.Now;

                _context.Cars.Update(db);
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(int carId, CancellationToken cancellationToken)
        {
            var DeleteCar = _context.Cars.FirstOrDefault(x => x.CarId == carId);
            if(DeleteCar != null)
            _context.Cars.RemoveRange(DeleteCar);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    } 
}
