using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentController
{
    class StudentService
    {
        private List<Student> students = new List<Student>();
        private static readonly List<string> subjectList = new List<string> { "Toán", "Lý", "Hóa", "Văn", "Sử", "Địa" };

        public static int SubjectCount => subjectList.Count;
        public static string GetSubject(int index) => subjectList[index];

        public void AddStudent(Student student)
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (string.IsNullOrWhiteSpace(student.Id) || string.IsNullOrWhiteSpace(student.Name) ||
                string.IsNullOrWhiteSpace(student.Email) || student.Subjects.Count == 0)
            {
                Console.WriteLine("Thông tin sinh viên không hợp lệ!");
                return;
            }
            students.Add(student);
            Console.WriteLine("Đã thêm sinh viên thành công!");
        }

        public void DisplayStudents()
        {        
            foreach (var student in students)
            {
                student.Display();
            }
        }

        public void SearchBySubject(int subjectIndex)
        {
            if (subjectIndex < 0 || subjectIndex >= subjectList.Count)
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
                return;
            }

            string subject = subjectList[subjectIndex];
            var filteredStudents = students.Where(s => s.Subjects.Contains(subject)).ToList();

            if (filteredStudents.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sinh viên nào học môn này.");
            }
            else
            {
                Console.WriteLine("\nDanh sách sinh viên học môn " + subject + ":");
                foreach (var student in filteredStudents)
                {
                    student.Display();
                }
            }
        }

        public void SearchByGender(Gender gender)
        {
            var filteredStudents = students.Where(s => s.Gender == gender).ToList();
            if (filteredStudents.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sinh viên nào có giới tính này.");
            }
            else
            {
                Console.WriteLine("\nDanh sách sinh viên giới tính " + gender + ":");
                foreach (var student in filteredStudents)
                {
                    student.Display();
                }
            }
        }
    }
}
