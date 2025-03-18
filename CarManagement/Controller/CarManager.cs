using System;
using System.Collections.Generic;
using System.Linq;
using CarManagement.Interface;
using CarManagement.Abstract;
using CarManagement.Validate;

namespace CarManagement.Controller
{
    class CarManager : ICarManagement
    {
        private List<Car> cars = new List<Car>();
        
        public void AddCar()
        {
            Console.Write("Nhập ID: ");
            int id = InputValidator.ValidateIntInput();
            Console.Write("Nhập tên xe: ");
            string name = InputValidator.ValidateStringInput();
            Console.Write("Nhập hãng xe: ");
            string brand = InputValidator.ValidateStringInput();
            Console.Write("Nhập giá: ");
            double price = InputValidator.ValidateDoubleInput();
            Console.Write("Nhập số lượng: ");
            int quantity = InputValidator.ValidateIntInput();
            
            cars.Add(new Car { ID = id, Name = name, Brand = brand, Price = price, Quantity = quantity });
            Console.WriteLine("Xe đã được thêm thành công!");
        }
        
        public void DisplayCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("Danh sách xe hơi trống!");
                return;
            }
            Console.WriteLine("\nDanh sách xe hơi:");
            foreach (var car in cars)
            {
                car.DisplayInfo();
            }
        }
        
        public void SearchCar()
        {
            Console.Write("Nhập tên xe cần tìm: ");
            string name = Console.ReadLine();
            var results = cars.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            
            if (results.Count == 0)
            {
                Console.WriteLine("Không tìm thấy xe!");
            }
            else
            {
                Console.WriteLine("\nKết quả tìm kiếm:");
                foreach (var car in results)
                {
                    car.DisplayInfo();
                }
            }
        }
        
        public void RemoveCar()
        {
            Console.Write("Nhập ID xe cần xóa: ");
            int id = InputValidator.ValidateIntInput();
            var car = cars.FirstOrDefault(c => c.ID == id);
            
            if (car != null)
            {
                cars.Remove(car);
                Console.WriteLine("Xe đã được xóa!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy xe!");
            }
        }
        
        public void SortCarsByPrice()
        {
            cars = cars.OrderBy(c => c.Price).ToList();
            Console.WriteLine("Danh sách xe đã được sắp xếp theo giá tăng dần!");
        }
        
        public void UpdateCar()
        {
            Console.Write("Nhập ID xe cần sửa: ");
            int id = InputValidator.ValidateIntInput();
            var car = cars.FirstOrDefault(c => c.ID == id);
            
            if (car != null)
            {
                Console.Write("Nhập tên mới: ");
                car.Name = InputValidator.ValidateStringInput();
                Console.Write("Nhập hãng mới: ");
                car.Brand = InputValidator.ValidateStringInput();
                Console.Write("Nhập giá mới: ");
                car.Price = InputValidator.ValidateDoubleInput();
                Console.Write("Nhập số lượng mới: ");
                car.Quantity = InputValidator.ValidateIntInput();
                Console.WriteLine("Thông tin xe đã được cập nhật!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy xe!");
            }
        }
    }
}
