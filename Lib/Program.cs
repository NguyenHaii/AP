using System;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            LibraryController controller = new LibraryController();

            while (true)
            {
                Console.WriteLine("\n===== 📖 QUẢN LÝ THƯ VIỆN 📖 =====");
                Console.WriteLine("1️: Thêm sách mới");
                Console.WriteLine("2️: Hiển thị danh sách sách");
                Console.WriteLine("3️: Tìm kiếm sách theo tiêu đề");
                Console.WriteLine("4️: Lọc sách theo tác giả");
                Console.WriteLine("0️: Thoát");
                Console.Write("👉 Chọn chức năng: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        controller.AddBook();
                        break;
                    case "2":
                        controller.DisplayBooks();
                        break;
                    case "3":
                        controller.SearchByTitle();
                        break;
                    case "4":
                        controller.FilterByAuthor();
                        break;
                    case "0":
                        Console.WriteLine("🚪 Thoát chương trình...");
                        return;
                    default:
                        Console.WriteLine("❌ Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}
