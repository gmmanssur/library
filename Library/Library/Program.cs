using Library.Entities;

namespace Library
{
    public class Program
    {
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
                        Book.ShowBookMenu();
                        break;

                    case "2":
                        User.ShowUserMenu();
                        break;

                    case "3":
                        Loan.ShowLoanMenu();
                        break;

                    default:
                        break;
                }
            }            
        }

        private static void Welcome()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Welcome to the Library System!");
            Console.WriteLine("==============================");
        }

        private static string GetUserOption()
        {
            Console.Write(
                "1 - Books\n" +
                "2 - Reader\n" +
                "3 - Loan\n" +
                "0 - Quit\n\n" +
                "Choice an option (0 - 3): ");

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