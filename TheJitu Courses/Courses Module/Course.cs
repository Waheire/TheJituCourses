using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheJitu_Courses.Courses_Module
{
    internal class Course
    {
        //public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        internal void ShowAllCourses()
        {
            Console.WriteLine($"\nTitle:\t\t{Title}\nDescription:\t{Description}\nPrice:\t\t{Price}");
        }
    }
}
