using System;
using System.Collections.Generic;
using System.Linq;
using CarManagement.Interface;
using CarManagement.Abstract;
using CarManagement.Validate;

namespace CarManagement.Abstract
{
    abstract class CarBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        
        public abstract void DisplayInfo();
    }
    
    class Car : CarBase
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Tên: {Name}, Hãng: {Brand}, Giá: {Price}, Số lượng: {Quantity}");
        }
    }
}