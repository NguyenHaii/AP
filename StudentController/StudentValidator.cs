using System;
using System.Text.RegularExpressions;

namespace StudentController
{
    class StudentValidator
    {
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[A-Za-zÀ-Ỹà-ỹ\s]{2,}$");
        }

        public static bool IsValidAge(int age)
        {
            return age >= 18 && age <= 100;
        }

        public static bool IsValidId(string id)
        {
            return Regex.IsMatch(id, @"^[A-Z]{3}\d{2}$");
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w+$");
        }
    }
}
