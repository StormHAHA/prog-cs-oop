using System;
using lab1_prog.BaseModel;
using lab1_prog.CarModel;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1. Создать транспортное средство");
            Console.WriteLine("2. Создать автомобиль");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            Console.WriteLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        CreateBaseVehicle();
                        break;

                    case "2":
                        CreateCar();
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("Выход из программы...");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    static void CreateBaseVehicle()
    {
        Console.WriteLine("=== Создание транспортного средства ===");
        string brand = AskString("Марка: ");
        string model = AskString("Модель: ");
        short year = AskShort("Год выпуска: ");
        int speed = AskInt("Макс. скорость: ");
        int price = AskInt("Цена: ");
        BaseVehicle vehicle = new BaseVehicle(brand, model, year, (short)speed, price);
        Console.WriteLine("\nТранспортное средство успешно создано!");
        vehicle.Print();
    }

    static void CreateCar()
    {
        Console.WriteLine("=== Создание автомобиля ===");
        string brand = AskString("Марка: ");
        string model = AskString("Модель: ");
        short year = AskShort("Год выпуска: ");
        int speed = AskInt("Макс. скорость: ");
        int price = AskInt("Цена: ");
        string fuel = AskString("Тип топлива (Бензин, Дизель, Электро, Гибрид, Газ): ");

        Car car = new Car(brand, model, year, (short)speed, price, fuel);
        Console.WriteLine("\nАвтомобиль успешно создан!");
        car.Print();
    }

    static string AskString(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? throw new ArgumentException("Значение не может быть пустым") : input;
    }

    static short AskShort(string prompt)
    {
        Console.Write(prompt);
        if (short.TryParse(Console.ReadLine(), out short result))
            return result;
        throw new ArgumentException("Ожидалось целое число (short).");
    }

    static int AskInt(string prompt)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int result))
            return result;
        throw new ArgumentException("Ожидалось целое число (int).");
    }
}
