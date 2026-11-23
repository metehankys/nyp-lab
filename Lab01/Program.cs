using System;
using System.Collections.Generic;

class Motor
{
    public int horsePower { get; set; }
    public Motor(int horsePower)
    {
        if (horsePower < 0)
        {
            throw new ArgumentOutOfRangeException("Horsepower cannot be negative");
        }
        this.horsePower = horsePower;
    }

    public void Calistir() => Console.WriteLine($"Engine works with{horsePower} HP");
}

class Teker
{
    public string Location { get; set; }
    public Teker(string location)
    {
        this.Location = location;
    }
}

class Car
{
    public string Brand { get; set; }
    private readonly Motor motor;
    private readonly List<Teker> tekerler;
    public  Car(string brand,int horsePower)
    {
        this.Brand = brand;
        motor = new Motor(horsePower); // Burada
        foreach (var konum in new[] { "Ön Sol", "Ön Sağ", "Arka Sol", "Arka Sağ" })
            tekerler.Add(new Teker(konum));
    }

    public void Calistir()
    {
        Console.WriteLine($"{Brand} marka araba calistiriliyor.");
        motor.Calistir();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Toyota", 95);
        car1.Calistir();
    }
}