namespace Library.Entities
{
    public sealed class Loan
    {
        public Guid Id { get; } = Guid.NewGuid();

        public User User { get; }

        public Book Book { get; }

        public DateTime LoanDate { get; } = DateTime.Now;

        public DateTime? ReturnDate { get; private set; }

        private static readonly List<Loan> Loans = [];

        public Loan(User user, Book book)
        {
            User = user;
            Book = book;
        }

        public static void ShowLoanMenu()
        {
            Console.WriteLine("Loan Menu:");
            Console.WriteLine("1 - Create Loan");
            Console.WriteLine("2 - Show Loaned Books");
            Console.WriteLine("3 - Return Book");
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
            Console.Write("Enter user name: ");
            string userName = Console.ReadLine() ?? string.Empty;

            User? currentUser = User.Users
                .FirstOrDefault(user =>
                    user.Name.Equals(
                        userName,
                        StringComparison.OrdinalIgnoreCase
                    ));

            if (currentUser is null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            Console.WriteLine("\nAvailable books:");

            Book.ShowAvailableBooks();

            Console.Write("\nChoose a book by title: ");
            string bookTitle = Console.ReadLine() ?? string.Empty;

            Book? selectedBook = Book.Books
                .FirstOrDefault(book =>
                    book.Title.Equals(
                        bookTitle,
                        StringComparison.OrdinalIgnoreCase
                    ));

            if (selectedBook is null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            if (!selectedBook.IsAvailable)
            {
                Console.WriteLine("Book is not available!");
                return;
            }

            Loan newLoan = new(currentUser, selectedBook);

            Loans.Add(newLoan);

            selectedBook.SetAvailability(false);

            Console.WriteLine("\nLoan created successfully!");
            Console.WriteLine($"Book: {selectedBook.Title}");
            Console.WriteLine($"User: {currentUser.Name}");
            Console.WriteLine($"Loan ID: {newLoan.Id}\n");
        }

        private static void ShowLoanBooks()
        {
            Console.WriteLine("Showing loaned books...\n");

            List<Loan> activeLoans = Loans
                .Where(loan => loan.ReturnDate is null)
                .ToList();

            if (activeLoans.Count == 0)
            {
                Console.WriteLine("No active loans found.\n");
                return;
            }

            foreach (Loan loan in activeLoans)
            {
                Console.WriteLine($"ID: {loan.Id}");
                Console.WriteLine($"Book: {loan.Book.Title}");
                Console.WriteLine($"User: {loan.User.Name}");
                Console.WriteLine(
                    $"Loan Date: {loan.LoanDate:dd/MM/yyyy HH:mm}"
                );
                Console.WriteLine();
            }
        }

        private static void ReturnBook()
        {
            Console.WriteLine("Returning a book...\n");

            List<Loan> activeLoans = [.. Loans.Where(loan => loan.ReturnDate is null)];

            if (activeLoans.Count == 0)
            {
                Console.WriteLine("No active loans found.\n");
                return;
            }

            ShowLoanBooks();

            Console.Write("Enter loan ID: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (!Guid.TryParse(input, out Guid loanId))
            {
                Console.WriteLine("Invalid loan ID.");
                return;
            }

            Loan? loan = Loans
                .FirstOrDefault(loan =>
                    loan.Id == loanId &&
                    loan.ReturnDate is null
                );

            if (loan is null)
            {
                Console.WriteLine("Active loan not found.");
                return;
            }

            loan.ChangeReturnBookStatus();

            Console.WriteLine(
                $"\nBook '{loan.Book.Title}' returned successfully!"
            );

            Console.WriteLine($"Returned by: {loan.User.Name}");
            Console.WriteLine(
                $"Return date: {loan.ReturnDate:dd/MM/yyyy HH:mm}\n"
            );
        }

        public void ChangeReturnBookStatus()
        {
            if (ReturnDate is not null)
            {
                return;
            }

            ReturnDate = DateTime.Now;

            Book.SetAvailability(true);
        }
    }
}