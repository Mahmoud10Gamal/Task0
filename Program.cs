
namespace Task4
{
    class Library
    {
        public List<Book> books; 

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(string title, string author, int isbn)
        {
            books.Add(new Book(title, author, isbn));
            Console.WriteLine("The book has been added successfully.");
        }

        public bool BorrowBook(int isbn)
        {
            Book book = SearchBook(isbn);
            if (book != null && book.Availability)
            {
                book.Availability = false;
                Console.WriteLine("The book has been successfully borrowed.");
                return true;
            }
            Console.WriteLine("The book is not available.");
            return false;
        }

        public bool ReturnBook(int isbn)
        {
            Book book = SearchBook(isbn);
            if (book != null && !book.Availability)
            {
                book.Availability = true;
                Console.WriteLine("The book has been returned successfully.");
                return true;
            }
            else if (book == null)
            {
                Console.WriteLine("The book is not available in the library.");
            }
            else
            {
                Console.WriteLine("The book was not borrowed.");
            }
            return false;
        }

        public Book SearchBook(int isbn)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == isbn)
                {
                    return books[i];
                }
            }
            return null;
        }
    }

    class Book
    {
        public string Title;
        public string Author;
        public int ISBN;
        public bool Availability;

        public Book(string title, string author, int isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true;
        }
        public string GetTitle()
        { return Title; }
        public string GetAuthor()
        { return Author; }
        public int GetISBN()
        {
            return ISBN;
        }
        public bool GetAvailability()
        { return Availability; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook("The Great Gatsby", "F. Scott Fitzgerald",7804);
            library.AddBook("To Kill a Mockingbird", "Harper Lee", 67890);
            Console.WriteLine("     ");
            Book book = library.SearchBook(67890);
            if (book != null)
            {
                Console.WriteLine($"The book has been found: {book.Title} - {book.Author}");
            }

            library.BorrowBook(7804);
            library.BorrowBook(67892);
            library.ReturnBook(15);
            Console.Write("Enter the book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            Console.Write("Enter ISBN: ");
            int isbn = int.Parse(Console.ReadLine());


            library.AddBook(title, author, isbn);
        }
    }
}
    