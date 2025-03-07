using System;
using System.Text.RegularExpressions;

namespace StudentController
{
    class StudentValidator
    {
        // Kiểm tra tên (phải có ít nhất 2 ký tự, không chứa số hoặc ký tự đặc biệt)
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[A-Za-zÀ-Ỹà-ỹ\s]{2,}$");
        }

        // Kiểm tra tuổi (chỉ chấp nhận từ 18 đến 100)
        public static bool IsValidAge(int age)
        {
            return age >= 18 && age <= 100;
        }

        // Kiểm tra ID (3 chữ cái in hoa + 3 số)
        public static bool IsValidId(string id)
        {
            return Regex.IsMatch(id, @"^[A-Z]{3}\d{2}$");
        }

        // Kiểm tra Email hợp lệ
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w+$");
        }
    }
}
