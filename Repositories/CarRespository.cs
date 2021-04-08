using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Sqlgregslist.Models;

namespace Sqlgregslist.Repositories
{
    public class CarRepository
    {
        public readonly IDbConnection _db;

        public CarRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Car> GetAll()
        {
            string sql = "SELECT * FROM car;";
            return _db.Query<Car>(sql);
        }

        internal Car GetById(int Id)
        {
            string sql = "SELECT * FROM car WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { Id });
        }

        internal object Create(Car newCar)
        {
            string sql = @"
      INSERT INTO car
      (model, year, price, miles)
      VALUES
      (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }

        internal Car Edit(Car CarToEdit)
        {
            string sql = @"
          UPDATE car
          SET
          model = @Model,
          year = @Year,
          price = @Price,
          miles = @Miles
          WHERE id = @Id;
          SELECT * FROM car WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, CarToEdit);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM car WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}