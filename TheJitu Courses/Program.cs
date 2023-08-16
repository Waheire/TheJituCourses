
using TheJitu_Courses;
using TheJitu_Courses.Users_Module;
using TheJitu_Courses.Courses_Module;

UsersManager usersManager = new UsersManager();
CoursesManager courseManager = new CoursesManager();

List<User> users = new List<User>();
List<Course> courses = new List<Course>();
UsersManager.LoadUsers(users);
CoursesManager.LoadCourses(courses);
//usersManager.LoadUsers();
//Console.WriteLine();


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("*********************************");
Console.WriteLine("* The Jitu Courses App *");
Console.WriteLine("*********************************");
Console.ForegroundColor = ConsoleColor.White;

string userSelection;
UsersManager.CheckForExistingUserFile();





while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Loaded {users.Count} User(s)");
    Console.WriteLine($"Loaded {courses.Count} Course(s) \n ");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("***********************");
    Console.WriteLine("* Select an Action *");
    Console.WriteLine("***********************");

    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");
    Console.Write("Your selection : ");

    userSelection = Console.ReadLine();

    switch (userSelection)
    {

        case "1":
           UsersManager.RegisterUser(users);
            break;
        case "2":
           UsersManager.LoginUser(users);
            break;
        case "3":
           UsersManager.SavaUsers(users);
           UsersManager.ViewAllUsers(users);
           Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
} 