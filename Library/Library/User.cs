namespace Library
{
    public class User
    {
        private string Name { get; }
        private string RegisteredDate { get; } 

        private User(string name, string registeredDate)
        {
            Name = name;
            RegisteredDate = registeredDate;
        }

        private static readonly List<User> Users = [];

        public static void RegisterUser()
        {
            Console.WriteLine("Registering a new user...");

            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Users.Add(new User(name, DateTime.Now.ToString("dd/MM/yyyy")));
            Console.WriteLine($"User registered successfully!\n");
        }

        public static void ShowRegisteredUsers()
        {
            IEnumerable<string> finalUser = from user in Users select user.Name;

            Console.Write(finalUser.ToString() + "\n");
        }
    }
}
