using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pocos;

namespace CofeWebApplication.Models
{
    public class CourseViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Length { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime[] AvailableStartDates { get; set; }
        public CourseType CourseType { get; set; }
    }
}