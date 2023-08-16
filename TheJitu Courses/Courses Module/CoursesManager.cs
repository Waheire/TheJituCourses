using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJitu_Courses.Courses_Module;
using TheJitu_Courses.Admin_Module;


namespace TheJitu_Courses
{
    internal class CoursesManager
    {

        public static string directory = @"C:\Data\theJituCourses\";
        public static string coursesFilePath = "course.txt";
       
        

        List<Course> courses = new List<Course>();
        //{
            //new Course() { Id=1, Title="C#", Description="Full Stack Development", Price=50000},
            //new Course() { Id=2, Title="JavaScript", Description="Full Stack Development", Price=40000},
            //new Course() { Id=3, Title="QA/QE", Description="Full Stack Development", Price=20000},
            //new Course() { Id=4, Title="WordPress", Description="Full Stack Development", Price=30000},
        //};




        //load users
        //internal static void LoadUsers(List<User> users)
        //{
        //    string path = $"{directory}{usersFilePath}";
        //    string[] lines = File.ReadAllLines(path);
        //    foreach (var line in lines)
        //    {
        //        string[] parts = line.Split(" ");
        //        if (parts.Length == 3)
        //        {
        //            users.Add(new User
        //            {
        //                Username = parts[0],
        //                Password = parts[1],
        //                Role = parts[2]
        //            });
        //        }
        //    }
        //}

        //save courses into courses file
        internal static void SavaCourses(List<Course> courses)
        {
            string path = $"{directory}{coursesFilePath}";
            StringBuilder sb = new StringBuilder();
            foreach (Course course in courses)
            {
                //sb.Append(course.Id);
                //sb.Append(",");
                sb.Append(course.Title);
                sb.Append(",");
                sb.Append(course.Description);
                sb.Append(",");
                sb.Append(course.Price);
                sb.Append(Environment.NewLine);
            }
            File.WriteAllText(path, sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Course has been successfully saved \n");
            Console.ResetColor();
        }

        //load courses
        internal static void LoadCourses(List<Course> courses) 
        {
            string CoursesFileFullPath = $"{directory}{coursesFilePath}";
            string[] lines = File.ReadAllLines(CoursesFileFullPath);
            if (lines.Length == 0)
            {
                //Console.WriteLine("There no Courses Yet");
            }
            else 
            {
               // Console.WriteLine($"Loaded {lines.Length} course(s)");
                foreach (var line in lines)
                {
                    string[] parts = line.Split(",");
                    if (parts.Length == 3)
                    {
                        courses.Add(new Course
                        {
                            Title = parts[0],
                            Description = parts[1],
                            Price = parts[2]
                        });
                    }
                }
            }
             
        }

        //view all courses 
        internal static void ViewAllCourses(List<Course>courses) 
        {
            if (courses.Count < 1)
            {
                Console.WriteLine("There are no courses available\n");
                //Console.WriteLine("Add new Course\n");
               // AdminManager.AddCourse();
            }

            for (int i =0; i < courses.Count; i++ ) 
            {
                courses[i].ShowAllCourses();
            }
        }

        






        //check if course exists
        //add new course 
        //update existing course by ID
        //delete existing course by ID
        //display dashboard for logged in user
        internal static void ShowDashboard() 
        {


        }
        //view all courses for logged in user
        //display courses purchased by logged in user
    }
}
