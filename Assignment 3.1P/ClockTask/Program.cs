// See https://aka.ms/new-console-template for more information
using ClockTask;
using System.Diagnostics.Metrics;

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
