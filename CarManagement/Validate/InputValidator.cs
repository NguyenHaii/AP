using System;
using System.Collections.Generic;
using System.Linq;
using CarManagement.Interface;
using CarManagement.Abstract;
using CarManagement.Validate;

namespace CarManagement.Validate
{
    class InputValidator
    {
        public static int ValidateIntInput()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write("Giá trị không hợp lệ, vui lòng nhập lại: ");
            }
            return value;
        }

        public static double ValidateDoubleInput()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write("Giá trị không hợp lệ, vui lòng nhập lại: ");
            }
            return value;
        }

        public static string ValidateStringInput()
        {
            string value;
            while (string.IsNullOrWhiteSpace(value = Console.ReadLine()))
            {
                Console.Write("Giá trị không hợp lệ, vui lòng nhập lại: ");
            }
            return value;
        }
    }
}
