namespace Library.Entities
{
    public sealed record class Book
    {
        private Guid IdBook { get; } = Guid.Empty;
        private string Title { get; } = string.Empty;
        private string Author { get; } = string.Empty;
        private string PublishedYear { get; } = string.Empty;
        private static readonly List<Book> Books = [];

        private Book(Guid idBook, string title, string author, string publishedYear)
        {
            IdBook = idBook;
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
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
            Console.WriteLine("Registering a new book...");
            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter published year: ");
            string publishedYear = Console.ReadLine() ?? string.Empty;

            Books.Add(new Book(Guid.NewGuid(), title, author, publishedYear));

            Console.WriteLine($"Book '{title}' by {author} ({publishedYear}) registered successfully!\n");
        }

        private static void ShowRegisteredBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("No books registered yet.\n");
                return;
            }

            Console.WriteLine("Showing registered books...");

            foreach(var book in Books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Published Year: {book.PublishedYear}");
            };
        }
    }
}
