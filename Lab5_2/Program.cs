using System;
using System.Threading;

class TrafficLight
{
    private object _lock = new object(); // об'єкт блокування для синхронізації доступу до стану світлофора
    private string _name;
    private int _state; // 0 - червоний, 1 - жовтий, 2 - зелений

    public TrafficLight(string name)
    {
        _name = name;
        _state = 0; // початковий стан - червоний
    }

    public void ChangeState()
    {
        lock (_lock) // блокуємо доступ до стану світлофора
        {
            if (_state == 0)
            {
                Console.WriteLine($"{_name} світлофор: переключаю на жовтий");
                _state = 1;
                Thread.Sleep(1000); // чекаємо 1 секунду
            }
            else if (_state == 1)
            {
                Console.WriteLine($"{_name} світлофор: переключаю на зелений");
                _state = 2;
                Thread.Sleep(5000); // чекаємо 5 секунд
            }
            else
            {
                Console.WriteLine($"{_name} світлофор: переключаю на червоний");
                _state = 0;
                Thread.Sleep(1000); // чекаємо 1 секунду
            }
        }
    }

    public int GetState()
    {
        lock (_lock) // блокуємо доступ до стану світлофора
        {
            return _state;
        }
    }
}

class Car
{
    private int _id;
    private TrafficLight[] _trafficLights;

    public Car(int id, TrafficLight[] trafficLights)
    {
        _id = id;
        _trafficLights = trafficLights;
    }

    public void Drive()
    {
        Console.WriteLine($"Автомобіль {_id} під'їжджає до перехрестя");

        // очікуємо, доки буде вільне місце на перехресті (семафор з розміром 2)
        Semaphore semaphore = new Semaphore(2, 2);
        semaphore.WaitOne();

        while (true)
        {
            // перевіряємо стан світлофорів
            int state1 = _trafficLights[0].GetState();
            int state2 = _trafficLights[1].GetState();
            int state3 = _trafficLights[2].GetState();
            int state4 = _trafficLights[3].GetState();

            // якщо світлофори відпов
public string Name { get; }
    public int GreenDuration { get; }
    public int YellowDuration { get; }
    public int RedDuration { get; }

    public TrafficLight(string name, int greenDuration, int yellowDuration, int redDuration)
    {
        Name = name;
        GreenDuration = greenDuration;
        YellowDuration = yellowDuration;
        RedDuration = redDuration;
    }

    public void Run()
    {
        while (true)
        {
            lock (_lock)
            {
                Console.WriteLine($"{Name} is green.");
                Thread.Sleep(GreenDuration);

                Console.WriteLine($"{Name} is yellow.");
                Thread.Sleep(YellowDuration);

                Console.WriteLine($"{Name} is red.");
                Thread.Sleep(RedDuration);
            }

            _semaphore.WaitOne();
            Console.WriteLine($"Car passed {Name} traffic light.");
            Thread.Sleep(1000);
            _semaphore.Release();
        }
    }
    public string Name { get; }
    public int GreenDuration { get; }
    public int YellowDuration { get; }
    public int RedDuration { get; }

    public TrafficLight(string name, int greenDuration, int yellowDuration, int redDuration)
    {
        Name = name;
        GreenDuration = greenDuration;
        YellowDuration = yellowDuration;
        RedDuration = redDuration;
    }

    public void Run()
    {
        while (true)
        {
            lock (_lock)
            {
                Console.WriteLine($"{Name} is green.");
                Thread.Sleep(GreenDuration);

                Console.WriteLine($"{Name} is yellow.");
                Thread.Sleep(YellowDuration);

                Console.WriteLine($"{Name} is red.");
                Thread.Sleep(RedDuration);
            }

            _semaphore.WaitOne();
            Console.WriteLine($"Car passed {Name} traffic light.");
            Thread.Sleep(1000);
            _semaphore.Release();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        _semaphore = new Semaphore(2, 2);
        var trafficLight1 = new TrafficLight("North", 3000, 1000, 2000);
        var trafficLight2 = new TrafficLight("South", 4000, 1000, 2000);
        var trafficLight3 = new TrafficLight("East", 2000, 1000, 3000);
        var trafficLight4 = new TrafficLight("West", 5000, 1000, 2000);

        var thread1 = new Thread(trafficLight1.Run);
        var thread2 = new Thread(trafficLight2.Run);
        var thread3 = new Thread(trafficLight3.Run);
        var thread4 = new Thread(trafficLight4.Run);

        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();
    }
}