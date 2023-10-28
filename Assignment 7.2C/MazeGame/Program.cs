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

Location garden = new Location(new string[] { "garden" }, "green garden", "A garden blooming with natural plants, trees, and flowers");
Item water = new Item(new string[] { "water" }, "a bottled water", "A 1 Litres bottle of spring water to keep you hydrated");
Item pearl = new Item(new string[] { "pearl" }, "a pearl", "A pearl picked from pearl tree. A fruit great for snack");
garden.Inventory.Put(water);
garden.Inventory.Put(pearl);


LookCommand look = new LookCommand(new string[] { "look", "Look" });

Console.WriteLine("Swin-Adventure Maze Game");
Console.WriteLine($"Welcome");
Console.WriteLine($"{_player.FullDescription}");
Console.WriteLine($"{_player.ChangeLocation(garden)}");
Console.WriteLine();


while (true)
{
    Console.WriteLine("Type in command 'look'");
    Console.WriteLine("Note: the command must be either 3 or 5 words only");
    Console.WriteLine("Example: 'look at ...' or 'look at ... in ...'");

    Console.Write("Command: ");
    string command = Console.ReadLine();

    if (command == "exit")
    {
        Console.WriteLine();
        Console.WriteLine("Bye Bye");
        break;
    }

    string[] cmdArray = command.Split(' ');
    Console.WriteLine();
    Console.WriteLine("Output: ");
    Console.WriteLine(look.Execute(_player, cmdArray));
    Console.WriteLine("");
}