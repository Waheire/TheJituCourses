using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJitu_Courses.Users_Module;
using TheJitu_Courses.Courses_Module;

namespace TheJitu_Courses.Admin_Module
{
    internal class AdminManager
    {

       static List<Course> courses = new List<Course>();

        //load existing courses
        //change existing user to Admin

        //Display all courses 
        internal static void DisplayAdminMenu() 
        {
           // CoursesManager.LoadCourses(courses);
            Console.WriteLine("1. View All Courses");
            Console.WriteLine("2. Add New Course ");
            Console.WriteLine("3. Delete Course");
            Console.WriteLine("4. Update Course");
            Console.WriteLine("5. View Analytics");
            Console.WriteLine("6. Exit");
            Console.Write("Your selection : ");

            string Selection = Console.ReadLine();

            switch (Selection)
            {
                case "1":
                    CoursesManager.LoadCourses(courses);
                    CoursesManager.ViewAllCourses(courses);
                    break;
                    case "2":
                    Console.WriteLine("Add new Course");
                    AddCourse();
                    break;
                    case "3":
                    Console.WriteLine("Delete course");
                    break;
                    case "4":
                    Console.WriteLine("Update Course");
                    break;
                    case "5":
                    Console.WriteLine("View Analytics");
                    break;
                    case "6":
                    Console.WriteLine("Exit application");
                    Environment.Exit(0);
                    break;
                    default: Console.WriteLine("Invalid, Please Try again");
                    break;
            }
        }

        //Add a new course and save to courses.txt
        internal static void AddCourse()
        {
            Console.Write("Enter course Title: ");
            string courseTitle = Console.ReadLine();
            Console.Write("Enter course Description: ");
            string courseDescription = Console.ReadLine();
            Console.Write("Enter Course Price: ");
            string coursePrice = Console.ReadLine();

            if (courses.Exists(t => t.Title == courseTitle && t.Description == courseDescription && t.Price == coursePrice))
            {
                Console.WriteLine("Course already exists");
            }
            else
            {
                courses.Add(new Course { Title = courseTitle, Description = courseDescription, Price = coursePrice });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Course successfully added");
                Console.ResetColor();
                CoursesManager.SavaCourses(courses);
                AdminManager.DisplayAdminMenu();
            }

        }

        //Delete an existing course
        //Update an existing course
        //View Analytics - show the courses and number of purchases from analytics.txt

    }
}
