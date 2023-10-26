// See https://aka.ms/new-console-template for more information
using MazeGame;
Player _player = new Player("Hoang An", "the comtemplator of infinity");
Item sword = new Item(new string[] { "knife" }, "an obsidian knife", "A hunting knife cast from obsidian");
Item axe = new Item(new string[] { "axe" }, "a stone axe", "An axe made of cobblestone");

_player.Inventory.Put(sword);
_player.Inventory.Put(axe);

Bag _bag = new Bag(new string[] { "b1" }, "leather bag", "a bag made and stiched with leather.");
_player.Inventory.Put(_bag);

Item shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
_bag.Inventory.Put(shovel);

LookCommand look = new LookCommand(new string[] { "look" });
bool commandListen = true;

Console.WriteLine("Swin-Adventure Maze Game");
Console.WriteLine($"Welcome");
Console.WriteLine($"{_player.FullDescription}");
Console.WriteLine();


while (commandListen == true)
{
    Console.WriteLine("Type in command 'look'");
    Console.WriteLine("Note: the command must be either 3 or 5 words only");
    Console.WriteLine("Example: 'look at ...' or 'look at ... in ...'");
    Console.WriteLine();

    Console.Write("Command: ");
    string command = Console.ReadLine();

    if (command == "exit")
    {
        break;
    }

    string[] cmdArray = command.Split(' ');
    Console.WriteLine("Output: ");
    Console.WriteLine(look.Execute(_player, cmdArray));
    Console.WriteLine("");
}