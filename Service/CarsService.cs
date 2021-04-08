using System;
using System.Collections.Generic;
using Sqlgregslist.Models;
using Sqlgregslist.Repositories;

namespace Sqlgregslist.Services
{
    public class CarsService
    {
        private readonly CarRepository _repo;

        public CarsService(CarRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> GetAll()
        {
            return _repo.GetAll();
        }

        internal Car GetById(int id)
        {
            Car car = _repo.GetById(id);
            if (car == null)
            {
                throw new Exception("invalid id");
            }
            return car;
        }

        internal object Create(Car newCar)
        {
            return _repo.Create(newCar);
        }

        internal Car Edit(Car editCar)
        {
            Car original = GetById(editCar.Id);

            original.Model = editCar.Model != null ? editCar.Model : original.Model;
            original.Price = editCar.Price != null ? editCar.Price : original.Price;

            //NOTE if you need to null check a number, you can use the Elvis operator on the type in the class. 
            original.Year = editCar.Year != null ? editCar.Year : original.Year;
            original.Miles = editCar.Miles != null ? editCar.Miles : original.Miles;

            return _repo.Edit(original);
        }
        internal Car Delete(int id)
        {
            Car original = GetById(id);
            _repo.Delete(id);
            return original;
        }

    }




}