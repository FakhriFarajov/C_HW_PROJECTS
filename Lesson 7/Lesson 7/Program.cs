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
        Console.WriteLine($"The Truck {Brand} {Model }is moving on the road");
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
}

public class Program
{
    public static void Main()
    {
        List<Transport> transports = new List<Transport>();
        Console.WriteLine("Welcome to the Cars Salon!");
        bool is_running = true;
        while (is_running)
        {
            Console.WriteLine("Make a choice:\n1)Add new Transport\n2)Delete Transport\n3)Launch Transport\n4)Display Transport\n5)Exit");
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
                            Console.WriteLine("Type of the Transport:");
                            type = Console.ReadLine();
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine(); 
                            Console.WriteLine("Model of the Transport:"); 
                            model = Console.ReadLine();
                            Console.WriteLine("Year of the Transport:"); 
                            year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Max speed of the Transport:");
                            maxSpeed = int.Parse(Console.ReadLine());
                            Console.WriteLine("Fuel of the Transport:"); 
                            fuel = Console.ReadLine();
                            Car car = new Car(type, brand, model, year, maxSpeed, fuel);
                            transports.Add(car);
                            Console.WriteLine("Car added!");
                            break;
                        case 2:
                            Console.WriteLine("Type of the Transport:");
                            type = Console.ReadLine();
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine(); 
                            Console.WriteLine("Model of the Transport:"); 
                            model = Console.ReadLine();
                            Console.WriteLine("Year of the Transport:"); 
                            year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Max speed of the Transport:");
                            maxSpeed = int.Parse(Console.ReadLine());
                            Console.WriteLine("Load capacity of the Transport:");
                            loadCapacity = int.Parse(Console.ReadLine());
                            Truck truck = new Truck(type, brand, model, year, maxSpeed, loadCapacity);
                            transports.Add(truck);
                            Console.WriteLine("Truck added!");
                            break;
                        case 3:
                            Console.WriteLine("Type of the Transport:");
                            type = Console.ReadLine();
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine(); 
                            Console.WriteLine("Model of the Transport:"); 
                            model = Console.ReadLine();
                            Console.WriteLine("Year of the Transport:"); 
                            year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Max speed of the Transport:");
                            maxSpeed = int.Parse(Console.ReadLine());
                            Console.WriteLine("Has side car of the Transport(1/0):");
                            HasSideCar = bool.Parse(Console.ReadLine());
                            Bike bike = new(type, brand, model, year, maxSpeed, HasSideCar);
                            transports.Add(bike);
                            Console.WriteLine("Bike added!");
                            break;
                        case 4:
                            Console.WriteLine("Type of the Transport:");
                            type = Console.ReadLine();
                            Console.WriteLine("Brand of the Transport:");
                            brand = Console.ReadLine();
                            Console.WriteLine("Model of the Transport:");
                            model = Console.ReadLine();
                            Console.WriteLine("Year of the Transport:");
                            year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Max speed of the Transport:");
                            maxSpeed = int.Parse(Console.ReadLine());
                            Console.WriteLine("Passenger capacity of the Transport:");
                            passengersCapacity = int.Parse(Console.ReadLine());
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
                        if (choice3 == 0 || choice3 >= transports.Count)
                        {
                            Console.WriteLine("Incorrect input!");
                        }
                        else break;
                    }

                    transports.RemoveAt(choice3 - 1);
                    Console.WriteLine("Transport removed!");
                    break;
                case 3:
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
                        if (choice4 == 0 || choice4 >= transports.Count)
                        {
                            Console.WriteLine("Incorrect input!");
                        }
                        else break;
                    }
                    for (int i = 0; i < transports.Count; i++)
                    {
                        if (transports[i] is Car)
                        {
                            ((Car)transports[i]).Move();
                        }
                        else if (transports[i] is Truck)
                        {
                            ((Truck)transports[i]).Move();
                        }
                        else if (transports[i] is Bike)
                        {
                            ((Bike)transports[i]).Move();
                        }
                        else if (transports[i] is Bus)
                        {
                            ((Bus)transports[i]).Move();
                        }
                    }
                    break;
                case 4:
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
                        case 2:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                Console.WriteLine($"Transport {++counter}");
                                if (transports[i] is Car)
                                {
                                    ((Car)transports[i]).ShowInfo();
                                }
                            }

                            break;
                        case 3:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                Console.WriteLine($"Transport {++counter}");
                                if (transports[i] is Truck)
                                {
                                    ((Truck)transports[i]).ShowInfo();
                                }
                            }

                            break;
                        case 4:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                Console.WriteLine($"Transport {++counter}");
                                if (transports[i] is Bike)
                                {
                                    ((Bike)transports[i]).ShowInfo();
                                }
                            }
                            break;
                        case 5:
                            counter = 0;
                            for (int i = 0; i < transports.Count; i++)
                            {
                                Console.WriteLine($"Transport {++counter}");
                                if (transports[i] is Bus)
                                {
                                    ((Bus)transports[i]).ShowInfo();
                                }
                            }

                            break;
                        default:
                            Console.WriteLine("Incorrect input!");
                            break;
                    }
                    break;
                case 6:
                    Console.WriteLine("Bye!");
                    is_running = false;
                    break;
            }
        }
    }
}
