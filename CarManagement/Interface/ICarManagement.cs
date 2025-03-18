using System;
using System.Collections.Generic;
using System.Linq;
using CarManagement.Interface;
using CarManagement.Abstract;
using CarManagement.Validate;

namespace CarManagement.Interface
{
    interface ICarManagement
    {
        void AddCar();
        void DisplayCars();
        void SearchCar();
        void RemoveCar();
        void SortCarsByPrice();
        void UpdateCar();
    }
}