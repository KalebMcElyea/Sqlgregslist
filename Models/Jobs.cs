using System;
using System.ComponentModel.DataAnnotations;

namespace Sqlgregslist.Models
{
    public class Job
    {
        public string Title { get; set; }

        public int Hour { get; set; }

        public decimal Rate { get; set; }

        public string company { get; set; }

        public int Id { get; set; }
    }
}