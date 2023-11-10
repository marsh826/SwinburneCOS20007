using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Message myMessage = new Message("Hello World - from Message Object");
            myMessage.Print();*/

            Message myMessage;
            Message[] messages = new Message[5];
            string name;

            myMessage = new Message("Hello World");
            myMessage.Print();

            messages[0] = new Message("Salute!");
            messages[1] = new Message("Oh hey, g'day mate.");
            messages[2] = new Message("Are you free for dinner at 6:00PM?");
            messages[3] = new Message("Cheers mate!");
            messages[4] = new Message("Good morning.");

            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();

            if (name == "Bill")
            {
                messages[0].Print();
            }
            else if (name == "Jeffery")
            {
                messages[1].Print();
            }
            else if (name == "Alice")
            {
                messages[2].Print();
            } 
            else if (name == "Joshua")
            {
                messages[3].Print();
            }
            else
            {
                messages[4].Print();
            }
        }
    }
}
