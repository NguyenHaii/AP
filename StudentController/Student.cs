using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace StudentController
{
    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public List<string> Subjects { get; set; }

        public Student(string id, string name, int age, Gender gender, List<string> subjects)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Subjects = subjects;
        }

        public void Display()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}, Subjects: {string.Join(", ", Subjects)}");
        }
    }
}
