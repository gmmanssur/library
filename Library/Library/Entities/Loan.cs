namespace Library.Entities
{
    public sealed record class Loan
    {
        private Guid Id { get; init; } = Guid.Empty;
        private Guid BookId { get; init; } = Guid.Empty;
        private Guid UserId { get; init; } = Guid.Empty;
        private DateTime LoanDate { get; init; } = DateTime.Now;
        private DateTime? ReturnDate { get; set; } = null;
        private static readonly List<Loan> Loans = [];

        private Loan(Guid id, Guid bookId, Guid userId, DateTime loanDate, DateTime? returnDate = null)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public static void ShowLoanMenu()
        {
            Console.WriteLine("Loan Menu:");
            Console.WriteLine("1 - Create Loan");
            Console.WriteLine("2 - Return Book");
            Console.WriteLine("3 - View Loan Details");
            Console.WriteLine("0 - Back to Main Menu");

            string option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1":
                    CreateLoan();
                    break;
                case "2":
                    ShowLoanBooks();
                    break;
                case "3":
                    ReturnBook();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option! Try again.\n");
                    ShowLoanMenu();
                    break;
            }
        }

        private static void CreateLoan()
        {
            Console.WriteLine("Creating a new loan...");
        }

        private static void ShowLoanBooks()
        {
            Console.WriteLine("Showing loaned books...");
        }

        private static void ReturnBook()
        {
            Console.WriteLine("Returning a book...");
        }
    }
}
