using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace StudentController
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            StudentController controller = new StudentController();

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhập thông tin sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Tìm kiếm sinh viên theo môn học");
                Console.WriteLine("4. Tìm kiếm sinh viên theo giới tính");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        controller.AddStudent();
                        break;
                    case "2":
                        controller.DisplayStudents();
                        break;
                    case "3":
                        controller.SearchBySubject();
                        break;
                    case "4":
                        controller.SearchByGender();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                        break;
                }
            }
        }
    }
}