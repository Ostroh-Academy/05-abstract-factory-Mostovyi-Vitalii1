using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            TransportFactory minibusFactory = new MinibusFactory();
            Transport minibus = minibusFactory.createTransport();
            Console.Write("Маршрутка їде:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.WriteLine();
            ((Minibus)minibus).pickUpPassenger();
            Thread.Sleep(1000); 
            ((Minibus)minibus).dropOffPassenger();
            Thread.Sleep(1000);

            Console.WriteLine();


            TransportFactory electricBusFactory = new ElectricBusFactory();

            Transport electricBus = electricBusFactory.createTransport();
 
            Console.Write("Електроавтобус їде:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.WriteLine();

            ((ElectricBus)electricBus).chargeBattery();


            Thread.Sleep(2000); 
            Console.Clear(); 
        }
    }
}




abstract class Transport
{
    public abstract void move();
}

class Minibus : Transport
{
    public override void move()
    {
        Console.WriteLine("Маршрутка їде по маршруту");
    }

    public void pickUpPassenger()
    {
        Console.WriteLine("Збір пасажирів");
    }

    public void dropOffPassenger()
    {
        Console.WriteLine("Висадка пасажирів");
    }
}

class ElectricBus : Transport
{
    public override void move()
    {
        Console.WriteLine("Електроавтобус їде по маршруту");
    }

    public void chargeBattery()
    {
        Console.WriteLine("Зарядка батареї");
    }
}

abstract class TransportFactory
{
    public abstract Transport createTransport();
}

class MinibusFactory : TransportFactory
{
    public override Transport createTransport()
    {
        return new Minibus();
    }
}

class ElectricBusFactory : TransportFactory
{
    public override Transport createTransport()
    {
        return new ElectricBus();
    }
}
