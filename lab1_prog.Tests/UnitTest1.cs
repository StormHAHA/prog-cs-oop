using System;
using Xunit;
using lab1_prog.BaseModel;
using lab1_prog.CarModel;

namespace lab1_prog.Tests
{
    public class VehicleTests
    {
        // ==== ТЕСТЫ ДЛЯ BaseVehicle ====

        [Fact]
        public void DefaultConstructor_ShouldSetDefaultValues()
        {
            var vehicle = new BaseVehicle();

            Assert.Equal("Неизвестно", vehicle.VehicleBrand);
            Assert.Equal("Неизвестно", vehicle.VehicleModel);
            Assert.Equal((short)2000, vehicle.VehicleYear);
            Assert.Equal((short)0, vehicle.VehicleMaxSpeed);
            Assert.Equal(0, vehicle.VehiclePrice);
        }

        [Fact]
        public void ParameterizedConstructor_ShouldAssignValues()
        {
            var vehicle = new BaseVehicle("Toyota", "Camry", 2020, 240, 2500000);

            Assert.Equal("Toyota", vehicle.VehicleBrand);
            Assert.Equal("Camry", vehicle.VehicleModel);
            Assert.Equal((short)2020, vehicle.VehicleYear);
            Assert.Equal((short)240, vehicle.VehicleMaxSpeed);
            Assert.Equal(2500000, vehicle.VehiclePrice);
        }

        [Fact]
        public void VehicleBrand_ShouldTrimAndStoreCorrectly()
        {
            var v = new BaseVehicle();
            v.VehicleBrand = "  BMW  ";
            Assert.Equal("BMW", v.VehicleBrand);
        }

        [Fact]
        public void VehicleBrand_ShouldThrow_WhenEmpty()
        {
            var v = new BaseVehicle();
            Assert.Throws<ArgumentException>(() => v.VehicleBrand = " ");
        }

        [Fact]
        public void VehicleYear_ShouldThrow_WhenOutOfRange()
        {
            var v = new BaseVehicle();
            Assert.Throws<ArgumentOutOfRangeException>(() => v.VehicleYear = 1800);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.VehicleYear = (short)(DateTime.Now.Year + 5));
        }

        [Fact]
        public void VehicleMaxSpeed_ShouldThrow_WhenTooHighOrNegative()
        {
            var v = new BaseVehicle();
            Assert.Throws<ArgumentOutOfRangeException>(() => v.VehicleMaxSpeed = -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.VehicleMaxSpeed = 600);
        }

        [Fact]
        public void VehiclePrice_ShouldThrow_WhenInvalid()
        {
            var v = new BaseVehicle();
            Assert.Throws<ArgumentOutOfRangeException>(() => v.VehiclePrice = -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.VehiclePrice = 2_000_000_000);
        }

        [Fact]
        public void Print_ShouldOutputToConsole()
        {
            var v = new BaseVehicle("Ford", "Focus", 2015, 180, 800000);
            using var sw = new System.IO.StringWriter();
            Console.SetOut(sw);

            v.Print();
            var output = sw.ToString();

            Assert.Contains("Ford", output);
            Assert.Contains("Focus", output);
            Assert.Contains("2015", output);
            Assert.Contains("800 000", output); // может быть с неразрывным пробелом
        }

        // ==== ТЕСТЫ ДЛЯ Car ====

        [Fact]
        public void Car_DefaultConstructor_ShouldSetFuelTypeToGasoline()
        {
            var car = new Car();
            Assert.Equal("Бензин", car.FuelType);
        }

        [Theory]
        [InlineData("Бензин")]
        [InlineData("Дизель")]
        [InlineData("Электро")]
        [InlineData("Гибрид")]
        [InlineData("Газ")]
        public void Car_ShouldAcceptValidFuelTypes(string fuel)
        {
            var car = new Car();
            car.FuelType = fuel;
            Assert.Equal(fuel, car.FuelType);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Вода")]
        public void Car_ShouldThrow_OnInvalidFuelType(string invalidFuel)
        {
            var car = new Car();
            Assert.Throws<ArgumentException>(() => car.FuelType = invalidFuel);
        }

        [Fact]
        public void Car_Print_ShouldIncludeFuelType()
        {
            var car = new Car();
            car.VehicleBrand = "Tesla";
            car.VehicleModel = "Model S";
            car.VehicleYear = 2023;
            car.VehicleMaxSpeed = 250;
            car.VehiclePrice = 10_000_000;
            car.FuelType = "Электро";

            using var sw = new System.IO.StringWriter();
            Console.SetOut(sw);

            car.Print();
            var output = sw.ToString();

            Assert.Contains("Tesla", output);
            Assert.Contains("Model S", output);
            Assert.Contains("Электро", output);
        }
    }
}
