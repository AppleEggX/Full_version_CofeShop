using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public enum Difficulty
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public enum CourseType 
    {
        Barista,
        HomeBrew,
        LatteArt,
        SensorySkills,
        Roasting

    }
    public class Course : Product
    {
        public string Length { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime[] AvailableStartDates { get; set; }
        public CourseType CourseType { get; set; }
        
    }
}
