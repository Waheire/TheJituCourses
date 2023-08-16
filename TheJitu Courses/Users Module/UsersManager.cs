using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TheJitu_Courses.Users_Module;
using System.IO;
using TheJitu_Courses.Admin_Module;

namespace TheJitu_Courses
{
    public class UsersManager
    {
        
        List<User> users = new List<User> ();

        public static string directory = @"C:\Data\theJituCourses\";
        public static string usersFilePath = "users.txt";
        public static string analyticsFilePath = "analytics.txt";
        public static string coursesFilePath = "course.txt";


        //check for existing users file and directory
        public static void CheckForExistingUserFile()
        {
            string UsersFilePath = $"{directory}{usersFilePath}";
            string AnalyticsFilePath = $"{directory}{analyticsFilePath}";
            string CoursesFilePath = $"{directory}{coursesFilePath}";

            bool existingUsersFileFound = File.Exists(UsersFilePath);
            bool existingAnalyticsFileFound = File.Exists(AnalyticsFilePath);
            bool existingCoursesFileFound = File.Exists(CoursesFilePath);

            //Console.WriteLine(existingFileFound);

            if (existingUsersFileFound && existingAnalyticsFileFound && existingCoursesFileFound)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Files Found: Application is ready");
                Console.ResetColor();
            }
            else
            {
                
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    File.Create(UsersFilePath);
                    File.Create(AnalyticsFilePath);
                    File.Create(CoursesFilePath);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Application is ready to save files.");
                    Console.ResetColor();
                }
            }

        }



        //register user
        internal static void RegisterUser(List<User> users) 
        {
            Console.Write("Enter username: ");
            string registerUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string registerPassword = Console.ReadLine();
           // Console.Write("Enter user role:");
            string registerRole = "User";

            if (users.Exists(t => t.Username == registerUsername && t.Password == registerUsername && t.Role == registerRole))
            {
                Console.WriteLine("User already exists");
            }
            else
            {
                users.Add(new User { Username = registerUsername, Password = registerPassword, Role = registerRole });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User has been successfully registered \n");
                Console.ResetColor();
            }

        }

        //view all users
        internal static void ViewAllUsers(List<User> users)
        {
            for (int i = 0; i < users.Count; i++) 
            {
                users[i].DisplayUserDetails();
            }
        }

      


        //load users
        internal static void LoadUsers(List<User> users)
        {
            string path = $"{directory}{usersFilePath}";
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                string[] parts = line.Split(",");
                if (parts.Length ==3)
                {
                    users.Add(new User
                    {
                        Username = parts[0],
                        Password = parts[1],
                        Role = parts[2]
                    });
                }
            }
        }

        //save users
        internal static void SavaUsers(List<User> users)
        {
            string path = $"{directory}{usersFilePath}";
            StringBuilder sb = new StringBuilder();
            foreach (User user in users)
            {
                sb.Append(user.Username);
                sb.Append(",");
                sb.Append(user.Password);
                sb.Append(",");
                sb.Append(user.Role);
                sb.Append(Environment.NewLine);
            }
            File.WriteAllText(path, sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Users have been successfully saved");
            Console.ResetColor();
        }

        //login user 
        internal static void LoginUser(List<User> users)
        {
            Console.Write("Enter username: ");
            string loginUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string loginPassword = Console.ReadLine();
            Console.Write("Enter user role:");
            string loginRole = Console.ReadLine();

            bool user = users.Exists(t => t.Username == loginUsername && t.Password == loginPassword && t.Role == loginRole);
            if (user && loginRole =="User" ) 
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Console.WriteLine($"Loaded {courses.Count} Course(s) \n \n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("**********************************************");
                Console.WriteLine($"* Welcome {loginUsername}, Select an Action *");
                Console.WriteLine("**********************************************");
                User.ShowUserMenu();
            }

            //check user role
            if (user && loginRole == "Admin")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Console.WriteLine($"Loaded {courses.Count} Course(s) \n \n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("**********************************************");
                Console.WriteLine($"* Welcome {loginUsername}, Select an Action *");
                Console.WriteLine("**********************************************");
                AdminManager.DisplayAdminMenu();
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again");
            }

        }

       





    }
}
