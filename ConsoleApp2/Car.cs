using System;
using System.Collections.Generic;
using lab1_prog.BaseModel;

namespace lab1_prog.CarModel;

public class Car : BaseVehicle
{
    private string _fuelType;

    private static readonly HashSet<string> AllowedFuelTypes = new()
    {
        "Бензин",
        "Дизель",
        "Электро",
        "Гибрид",
        "Газ"
    };

    public string FuelType
    {
        get => _fuelType;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Тип топлива не может быть пустым");

            value = value.Trim();

            if (!AllowedFuelTypes.Contains(value))
                throw new ArgumentException($"Недопустимый тип топлива: {value}. Допустимые: {string.Join(", ", AllowedFuelTypes)}");

            _fuelType = value;
        }
    }

    public Car() : base()
    {
        FuelType = "Бензин";
    }

    public Car(string brand, string model, short year, short maxSpeed, int price, string fuelType)
        : base(brand, model, year, maxSpeed, price)
    {
        FuelType = fuelType; // ✅ исправлено
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Тип топлива: {FuelType}");
        Console.WriteLine("-----------------------------------");
    }
}
