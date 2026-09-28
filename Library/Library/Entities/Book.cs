
namespace Library.Entities
{
    public sealed record class Book
    {
        public Guid IdBook { get; } = Guid.Empty;
        public string Title { get; }
        public string Author { get; }
        public string PublishedYear { get; }

        public bool IsAvailable { get;   set; } = true;

        public static readonly List<Book> Books = [];

        public static IReadOnlyList<Book> RegisteredBooks => Books;

        private Book(Guid idBook, string title, string author, string publishedYear)
        {
            IdBook = idBook;
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
        }

        public void SetAvailability(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }

        public static void ShowAvailableBooks()
        {
            var availableBooks = Books
                .Where(book => book.IsAvailable)
                .ToList();

            if (availableBooks.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in availableBooks)
            {
                Console.WriteLine(
                    $"Title: {book.Title}, " +
                    $"Author: {book.Author}, " +
                    $"Published Year: {book.PublishedYear}"
                );
            }
        }

        public static void ShowBookMenu()
        {
            Console.WriteLine("Book Menu:");
            Console.WriteLine("1 - Register a new book");
            Console.WriteLine("2 - Show registered books");
            Console.WriteLine("0 - Back to main menu");

            string option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1":
                    RegisterBook();
                    break;
                case "2":
                    ShowRegisteredBooks();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option! Try again.\n");
                    ShowBookMenu();
                    break;
            }
        }

        private static void RegisterBook()
        {
            Console.WriteLine("\nRegistering a new book...");

            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter published year: ");
            string publishedYear = Console.ReadLine() ?? string.Empty;

            Books.Add(new Book(
                Guid.NewGuid(),
                title,
                author,
                publishedYear
            ));

            Console.WriteLine(
                $"Book '{title}' by {author} ({publishedYear}) registered successfully!\n"
            );
        }

        private static void ShowRegisteredBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("No books registered yet.\n");
                return;
            }

            foreach (var book in Books)
            {
                Console.WriteLine(
                    $"Title: {book.Title}, " +
                    $"Author: {book.Author}, " +
                    $"Published Year: {book.PublishedYear}, " +
                    $"Available: {book.IsAvailable}"
                );
            }
        }
    }
}