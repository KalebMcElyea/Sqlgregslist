using System;
using System.ComponentModel.DataAnnotations;

namespace Sqlgregslist.Models
{
    public class Car
    {
        public string Model { get; set; }

        public int? Year { get; set; }

        public decimal? Price { get; set; }

        public int? Miles { get; set; }

        public int Id { get; set; }
    }
}