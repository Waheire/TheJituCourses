using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJitu_Courses.Courses_Module;

namespace TheJitu_Courses.Users_Module
{
    internal class User
    {
       public static List<Course> courses = new List<Course>();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        //show user menu
        internal static void ShowUserMenu() {


            Console.WriteLine("1. View All Courses");
            Console.WriteLine("2. Purchase Course");
            Console.WriteLine("3. View My Purchased Courses");
            Console.WriteLine("4. Exit");
            Console.Write("Your selection : ");

            string loggedinUserSelection = Console.ReadLine();

            switch (loggedinUserSelection)
            {
                case "1":
                    CoursesManager.LoadCourses(courses);
                    CoursesManager.ViewAllCourses(courses);
                    break;
                case "2": 
                    Console.WriteLine("Purchase Course"); 
                    break;
                 case "3": 
                    Console.WriteLine("View my Purchased Courses");
                    break;
                case "4": 
                    Environment.Exit(0);
                    break;
                    default: Console.WriteLine("Invalid selection. Please Try again");
                    break;
            }
        }
        internal void DisplayUserDetails()
        {
            Console.WriteLine($"\nUsername:\t{Username}\nPassword:\t{Password}\nRole:\t\t{Role}");
        }


    }

  
}
