using System;

namespace LibraryManagement
{
    class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string id, string title, string author, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
        }

        public void Display()
        {
            Console.WriteLine($"| {Id,-8} | {Title,-30} | {Author,-20} | {Year,-5} |");
        }
    }
}
