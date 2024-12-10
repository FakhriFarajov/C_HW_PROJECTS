using System.Runtime.CompilerServices;
#region a
enum FuelType { DIESEL, GASOLINE, ELECTRICAL };
enum StructureType {SEDAN, SUV ,SPORT};

class Transport
{
    private string _brand;
    private string _model;
    private FuelType _fuelType;
    private StructureType _structureType;
    
    
    public Transport(string brand, string model,FuelType fuelType, StructureType structureType)
    {
        _brand = brand;
        _model = model;
        _fuelType = fuelType;
        _structureType = structureType;
    }
    
    public void setBrand(string brand)
    {
        _brand = brand;
    }

    public void setModel(string model)
    {
        _model = model;
    }

    public void setFuelType(FuelType fuelType)
    {
        _fuelType = fuelType;
    }

    public void setStructureType(StructureType structureType)
    {
        _structureType = structureType;
    }

    public string getBrand()
    {
        return _brand;
    }

    public string getModel()
    {
        return _model;
    }
    
    public FuelType getFuelType()
    {
        return _fuelType;
    }

    public StructureType getStructureType()
    {
        return _structureType;
    }
    
    public virtual void getInfo()
    {
        Console.WriteLine($"Brand: {_brand}");
        Console.WriteLine($"Model: {_model}");
        Console.WriteLine($"FuelType: {_fuelType}");
        Console.WriteLine($"StructureType: {_structureType}");
    }
    
}

class Car : Transport
{
    private string _color;
    
    public Car(string color,string brand, string model, FuelType fuelType, StructureType structureType)
        : base(brand, model, fuelType, structureType)
    {
        _color = color;
    }

    public void setColor(string color)
    {
        _color = color;
    }

    public string getColor()
    {
        return _color;
    }

    public override void getInfo()
    {
        base.getInfo();
        Console.WriteLine($"Color: {_color}");
    }
}

class Bus : Transport
{
    private int _passengers_capacity;
    
    public Bus(int passengers_capacity,string brand, string model, FuelType fuelType, StructureType structureType)
        : base(brand, model, fuelType, structureType)
    {
        _passengers_capacity = passengers_capacity;
    }

    public void setPassengers_capacity(int passengers_capacity)
    {
        _passengers_capacity = passengers_capacity;
    }

    public int getPassengers_capacity()
    {
        return _passengers_capacity;
    }

    public override void getInfo()
    {
        base.getInfo();
        Console.WriteLine($"Color: {_passengers_capacity}");
    }
}


