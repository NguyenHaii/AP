using System;
using CarManagement.Controller;

class Program
{
    static void Main()
    {
        CarManager carManager = new CarManager();
        
        while (true)
        {
            Console.WriteLine("\n===== QUẢN LÝ XE HƠI =====");
            Console.WriteLine("1. Thêm xe");
            Console.WriteLine("2. Hiển thị danh sách xe");
            Console.WriteLine("3. Tìm kiếm xe theo tên");
            Console.WriteLine("4. Xóa xe theo ID");
            Console.WriteLine("5. Sắp xếp xe theo giá tăng dần");
            Console.WriteLine("6. Chỉnh sửa thông tin xe");
            Console.WriteLine("7. Thoát");
            Console.Write("Chọn chức năng: ");
            
            int choice = CarManagement.Validate.InputValidator.ValidateIntInput();
            switch (choice)
            {
                case 1:
                    carManager.AddCar();
                    break;
                case 2:
                    carManager.DisplayCars();
                    break;
                case 3:
                    carManager.SearchCar();
                    break;
                case 4:
                    carManager.RemoveCar();
                    break;
                case 5:
                    carManager.SortCarsByPrice();
                    break;
                case 6:
                    carManager.UpdateCar();
                    break;
                case 7:
                    Console.WriteLine("Thoát chương trình!");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại!");
                    break;
            }
        }
    }
}
