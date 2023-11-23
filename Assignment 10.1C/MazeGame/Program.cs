// See https://aka.ms/new-console-template for more information
using MazeGame;
Player _player = new Player("Hoang An", "the comtemplator of infinity");
Item knife = new Item(new string[] { "knife" }, "an obsidian knife", "A hunting knife cast from obsidian");
Item axe = new Item(new string[] { "axe" }, "a stone axe", "An axe made of cobblestone");

_player.Inventory.Put(knife);
_player.Inventory.Put(axe);

Bag _bag = new Bag(new string[] { "b1" }, "leather bag", "a bag made and stiched with leather.");
_player.Inventory.Put(_bag);

Item shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
_bag.Inventory.Put(shovel);

////////Locations/////
//Location 1
Location garden = new Location(new string[] { "garden" }, "green garden", "A garden blooming with natural plants, trees, and flowers");
Item water = new Item(new string[] { "water" }, "a bottled water", "A 1 Litres bottle of spring water to keep you hydrated");
Item pearl = new Item(new string[] { "pearl" }, "a pearl", "A pearl picked from pearl tree. A fruit great for snack");
garden.Inventory.Put(water);
garden.Inventory.Put(pearl);

//Location 2
Location area51 = new Location(new string[] { "area51" }, "area 51", "Special labratory for aliens");

//Location 3
Location library = new Location(new string[] { "library" }, "archive library", "area that contains old history book");
Item book = new Item(new string[] { "book" }, "a history book", "A book that captures the history of this city");
library.Inventory.Put(book);

//Location 4
Location bakery = new Location(new string[] { "bakery" }, "bakery shop", "A shop that sells freshly made breads and deserts");
Item bread = new Item(new string[] { "bread" }, "a loaf of bread", "A freshly baked loaf of white bread");
Item cake = new Item(new string[] { "cake" }, "a piece of cake", "A sweet cake. The shop's signature desert");
bakery.Inventory.Put(bread);
bakery.Inventory.Put(cake);

///////////Command Processor - Identify command type before executing//////////////
CommandProcessor processor = new CommandProcessor();

/////Each location has a number of paths that is linked to a different Location////
///Paths in Garden
Paths gardenPath1 = new Paths(new string[] { "n" }, "north", 
    "You got in your car and travelled through the road up North", area51);
Paths gardenPath2 = new Paths(new string[] { "e" }, "east", 
    "You walked for a kilometer to a library in East", library);
garden.PathList.Add(gardenPath1);
garden.PathList.Add(gardenPath2);

///Paths in Area51
Paths area51Path1 = new Paths(new string[] { "s" }, "south", 
    "You got in your car and travelled through the road down South", garden);
area51.PathList.Add(area51Path1);

///Paths in Library
Paths libraryPath1 = new Paths(new string[] { "w" }, "west",
    "You walked for a kilometer to a garden in East.", garden);
Paths libraryPath2 = new Paths(new string[] { "nw" }, "northwest",
    "You crossed the road and turned left to a bakery in NorthWest", bakery);
library.PathList.Add(libraryPath1);
library.PathList.Add(libraryPath2);

///Paths in Bakery
Paths bakeryPath1 = new Paths(new string[] { "ne" }, "northeast",
    "You turned right and crossed the road to a library in NorthEast", library);
bakery.PathList.Add(bakeryPath1);


Console.WriteLine("Swin-Adventure Maze Game");
Console.WriteLine($"Welcome");
Console.WriteLine($"{_player.FullDescription}");
Console.WriteLine($"{_player.ChangeLocation(garden)}");
Console.WriteLine();

while (true)
{
    Console.WriteLine("For look command, type in command 'look'");
    Console.WriteLine("Note: The input must be either 3 or 5 words only");
    Console.WriteLine("Example: 'look at ...' or 'look at ... in ...'\n");
    Console.WriteLine("For move command, type in command with directions (n, e, s, w):\n" +
        " 'go'\n" +
        " 'move'\n" +
        " 'head'\n" +
        " 'leave'");
    Console.WriteLine("Note: The input must be 2 words only\n");

    Console.Write("Command: ");
    string command = Console.ReadLine();

    if (command == "exit" || command == "Exit")
    {
        Console.WriteLine();
        Console.WriteLine("Bye Bye");
        break;
    }

    string[] cmdArray = command.Split(' ');
    Console.WriteLine();
    Console.Clear();

    Console.WriteLine("Output: ");
    Console.WriteLine(processor.Execute(_player, cmdArray));
}

