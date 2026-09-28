namespace Library.Entities
{
    public sealed record class User
    {
        public Guid IdUser { get; } = Guid.Empty;
        public string Name { get; } = string.Empty;
        public bool IsAuthorized { get; }

        private User(Guid idUser, string name, bool isAuthorized)
        {
            IdUser = idUser;
            Name = name;
            IsAuthorized = isAuthorized;
        }

        public static readonly List<User> Users = [];

        public static void ShowUserMenu()
        {
            Console.WriteLine("User Menu:");
            Console.WriteLine("1 - Register a new user");
            Console.WriteLine("2 - Show registered users");
            Console.WriteLine("0 - Back to main menu");

            string option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    ShowRegisteredUsers();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option! Try again.\n");
                    ShowUserMenu();
                    break;
            }
        }

        private static void RegisterUser()
        {
            Console.WriteLine("\nRegistering a new user...");

            Console.Write("Enter a name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("This user is admin? (y/n): ");
            bool isAdmin = "y".Equals(Console.ReadLine(), StringComparison.OrdinalIgnoreCase);

            Guid userId = Guid.NewGuid();
            Users.Add(new User(userId, name, isAdmin));

            Console.WriteLine("User registered successfully!\n");
        }

        private static void ShowRegisteredUsers()
        {
            Users.Select(x => x)
                .ToList()
                .ForEach(user => Console.Write($"{user.Name} - {(user.IsAuthorized ? "Admin" : "Regular")}\n"));
        }
    }
}
