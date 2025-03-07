using System;
using System.Collections.Generic;
using System.Text;

namespace StudentController
{

    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public List<string> Subjects { get; set; }

        public Student(string id, string name, int age, Gender gender, string email, List<string> subjects)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Email = email;
            Subjects = subjects;
        }

        public void Display()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"| {Id,-5} | {Name,-20} | {Age,-5} | {Gender,-5} | {Email,-25} | {string.Join(", ", Subjects),-30} |");
        }
    }
}
