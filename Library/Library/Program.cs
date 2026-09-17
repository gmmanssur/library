namespace Library
{
    public class Program
    {
        private readonly Dictionary<int, string> Books = new()
        {
            { 1, "The Great Gatsby" },
            { 2, "To Kill a Mockingbird" },
            { 3, "1984" },
            { 4, "Pride and Prejudice" },
            { 5, "The Catcher in the Rye" }
        };

        public static void Main(string[] args)
        {
            Welcome();

            while (true)
            {
                string option = GetUserOption();

                if("0".Equals(option))
                {
                    Console.WriteLine("Disconnecting...");
                    break;
                }

                if (!ValidateInput(option))
                {
                    Console.WriteLine("Invalid option! Try again.\n");
                    continue;
                }

                switch (option)
                {
                    case "1":
                        User.RegisterUser();
                        break;

                    case "2":
                        User.ShowRegisteredUsers();
                        break;

                    case "3":
                        //LendBook();
                        break;

                    case "4":
                        //ReturnBook();
                        break;

                }
            }            
        }

        private static void Welcome()
            => Console.WriteLine("Welcome to the Library System!\n");

        private static string GetUserOption()
        {
            Console.Write(
                "1 - Register a user\n" +
                "2 - Search Users\n" +
                "3 - Register a book\n" +
                "4 - Lend book\n" +
                "5 - Return book\n" +
                "0 - Desconectar\n\n" +
                "Choice an option (0 - 4): ");

            return Console.ReadLine() ?? string.Empty;
        }

        private static bool ValidateInput(string option)
        {
            return option switch
            {
                "0" => true,
                "1" => true,
                "2" => true,
                "3" => true,
                "4" => true,
                "5" => true,
                _ => false
            };
        }
    }
}