public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year{ get; set; }


    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"\"{Title}\" - {Author} ({Year})";
    }
}


class TestClass
{
    static void Main(string[] args)
    {
        
        List<Book> books = new List<Book>();
        bool is_running = true;
        while (is_running)
        {
            Console.WriteLine("Welcome to the library:\nChoose an operation:\n1)Add Book\n2)Remove Book\n3)Show All Books\n4)Exit");
            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    string title;
                    string author;
                    int year;
                    Console.WriteLine($"Your choice: {choice}");
                    Console.WriteLine("Enter the Title of the book:");
                    title = Console.ReadLine();
                    Console.WriteLine("Enter the Author of the book:");
                    author = Console.ReadLine();
                    Console.WriteLine("Enter the Year of the book:");
                    year = int.Parse(Console.ReadLine());
                    Book book_new = new(title, author, year);
                    books.Add(book_new);
                    Console.WriteLine("Book added");
                    break;
                case 2:
                    Console.WriteLine($"Your choice: {choice}");
                    Console.WriteLine("All books:");
                    int counter_new = 0;
                    foreach (var book in books)
                    {
                        Console.Write($"Book {++counter_new}   ");
                        Console.WriteLine(book.ToString());
                    }

                    if (books.Count == 0)
                    {
                        Console.WriteLine("There are no books");
                        break;
                    }

                    Console.WriteLine("Enter the number of the book: ");
                    int new_index;
                    while (true)
                    {
                        new_index = int.Parse(Console.ReadLine());
                        if (new_index == 0 || new_index > books.Count)
                        {
                            Console.WriteLine("Incorrect");
                        }
                        else break;
                    }
                    books.RemoveAt(new_index-1);
                    Console.WriteLine("Book removed");
                    break;
                case 3:
                    if (books.Count == 0)
                    {
                        Console.WriteLine("There are no books");
                        break;
                    }

                    Console.WriteLine("All books:");
                    int counter = 0;
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Book {++counter}");
                        Console.WriteLine(book.ToString());
                    }
                    break;
                case 4:
                    Console.WriteLine("BYE!");
                    is_running = false;
                    break;
            }
        }
    }
}