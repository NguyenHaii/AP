using System;

namespace LibraryManagement
{
    class LibraryController
    {
        private LibraryService libraryService = new LibraryService();

        public void AddBook()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string id;
            do
            {
                Console.Write("📌 Nhập ID sách (VD: ABC123): ");
                id = Console.ReadLine();
                if (!BookValidator.IsValidId(id))
                {
                    Console.WriteLine("❌ ID không hợp lệ! (Phải có 3 chữ cái in hoa + 3 số)");
                }
            } while (!BookValidator.IsValidId(id));

            string title;
            do
            {
                Console.Write("📌 Nhập tiêu đề sách: ");
                title = Console.ReadLine();
                if (!BookValidator.IsValidTitle(title))
                {
                    Console.WriteLine("❌ Tiêu đề phải có ít nhất 2 ký tự!");
                }
            } while (!BookValidator.IsValidTitle(title));

            string author;
            do
            {
                Console.Write("📌 Nhập tác giả: ");
                author = Console.ReadLine();
                if (!BookValidator.IsValidAuthor(author))
                {
                    Console.WriteLine("❌ Tên tác giả phải có ít nhất 2 ký tự và không chứa số!");
                }
            } while (!BookValidator.IsValidAuthor(author));

            int year;
            do
            {
                Console.Write("📌 Nhập năm xuất bản (1900 - 2025): ");
                if (!int.TryParse(Console.ReadLine(), out year) || !BookValidator.IsValidYear(year))
                {
                    Console.WriteLine("❌ Năm xuất bản không hợp lệ!");
                }
            } while (!BookValidator.IsValidYear(year));

            libraryService.AddBook(new Book(id, title, author, year));
        }

        public void DisplayBooks()
        {
            libraryService.DisplayBooks();
        }

        public void SearchByTitle()
        {
            Console.Write("🔎 Nhập tiêu đề sách cần tìm: ");
            string title = Console.ReadLine();
            libraryService.SearchByTitle(title);
        }

        public void FilterByAuthor()
        {
            Console.Write("📚 Nhập tên tác giả để lọc sách: ");
            string author = Console.ReadLine();
            libraryService.FilterByAuthor(author);
        }
    }
}
