using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    class LibraryService
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("✅ Sách đã được thêm thành công!");
        }

        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("📌 Không có sách nào trong thư viện.");
                return;
            }

            Console.WriteLine("\n+----------+--------------------------------+----------------------+-------+");
            Console.WriteLine("| ID       | Tiêu đề                        | Tác giả              | Năm   |");
            Console.WriteLine("+----------+--------------------------------+----------------------+-------+");

            foreach (var book in books)
            {
                book.Display();
            }

            Console.WriteLine("+----------+--------------------------------+----------------------+-------+");
        }

        public void SearchByTitle(string title)
        {
            var foundBooks = books.Where(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (foundBooks.Count == 0)
            {
                Console.WriteLine("❌ Không tìm thấy sách nào với tiêu đề này.");
            }
            else
            {
                Console.WriteLine($"🔎 Kết quả tìm kiếm cho tiêu đề: {title}");
                DisplayBooks();
            }
        }

        public void FilterByAuthor(string author)
        {
            var foundBooks = books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();

            if (foundBooks.Count == 0)
            {
                Console.WriteLine("❌ Không tìm thấy sách nào của tác giả này.");
            }
            else
            {
                Console.WriteLine($"📚 Danh sách sách của tác giả: {author}");
                DisplayBooks();
            }
        }
    }
}
