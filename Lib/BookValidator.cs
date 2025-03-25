using System;
using System.Text.RegularExpressions;

namespace LibraryManagement
{
    class BookValidator
    {
        public static bool IsValidId(string id)
        {
            return Regex.IsMatch(id, @"^[A-Z]{3}\d{3}$");
        }

        public static bool IsValidTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title) && title.Length >= 2;
        }

        public static bool IsValidAuthor(string author)
        {
            return Regex.IsMatch(author, @"^[A-Za-zÀ-Ỹà-ỹ\s]{2,}$");
        }

        public static bool IsValidYear(int year)
        {
            return year >= 1900 && year <= 2025;
        }
    }
}
