using System.IO;
using System.Text.Json;
public abstract class Transport
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int MaxSpeed { get; set; }

    public Transport(string type, string brand, string model, int year, int maxSpeed)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Year = year;
        MaxSpeed = maxSpeed;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Type: {Type}, Brand: {Brand}, Model: {Model}, Year: {Year}, MaxSpeed: {MaxSpeed}");
    }

    public abstract void Move();
    public abstract string ToCsv();
}

public class Car : Transport
{
    public string FuelType { get; set; }

    public Car(string type, string brand, string model, int year, int maxSpeed, string fuel)
        : base(type, brand, model, year, maxSpeed)
    {
        FuelType = fuel;
    }

    public override void Move()
    {
        Console.WriteLine($"The car {Brand} is moving at the speed of {MaxSpeed} km/h.}}");
    }
    
    public override string ToCsv()
    {
        return $"{Type},{Brand},{Model},{Year},{MaxSpeed},{FuelType}";
    }
}

public class Truck : Transport
{
    
    public int LoadCapacity { get; set; }
    
    public Truck(string type, string brand, string model, int year, int maxSpeed, int loadCapacity)
        : base(type, brand, model, year, maxSpeed)
    {
        LoadCapacity = loadCapacity;
    }
    
    public override void Move()
    {
        Console.WriteLine($"The Truck {Brand} {Model} is moving on the road");
    }
    public override string ToCsv()
    {
        return $"{Type},{Brand},{Model},{Year},{MaxSpeed},{LoadCapacity}";
    }
}

public class Bike : Transport
{
    
    public bool HasSideCar { get; set; }
    
    
    public Bike(string type, string brand, string model, int year, int maxSpeed, bool hasSideCar)
        : base(type, brand, model, year, maxSpeed)
    {
        HasSideCar = hasSideCar;
    }
    
    public override void Move()
    {
        Console.WriteLine($"The Bike {Brand} {Model}is moving on the road");
    }
    
    public override string ToCsv()
    {
        return $"{Type},{Brand},{Model},{Year},{MaxSpeed},{HasSideCar}";
    }
}

public class Bus : Transport
{
    public int PassengersCapacity { get; set; }
    
    public Bus(string type, string brand, string model, int year, int maxSpeed, int passengersCapacity)
        : base(type, brand, model, year, maxSpeed)
    {
        PassengersCapacity = passengersCapacity;
    }
        
    public override void Move()
    {
        Console.WriteLine($"The Bus {Brand} {Model}is moving on the road");
    }
    public override string ToCsv()
    {
        return $"{Type},{Brand},{Model},{Year},{MaxSpeed},{PassengersCapacity}";
    }
}

