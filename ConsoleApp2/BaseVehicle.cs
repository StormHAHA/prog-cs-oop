using System;

namespace lab1_prog.BaseModel;

public class BaseVehicle
{
    private string _vehicleBrand;
    private string _vehicleModel;
    private short _vehicleYear;
    private short _vehicleMaxSpeed;
    private int _vehiclePrice;

    public BaseVehicle()
    {
        VehicleBrand = "Неизвестно";
        VehicleModel = "Неизвестно";
        VehicleYear = 2000;
        VehicleMaxSpeed = 0;
        VehiclePrice = 0;
    }

    public BaseVehicle(string brand, string model, short year, short maxSpeed, int price)
    {
        VehicleBrand = brand;
        VehicleModel = model;
        VehicleYear = year;
        VehicleMaxSpeed = maxSpeed;
        VehiclePrice = price;
    }

    public string VehicleBrand
    {
        get => _vehicleBrand;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Марка не может быть пустой или состоять из пробелов");
            if (value.Length > 50)
                throw new ArgumentException("Марка слишком длинная (макс. 50 символов)");
            _vehicleBrand = value.Trim();
        }
    }

    public string VehicleModel
    {
        get => _vehicleModel;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Модель не может быть пустой или состоять из пробелов");
            if (value.Length > 50)
                throw new ArgumentException("Модель слишком длинная (макс. 50 символов)");
            _vehicleModel = value.Trim();
        }
    }

    public short VehicleYear
    {
        get => _vehicleYear;
        set
        {
            int currentYear = DateTime.Now.Year;
            if (value < 1886 || value > currentYear + 1)
                throw new ArgumentOutOfRangeException(nameof(value), $"Год выпуска должен быть в диапазоне 1886–{currentYear + 1}");
            _vehicleYear = value;
        }
    }

    public short VehicleMaxSpeed
    {
        get => _vehicleMaxSpeed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Скорость не может быть ниже нуля км/ч");
            if (value > 500)
                throw new ArgumentOutOfRangeException(nameof(value), "Скорость подозрительно высокая (> 500 км/ч)");
            _vehicleMaxSpeed = value;
        }
    }

    public int VehiclePrice
    {
        get => _vehiclePrice;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Цена не может быть отрицательной");
            if (value > 1_000_000_000)
                throw new ArgumentOutOfRangeException(nameof(value), "Слишком высокая цена");
            _vehiclePrice = value;
        }
    }

    public virtual void Print()
    {
        Console.WriteLine("=== Информация о транспортном средстве ===");
        Console.WriteLine($"Марка: {VehicleBrand}");
        Console.WriteLine($"Модель: {VehicleModel}");
        Console.WriteLine($"Год выпуска: {VehicleYear}");
        Console.WriteLine($"Макс. скорость: {VehicleMaxSpeed} км/ч");
        Console.WriteLine($"Цена: {VehiclePrice:N0} ₽");
        Console.WriteLine("=========================================");
    }
}