class Program
{
    public static void Main()
    {
        int curr = 0;
        Transport[] array_trasnports = new Transport[200];
        string color;
        string brand;
        string model;
        int fuelType;
        int transport_type;
        int passengers_capacity;


        bool is_running = true;

        
        while (is_running)
        {
            int choice;
            Console.Write("Make a choice:\n1)Create a Car\n2)Create a Bus\n3)Delete a transport\n4)Change a transport\n5)Display all the transports\n6)Exit\nChoice:");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Type the color:");
                    color = Console.ReadLine();
                    Console.WriteLine("Type the brand:");
                    brand = Console.ReadLine();
                    Console.WriteLine("Type the model:");
                    model = Console.ReadLine();
                    Console.WriteLine("Choice the fuel type:\n1)DIESEL\n2)GASOLINE\n3)ELECTRICAL\nChoice:");
                    fuelType = int.Parse(Console.ReadLine());
                    Console.WriteLine("Choice the transport type:\n1)Sedan\n2)SUV\n3)SPORT\nChoice:");
                    transport_type = int.Parse(Console.ReadLine());
                    Car car_temp = new Car(color,brand,model,(FuelType)fuelType,(StructureType)transport_type);
                    array_trasnports[curr] = car_temp;
                    curr++;
                    Console.WriteLine("The new Car was added to the transports list.");
                    break;
                case 2:
                    Console.WriteLine("Type the passengers capacity:");
                    passengers_capacity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Type the brand:");
                    brand = Console.ReadLine();
                    Console.WriteLine("Type the model:");
                    model = Console.ReadLine();
                    Console.WriteLine("Choice the fuel type:\n1)DIESEL\n2)GASOLINE\n3)ELECTRICAL\nChoice:");
                    fuelType = int.Parse(Console.ReadLine());
                    Console.WriteLine("Choice the transport type:\n1)Sedan\n2)SUV\n3)SPORT\nChoice:");
                    transport_type = int.Parse(Console.ReadLine());
                    Bus bus_temp = new Bus(passengers_capacity,brand,model,(FuelType)fuelType,(StructureType)transport_type);
                    array_trasnports[curr] = bus_temp;
                    curr++;
                    Console.WriteLine("The new Bus was added to the transports list.");
                    break;
                case 3:
                    if (curr == 0)
                    {
                        Console.WriteLine("The list is empty.");
                        break;
                    }
                    int counter1 = 0;
                    for (int i = 0; i < curr+1; i++)
                    {
                        if (array_trasnports[i] is Car)
                        {
                            counter1++;
                            Console.WriteLine($"Transport {counter1}:");
                            array_trasnports[i].getInfo();
                        }
                        else if (array_trasnports[i] is Bus)
                        {
                            counter1++;
                            Console.WriteLine($"Transport {counter1}:");
                            array_trasnports[i].getInfo();
                        }
                    }
                    Console.WriteLine($"Make a choice to delete a transport: ");
                    int user_choice;
                    while (true)
                    {
                        user_choice = int.Parse(Console.ReadLine());
                        if (choice < 0 || user_choice > curr)
                        {
                            Console.WriteLine("Incorrect choice, please try again.");
                        }
                        else break;
                    }
                    for (int i = user_choice-1; i < curr; i++)
                    {
                        array_trasnports[i] = array_trasnports[i+1];
                    }
                    curr--;

                    Console.WriteLine("The transport was deleted from the transports list.");
                    break;
                case 4:
                    if (curr == 0)
                    {
                        Console.WriteLine("The list is empty.");
                        break;
                    }
                    int counter2 = 0;
                    for (int i = 0; i < curr+1; i++)
                    {
                        if (array_trasnports[i] is Car)
                        {
                            counter2++;
                            Console.WriteLine($"Transport {counter2}:");
                            array_trasnports[i].getInfo();
                        }
                        else if (array_trasnports[i] is Bus)
                        {
                            counter2++;
                            Console.WriteLine($"Transport {counter2}:");
                            array_trasnports[i].getInfo();
                        }
                    }
                    Console.WriteLine($"Make a choice to delete a transport: ");
                    int user_choice1;
                    while (true)
                    {
                        user_choice1 = int.Parse(Console.ReadLine());
                        if (choice < 0 || user_choice1 > curr)
                        {
                            Console.WriteLine("Incorrect choice, please try again.");
                        }
                        else break;
                    }

                    if (array_trasnports[user_choice1 - 1] is Car)
                    {
                        int user_choice_change;
                        Console.WriteLine("Make a choice about what to change:\n1)Color\n2)Brand\n3)Model\n4)Fuel type\n5)Structure type\nChoice:");
                        user_choice_change = int.Parse(Console.ReadLine());
                        Car car_temp1;
                        switch (user_choice_change)
                        {
                            case 1:
                                Console.WriteLine("Type new color");
                                string color_change = Console.ReadLine();
                                car_temp1 = (Car)array_trasnports[user_choice1 - 1];
                                car_temp1.setColor(color_change);
                                array_trasnports[user_choice1 - 1] = car_temp1;
                                Console.WriteLine("The color is changed!");
                                break;
                            case 2:
                                Console.WriteLine("Type new brand");
                                string brand_change = Console.ReadLine();
                                car_temp1 = (Car)array_trasnports[user_choice1 - 1];
                                car_temp1.setBrand(brand_change);
                                array_trasnports[user_choice1 - 1] = car_temp1;
                                Console.WriteLine("The brand is changed!");
                                break;
                            case 3:
                                Console.WriteLine("Type new model");
                                string model_change = Console.ReadLine();
                                car_temp1 = (Car)array_trasnports[user_choice1 - 1];
                                car_temp1.setModel(model_change);
                                array_trasnports[user_choice1 - 1] = car_temp1;
                                Console.WriteLine("The model is changed!");
                                break;
                            case 4:
                                Console.WriteLine("Choice the fuel type:\n1)DIESEL\n2)GASOLINE\n3)ELECTRICAL\nChoice:");
                                int fuelType_change = int.Parse(Console.ReadLine());
                                car_temp1 = (Car)array_trasnports[user_choice1 - 1];
                                car_temp1.setFuelType((FuelType)fuelType_change);
                                array_trasnports[user_choice1 - 1] = car_temp1;
                                Console.WriteLine("The fuel type is changed!");
                                break;
                            case 5:
                                Console.WriteLine("Choice the transport type:\n1)Sedan\n2)SUV\n3)SPORT\nChoice:");
                                int transport_type_change = int.Parse(Console.ReadLine());
                                car_temp1 = (Car)array_trasnports[user_choice1 - 1];
                                car_temp1.setStructureType((StructureType)transport_type_change);
                                array_trasnports[user_choice1 - 1] = car_temp1;
                                Console.WriteLine("The struct type is changed!");
                                break;
                        }
                    }
                    else if (array_trasnports[user_choice1 - 1] is Bus)
                    {
                        int user_choice_change;
                        Console.WriteLine("Make a choice about what to change:\n1)Color\n2)Brand\n3)Model\n4)Fuel type\n5)Structure type\nChoice:");
                        user_choice_change = int.Parse(Console.ReadLine());
                        Bus bus_temp1;
                        switch (user_choice_change)
                        {
                            case 1:
                                Console.WriteLine("Type new passengers capacity");
                                int capacity_new = int.Parse(Console.ReadLine());
                                bus_temp1 = (Bus)array_trasnports[user_choice1 - 1];
                                bus_temp1.setPassengers_capacity(capacity_new);
                                array_trasnports[user_choice1 - 1] = bus_temp1;
                                Console.WriteLine("The capacity is changed!");
                                break;
                            case 2:
                                Console.WriteLine("Type new brand");
                                string brand_change = Console.ReadLine();
                                bus_temp1 = (Bus)array_trasnports[user_choice1 - 1];
                                bus_temp1.setBrand(brand_change);
                                array_trasnports[user_choice1 - 1] = bus_temp1;
                                Console.WriteLine("The brand is changed!");
                                break;
                            case 3:
                                Console.WriteLine("Type new model");
                                string model_change = Console.ReadLine();
                                bus_temp1 = (Bus)array_trasnports[user_choice1 - 1];
                                bus_temp1.setModel(model_change);
                                array_trasnports[user_choice1 - 1] = bus_temp1;
                                Console.WriteLine("The model is changed!");
                                break;
                            case 4:
                                Console.WriteLine("Choice the fuel type:\n1)DIESEL\n2)GASOLINE\n3)ELECTRICAL\nChoice:");
                                int fuelType_change = int.Parse(Console.ReadLine());
                                bus_temp1 = (Bus)array_trasnports[user_choice1 - 1];
                                bus_temp1.setFuelType((FuelType)fuelType_change);
                                array_trasnports[user_choice1 - 1] = bus_temp1;
                                Console.WriteLine("The fuel type is changed!");
                                break;
                            case 5:
                                Console.WriteLine("Choice the transport type:\n1)Sedan\n2)SUV\n3)SPORT\nChoice:");
                                int transport_type_change = int.Parse(Console.ReadLine());
                                bus_temp1 = (Bus)array_trasnports[user_choice1 - 1];
                                bus_temp1.setStructureType((StructureType)transport_type_change);
                                array_trasnports[user_choice1 - 1] = bus_temp1;
                                Console.WriteLine("The struct type is changed!");
                                break;
                        }
                    }
                    break;
                
                
                case 5:
                    int counter = 0;
                    for (int i = 0; i < curr+1; i++)
                    {
                        if (array_trasnports[i] is Car)
                        {
                            counter++;
                            Console.WriteLine($"Transport {counter}:");
                            array_trasnports[i].getInfo();
                        }
                        else if (array_trasnports[i] is Bus)
                        {
                            counter++;
                            Console.WriteLine($"Transport {counter}:");
                            array_trasnports[i].getInfo();
                        }
                    }
                    break;
                case 6:
                    is_running = false;
                    break;
            }
        }
    }
}
#endregion