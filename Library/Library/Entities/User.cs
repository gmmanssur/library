namespace Library.Entities
{
    public sealed record class User
    {
        private Guid IdUser { get; } = Guid.Empty;
        private string Name { get; } = string.Empty;

        private User(Guid idUser, string name)
        {
            IdUser = idUser;
            Name = name;
        }

        private static readonly List<User> Users = [];

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
            Console.WriteLine("Registering a new user...");

            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Users.Add(new User(Guid.NewGuid(), name));
            
            Console.WriteLine($"User registered successfully!\n");
        }

        private static void ShowRegisteredUsers()
        {
            Users.Select(x => x.Name)
                .ToList()
                .ForEach(name => Console.Write(name + "\n"));
        }
    }
}
