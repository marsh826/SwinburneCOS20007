// See https://aka.ms/new-console-template for more information
using ClockTask;
using System.Diagnostics.Metrics;

Console.WriteLine("Hello, World!");

/*static void PrintCounters(Counter[] counters)
{
    foreach (Counter c in counters)
    {
        Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
    }
}

Counter[] myCounters = new Counter[3];
int i;

myCounters[0] = new Counter("Counter 1");
myCounters[1] = new Counter("Counter 2");
myCounters[2] = new Counter(myCounters[0].Name);

for (i = 0; i < 9; i++)
{
    myCounters[0].Increment();
}


for (i = 0; i < 14; i++)
{
    myCounters[1].Increment();
}

PrintCounters(myCounters);
myCounters[2].Reset();
PrintCounters(myCounters);*/

Counter[] clockD1 = new Counter[3];
clockD1[0] = new Counter("Digit1 Hour ");
clockD1[1] = new Counter("Digit1 Minute ");
clockD1[2] = new Counter("Digit1 Second");

Counter[] clockD2 = new Counter[3];
clockD2[0] = new Counter("Digit2 Hour");
clockD2[1] = new Counter("Digit2 Minute");
clockD2[2] = new Counter("Digit2 Second");

Clock clock = new Clock(clockD1, clockD2);

while (true)
{
    Console.WriteLine($"Current Time is: {clock.Time}");
    Console.WriteLine("Enter Command: tick, reset or quit");
    var command = Console.ReadLine();
    if (command == "tick")
    {
        clock.ClockStart();
    }

    if (command == "reset")
    {
        clock.ClockReset();
    }

    if (command == "quit")
    {
        break;
    }
}
