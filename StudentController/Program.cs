using System;
using System.Collections.Generic;
using System.Linq;

interface IRepository<T>
{
    void Add(T item);
    List<T> GetAll();
    void Update(int id, T item);
    void Delete(int id);
}

class Repository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public void Update(int id, T item)
    {
        var existingItem = _items.FirstOrDefault(x => x.Id == id);
        if (existingItem != null)
        {
            _items[_items.IndexOf(existingItem)] = item;
        }
    }

    public void Delete(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }
}

interface IEntity
{
    int Id { get; set; }
}

class Student : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        IRepository<Student> studentRepo = new Repository<Student>();
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    studentRepo.Add(new Student { Id = id, Name = name, Age = age });
                    break;
                case "2":
                    var students = studentRepo.GetAll();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
                    }
                    break;
                case "3":
                    Console.Write("Enter ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Age: ");
                    int newAge = int.Parse(Console.ReadLine());
                    studentRepo.Update(updateId, new Student { Id = updateId, Name = newName, Age = newAge });
                    break;
                case "4":
                    Console.Write("Enter ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    studentRepo.Delete(deleteId);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
