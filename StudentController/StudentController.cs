using System;
using System.Collections.Generic;
using System.Text;

namespace StudentController
{
    class StudentController
    {
        private StudentService studentService = new StudentService();

        public void AddStudent()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string id;
            do
            {
                Console.Write("Nhập ID sinh viên (VD: ABC123): ");
                id = Console.ReadLine();
                if (!StudentValidator.IsValidId(id))
                {
                    Console.WriteLine("ID không hợp lệ! ID phải có 3 chữ cái in hoa + 2 số (VD: ABC123).");
                }
            } while (!StudentValidator.IsValidId(id));

            string name;
            do
            {
                Console.Write("Nhập tên sinh viên: ");
                name = Console.ReadLine();
                if (!StudentValidator.IsValidName(name))
                {
                    Console.WriteLine("Tên không hợp lệ! Tên phải có ít nhất 2 ký tự và không chứa số.");
                }
            } while (!StudentValidator.IsValidName(name));

            int age;
            do
            {
                Console.Write("Nhập tuổi sinh viên (18 - 100): ");
                if (!int.TryParse(Console.ReadLine(), out age) || !StudentValidator.IsValidAge(age))
                {
                    Console.WriteLine("Tuổi không hợp lệ! Phải từ 18 đến 100.");
                }
            } while (!StudentValidator.IsValidAge(age));

            string email;
            do
            {
                Console.Write("Nhập email sinh viên: ");
                email = Console.ReadLine();
                if (!StudentValidator.IsValidEmail(email))
                {
                    Console.WriteLine("Email không hợp lệ! Hãy nhập đúng định dạng (VD: example@gmail.com).");
                }
            } while (!StudentValidator.IsValidEmail(email));

            Console.Write("Chọn giới tính (0: Nam, 1: Nữ): ");
            Gender gender = (Gender)int.Parse(Console.ReadLine());

            List<string> subjects = new List<string>();
            while (true)
            {
                DisplaySubjectTable();
                Console.Write("Chọn số môn học (1-6) hoặc nhập 0 để kết thúc: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 6)
                {
                    string selectedSubject = StudentService.GetSubject(choice - 1);
                    if (!subjects.Contains(selectedSubject))
                    {
                        subjects.Add(selectedSubject);
                    }
                    else
                    {
                        Console.WriteLine("Môn học đã được chọn trước đó!");
                    }
                }
                else if (choice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                }
            }

            studentService.AddStudent(new Student(id, name, age, gender, email, subjects));
        }


        public void DisplayStudents()
        {
            studentService.DisplayStudents();
        }

        public void SearchBySubject()
        {
            Console.OutputEncoding = Encoding.UTF8;
            DisplaySubjectTable();
            Console.Write("Chọn số môn học để tìm kiếm: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                studentService.SearchBySubject(choice - 1);
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
            }
        }

        public void SearchByGender()
        {
            Console.Write("Chọn giới tính để tìm kiếm (0: Nam, 1: Nữ): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 0 || choice == 1))
            {
                studentService.SearchByGender((Gender)choice);
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ!");
            }
        }

        private void DisplaySubjectTable()
        {
            Console.WriteLine("\n+----+------------+");
            Console.WriteLine("| STT | Môn học   |");
            Console.WriteLine("+----+------------+");
            for (int i = 0; i < StudentService.SubjectCount; i++)
            {
                Console.WriteLine($"| {i + 1,2} | {StudentService.GetSubject(i),-10} |");
            }
            Console.WriteLine("+----+------------+");
        }
    }
}
