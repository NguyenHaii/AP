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
        Console.Write("Nhập ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Nhập tên sản phẩm: ");
        string name = Console.ReadLine();
        Console.Write("Nhập giá: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("Nhập số lượng: ");
        int quantity = int.Parse(Console.ReadLine());
        
        products.Add(new Product { ID = id, Name = name, Price = price, Quantity = quantity });
        Console.WriteLine("Đã thêm sản phẩm thành công!");
    }

    static void DisplayProducts()
    {
        if (products.Count == 0)
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
        string name = Console.ReadLine();
        var results = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        
        if (results.Count == 0)
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
        Console.Write("Nhập ID sản phẩm cần xóa: ");
        int id = int.Parse(Console.ReadLine());
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
        Console.Write("Nhập ID sản phẩm cần sửa: ");
        int id = int.Parse(Console.ReadLine());
        var product = products.FirstOrDefault(p => p.ID == id);
        
        if (product != null)
        {
            Console.Write("Nhập tên mới: ");
            product.Name = Console.ReadLine();
            Console.Write("Nhập giá mới: ");
            product.Price = double.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng mới: ");
            product.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Thông tin sản phẩm đã được cập nhật!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sản phẩm!");
        }
    }
}
