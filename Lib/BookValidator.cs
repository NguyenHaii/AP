using System;
using System.Text.RegularExpressions;

namespace LibraryManagement
{
    class BookValidator
    {
        // Kiểm tra ID sách (3 chữ cái in hoa + 3 số)
        public static bool IsValidId(string id)
        {
            return Regex.IsMatch(id, @"^[A-Z]{3}\d{3}$");
        }

        // Kiểm tra tiêu đề sách (tối thiểu 2 ký tự)
        public static bool IsValidTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title) && title.Length >= 2;
        }

        // Kiểm tra tên tác giả (tối thiểu 2 ký tự, không chứa số)
        public static bool IsValidAuthor(string author)
        {
            return Regex.IsMatch(author, @"^[A-Za-zÀ-Ỹà-ỹ\s]{2,}$");
        }

        // Kiểm tra năm xuất bản (1900 - 2025)
        public static bool IsValidYear(int year)
        {
            return year >= 1900 && year <= 2025;
        }
    }
}
