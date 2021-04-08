using System;
using System.ComponentModel.DataAnnotations;

namespace Sqlgregslist.Models
{
    public class House
    {
        public string Description { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int Id { get; set; }
    }
}