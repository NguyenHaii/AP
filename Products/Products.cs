using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static List<Product> products = new List<Product>();
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nQUẢN LÝ SẢN PHẨM");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm kiếm sản phẩm theo tên");
            Console.WriteLine("4. Xóa sản phẩm theo ID");
            Console.WriteLine("5. Sắp xếp theo giá tăng dần");
            Console.WriteLine("6. Sửa thông tin sản phẩm theo ID");
            Console.WriteLine("7. Thoát");
            Console.Write("Chọn chức năng: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddProduct(); break;
                case "2": DisplayProducts(); break;
                case "3": SearchProduct(); break;
                case "4": RemoveProduct(); break;
                case "5": SortProducts(); break;
                case "6": UpdateProduct(); break;
                case "7": return;
                default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
            }
        }
    }

    static void AddProduct()
    {
        int id = GetValidInt("Nhập ID: ");
        Console.Write("Nhập tên sản phẩm: ");
        string name = Console.ReadLine().Trim();
        double price = GetValidDouble("Nhập giá: ");
        int quantity = GetValidInt("Nhập số lượng: ");
        
        products.Add(new Product { ID = id, Name = name, Price = price, Quantity = quantity });
        Console.WriteLine("Đã thêm sản phẩm thành công!");
    }

    static void DisplayProducts()
    {
        if (!products.Any())
        {
            Console.WriteLine("Danh sách sản phẩm trống!");
            return;
        }
        Console.WriteLine("\nDanh sách sản phẩm:");
        foreach (var p in products)
        {
            Console.WriteLine($"ID: {p.ID}, Tên: {p.Name}, Giá: {p.Price}, Số lượng: {p.Quantity}");
        }
    }

    static void SearchProduct()
    {
        Console.Write("Nhập tên sản phẩm cần tìm: ");
        string name = Console.ReadLine().Trim();
        var results = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        
        if (!results.Any())
        {
            Console.WriteLine("Không tìm thấy sản phẩm!");
        }
        else
        {
            Console.WriteLine("\nKết quả tìm kiếm:");
            foreach (var p in results)
            {
                Console.WriteLine($"ID: {p.ID}, Tên: {p.Name}, Giá: {p.Price}, Số lượng: {p.Quantity}");
            }
        }
    }

    static void RemoveProduct()
    {
        int id = GetValidInt("Nhập ID sản phẩm cần xóa: ");
        var product = products.FirstOrDefault(p => p.ID == id);
        
        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine("Sản phẩm đã được xóa!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sản phẩm!");
        }
    }

    static void SortProducts()
    {
        products = products.OrderBy(p => p.Price).ToList();
        Console.WriteLine("Danh sách đã được sắp xếp theo giá tăng dần!");
    }

    static void UpdateProduct()
    {
        int id = GetValidInt("Nhập ID sản phẩm cần sửa: ");
        var product = products.FirstOrDefault(p => p.ID == id);
        
        if (product != null)
        {
            Console.Write("Nhập tên mới: ");
            product.Name = Console.ReadLine().Trim();
            product.Price = GetValidDouble("Nhập giá mới: ");
            product.Quantity = GetValidInt("Nhập số lượng mới: ");
            Console.WriteLine("Thông tin sản phẩm đã được cập nhật!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sản phẩm!");
        }
    }

    static int GetValidInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                return value;
            Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ!");
        }
    }

    static double GetValidDouble(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                return value;
            Console.WriteLine("Vui lòng nhập một số hợp lệ!");
        }
    }
}


// ﻿using System;
// using System.Text.RegularExpressions;

// namespace StudentController
// {
//     class StudentValidator
//     {
//         public static bool IsValidName(string name)
//         {
//             return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[A-Za-zÀ-Ỹà-ỹ\s]{2,}$");
//         }

//         public static bool IsValidAge(int age)
//         {
//             return age >= 18 && age <= 100;
//         }

//         public static bool IsValidId(string id)
//         {
//             return Regex.IsMatch(id, @"^[A-Z]{3}\d{2}$");
//         }

//         public static bool IsValidEmail(string email)
//         {
//             return Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w+$");
//         }
//     }
// }