public class Program
{
    public static void Main()
    {
        string filePath = "Transports.txt";

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        
        
        
        List<Transport> transports = new List<Transport>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields.Length == 6)
                {
                    string type = fields[0];
                    string brand = fields[1];
                    string model = fields[2];
                    int year = int.Parse(fields[3]);
                    int maxSpeed = int.Parse(fields[4]);

                    if (type == "Car")
                    {
                        string fuelType = fields[5];
                        transports.Add(new Car(type, brand, model, year, maxSpeed, fuelType));
                    }
                    else if (type == "Truck")
                    {
                        int loadCapacity = int.Parse(fields[5]);
                        transports.Add(new Truck(type, brand, model, year, maxSpeed, loadCapacity));
                    }
                    else if (type == "Bike")
                    {
                        bool hasSideCar = bool.Parse(fields[5]);
                        transports.Add(new Bike(type, brand, model, year, maxSpeed, hasSideCar));
                    }
                    else if (type == "Bus")
                    {
                        int passengersCapacity = int.Parse(fields[5]);
                        transports.Add(new Bus(type, brand, model, year, maxSpeed, passengersCapacity));
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }

        transports.ToArray();
        
        
        Console.WriteLine("Welcome to the Cars Salon!");
        bool is_running = true;
        while (is_running)
        {
            Console.WriteLine("Make a choice:\n1)Add new Transport\n2)Delete Transport\n3)Launch Transport\n4)Display Transport\n5)Filter\n6)Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Type of the Transport:");
                    Console.WriteLine("1)Car");
                    Console.WriteLine("2)Truck");
                    Console.WriteLine("3)Bike");
                    Console.WriteLine("4)Bus");
                    int choice2 = int.Parse(Console.ReadLine());
                    string type;
                    string brand;
                    string model;
                    int year;
                    int maxSpeed;
                    int passengersCapacity;
                    bool HasSideCar;
                    int loadCapacity;
                    string fuel;
                    
                    switch (choice2)
                    {
                        case 1:
                            type = "Car";
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine(); 
                            Console.WriteLine("Model of the Transport:"); 
                            model = Console.ReadLine();

                            while (true)
                            {
                                Console.WriteLine("Year of the Transport:"); 
                                year = int.Parse(Console.ReadLine());
                                if (year < 1886 || year > DateTime.Now.Year)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            while (true)
                            {
                                Console.WriteLine("Max speed of the Transport:");
                                maxSpeed = int.Parse(Console.ReadLine());
                                if (maxSpeed < 0)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            Console.WriteLine("Fuel of the Transport:"); 
                            fuel = Console.ReadLine();
                            Car car = new Car(type, brand, model, year, maxSpeed, fuel);
                            transports.Add(car);
                            Console.WriteLine("Car added!");
                            break;
                        case 2:
                            type = "Truck";
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine(); 
                            Console.WriteLine("Model of the Transport:"); 
                            model = Console.ReadLine();
                            while (true)
                            {
                                Console.WriteLine("Year of the Transport:"); 
                                year = int.Parse(Console.ReadLine());
                                if (year < 1886 || year > DateTime.Now.Year)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            while (true)
                            {
                                Console.WriteLine("Max speed of the Transport:");
                                maxSpeed = int.Parse(Console.ReadLine());
                                if (maxSpeed < 0)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }

                            while (true)
                            {
                                Console.WriteLine("Load capacity of the Transport:");
                                loadCapacity = int.Parse(Console.ReadLine());
                                if (loadCapacity < 0)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            Truck truck = new Truck(type, brand, model, year, maxSpeed, loadCapacity);
                            transports.Add(truck);
                            Console.WriteLine("Truck added!");
                            break;
                        case 3:
                            type = "Bike";
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine(); 
                            Console.WriteLine("Model of the Transport:"); 
                            model = Console.ReadLine();
                            while (true)
                            {
                                Console.WriteLine("Year of the Transport:"); 
                                year = int.Parse(Console.ReadLine());
                                if (year < 1885 || year > DateTime.Now.Year)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            while (true)
                            {
                                Console.WriteLine("Max speed of the Transport:");
                                maxSpeed = int.Parse(Console.ReadLine());
                                if (maxSpeed < 0)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            while (true)
                            {
                                Console.WriteLine("Has side car of the Transport(1/0):");
                                int temp = int.Parse(Console.ReadLine());
                                if (temp == 0 || temp == 1)
                                {
                                    HasSideCar = (temp == 1) ? true : false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Type again!");
                                }
                            }
                            
                            Bike bike = new(type, brand, model, year, maxSpeed, HasSideCar);
                            transports.Add(bike);
                            Console.WriteLine("Bike added!");
                            break;
                        case 4:
                            type = "Bus";
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine();
                            Console.WriteLine("Model of the Transport:");
                            model = Console.ReadLine();
                            while (true)
                            {
                                Console.WriteLine("Year of the Transport:"); 
                                year = int.Parse(Console.ReadLine());
                                if (year < 1886 || year > DateTime.Now.Year)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            while (true)
                            {
                                Console.WriteLine("Max speed of the Transport:");
                                maxSpeed = int.Parse(Console.ReadLine());
                                if (maxSpeed < 0)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }

                            while (true)
                            {
                                Console.WriteLine("Passenger capacity of the Transport:");
                                passengersCapacity = int.Parse(Console.ReadLine());
                                if (passengersCapacity < 0)
                                {
                                    Console.WriteLine("Type again!");
                                }
                                else break;
                            }
                            Bus bus = new Bus(type, brand, model, year, maxSpeed, passengersCapacity);
                            transports.Add(bus);
                            Console.WriteLine("Bus added!");
                            break;
                        default:
                            Console.WriteLine("Type again!");
                            break;
                    }

                    break;
                case 2:
                    if (transports.Count <= 0)
                    {
                        Console.WriteLine("There are no transports yet!");
                        continue;
                    }
                    int counter = 0;
                    for (int i = 0; i < transports.Count; i++)
                    {
                        Console.WriteLine($"Transport {++counter}");
                        if (transports[i] is Car)
                        {
                            ((Car)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Truck)
                        {
                            ((Truck)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Bike)
                        {
                            ((Bike)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Bus)
                        {
                            ((Bus)transports[i]).ShowInfo();
                        }
                    }

                    int choice3;
                    while (true)
                    {
                        Console.WriteLine("Choose a transport:");
                        choice3 = int.Parse(Console.ReadLine());
                        if (choice3 == 0 || choice3 > transports.Count)
                        {
                            Console.WriteLine("Incorrect input!");
                        }
                        else break;
                    }

                    transports.RemoveAt(choice3 - 1);
                    Console.WriteLine("Transport removed!");
                    break;
                case 3:
                    if (transports.Count <= 0)
                    {
                        Console.WriteLine("There are no transports yet!");
                        continue;
                    }
                    Console.WriteLine("Choose a transport:");
                    counter = 0;
                    for (int i = 0; i < transports.Count; i++)
                    {
                        Console.WriteLine($"Transport {++counter}");
                        if (transports[i] is Car)
                        {
                            ((Car)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Truck)
                        {
                            ((Truck)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Bike)
                        {
                            ((Bike)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Bus)
                        {
                            ((Bus)transports[i]).ShowInfo();
                        }
                    }
                    
                    int choice4;
                    while (true)
                    {
                        Console.WriteLine("Choose a transport:");
                        choice4 = int.Parse(Console.ReadLine());
                        if (choice4 <= 0 || choice4 > transports.Count)
                        {
                            Console.WriteLine("Incorrect input!");
                        }
                        else break;
                    }

                    choice4--;
                    if (transports[choice4] is Car)
                    {
                        ((Car)transports[choice4]).Move();
                    }
                    else if (transports[choice4] is Truck)
                    {
                        ((Truck)transports[choice4]).Move();
                    }
                    else if (transports[choice4] is Bike)
                    {
                        ((Bike)transports[choice4]).Move();
                    }
                    else if (transports[choice4] is Bus)
                    {
                        ((Bus)transports[choice4]).Move();
                    }
                    break;
                case 4:
                    if (transports.Count <= 0)
                    {
                        Console.WriteLine("There are no transports yet!");
                        continue;
                    }
                    counter = 0;
                    for (int i = 0; i < transports.Count; i++)
                    {
                        Console.WriteLine($"Transport {++counter}");
                        if (transports[i] is Car)
                        {
                            ((Car)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Truck)
                        {
                            ((Truck)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Bike)
                        {
                            ((Bike)transports[i]).ShowInfo();
                        }
                        else if (transports[i] is Bus)
                        {
                            ((Bus)transports[i]).ShowInfo();
                        }
                    }

                    break;
                case 5:
                    if (transports.Count <= 0)
                    {
                        Console.WriteLine("There are no transports yet!");
                        continue;
                    }
                    Console.WriteLine("Choose the filter type:");
                    Console.WriteLine("1 - All");
                    Console.WriteLine("2 - Car");
                    Console.WriteLine("3 - Truck");
                    Console.WriteLine("4 - Bike");
                    Console.WriteLine("5 - Bus");
                    int filter = int.Parse(Console.ReadLine());

                    switch (filter)
                    {
                        case 1:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                if (transports[i] is Car)
                                {
                                    ((Car)transports[i]).ShowInfo();
                                }
                                else if (transports[i] is Truck)
                                {
                                    ((Truck)transports[i]).ShowInfo();
                                }
                                else if (transports[i] is Bike)
                                {
                                    ((Bike)transports[i]).ShowInfo();
                                }
                                else if (transports[i] is Bus)
                                {
                                    ((Bus)transports[i]).ShowInfo();
                                }
                            }
                            break;
                        case 2:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                if (transports[i] is Car)
                                {
                                    Console.WriteLine($"Transport {++counter}");
                                    ((Car)transports[i]).ShowInfo();
                                }
                            }

                            if (counter == 0)
                            {
                                Console.WriteLine("There are no Cars yet!");
                            }
                            break;
                        case 3:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                if (transports[i] is Truck)
                                {
                                    Console.WriteLine($"Transport {++counter}");
                                    ((Truck)transports[i]).ShowInfo();
                                }
                            }
                            if (counter == 0)
                            {
                                Console.WriteLine("There are no Trucks yet!");
                            }

                            break;
                        case 4:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                if (transports[i] is Bike)
                                {
                                    Console.WriteLine($"Transport {++counter}");
                                    ((Bike)transports[i]).ShowInfo();
                                }
                            }
                            if (counter == 0)
                            {
                                Console.WriteLine("There are no MotoBikes yet!");
                            }
                            break;
                        case 5:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                if (transports[i] is Bus)
                                {
                                    Console.WriteLine($"Transport {++counter}");
                                    ((Bus)transports[i]).ShowInfo();
                                }
                            }
                            if (counter == 0)
                            {
                                Console.WriteLine("There are no Buses yet!");
                            }
                            break;
                        default:
                            Console.WriteLine("Incorrect input!");
                            break;
                    }
                    break;
                case 6:
                    
                    using (StreamWriter writer = new StreamWriter(filePath, false)) // 'false' overwrites the file
                    {
                        foreach (Transport transport in transports)
                        {
                            writer.WriteLine(transport.ToCsv());
                        }
                    }
                    
                    Console.WriteLine("Bye!");
                    is_running = false;
                    break;
            }
        }
    }
}
