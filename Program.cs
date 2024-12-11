public enum FuelType
{
    Petrol,
    Diesel,
    Hybrid
}

public enum BodyType
{
    Sedan,
    Hatchback
}

public abstract class Transport
{
    protected string Make { get; set; }
    protected string Model { get; set; }
    protected int Year { get; set; }
    protected FuelType Fuel { get; set; }

    protected Transport(string make, string model, int year, FuelType fuel)
    {
        Make = make;
        Model = model;
        Year = year;
        Fuel = fuel;
    }

    public abstract void display_info();
}

public class Car : Transport
{
    private BodyType Body { get; set; }

    public Car(string make, string model, int year, FuelType fuel, BodyType body) : base(make, model, year, fuel)
    {
        Body = body;
    }

    public override void display_info()
    {
        Console.WriteLine($"Car: {Year} {Make} {Model}, Fuel: {Fuel}, Body: {Body}");
    }
}

public class Bus : Transport
{
    private int Passengers_Capacity { get; set; }

    public Bus(string make, string model, int year, FuelType fuel, int passengers_capacity) : base(make, model, year, fuel)
    {
        Passengers_Capacity = passengers_capacity;
    }
    
    public override void display_info()
    {
        Console.WriteLine($"Bus: {Year} {Make} {Model}, Fuel: {Fuel}, Capacity: {Passengers_Capacity} passengers");
    }
}

public class FleetManager
{
    private List<Transport> transports = new List<Transport>();  // самый удобный вариант
    
    public void add_transport(Transport transport)
    {
        transports.Add(transport);
        Console.WriteLine("Transport added successfully.");
    }
    
    public void edit_transport(int index, Transport new_transport)
    {
        if (index >= 0 && index < transports.Count)
        {
            transports[index] = new_transport;
            Console.WriteLine("Transport updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
    
    public void remove_transport(int index)
    {
        if (index >= 0 && index < transports.Count)
        {
            transports.RemoveAt(index);
            Console.WriteLine("Transport removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
    
    public void display_fleet()
    {
        if (transports.Count == 0)
        {
            Console.WriteLine("The fleet is empty.");
        }
        else
        {
            for (int i = 0; i < transports.Count; i++)
            {
                Console.Write($"[{i}] ");
                transports[i].display_info();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FleetManager manager = new FleetManager();
        
        manager.add_transport(new Car("Toyota", "Camry", 2022, FuelType.Petrol, BodyType.Sedan));
        manager.add_transport(new Bus("Mercedes", "Sprinter", 2019, FuelType.Diesel, 20));

        // Вывод автопарка
        manager.display_fleet();

        // Редактирование первого элемента
        manager.edit_transport(0, new Car("Honda", "Civic", 2023, FuelType.Hybrid, BodyType.Hatchback));

        // Вывод автопарка
        manager.display_fleet();

        // Удаление второго элемента
        manager.remove_transport(1);

        // Вывод автопарка
        manager.display_fleet();
    }
}