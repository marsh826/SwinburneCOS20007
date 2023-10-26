// See https://aka.ms/new-console-template for more information
using MazeGame;

Console.WriteLine("Hello, World!");

/*IdentifiableObject id = new IdentifiableObject(new string[] {"ID1", "iD2", "Id3", "id4", "id1" });
IdentifiableObject id2 = new IdentifiableObject(new string[0] { });

Console.WriteLine(id.FirstId);

if(id2.FirstId == "")
{
    Console.WriteLine("id2 returned an empty string");
}*/

/*_player = new Player("Hoang An", "the comtemplator of infinity");
sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze");
shovel = new Item(new string[] { "shovel" }, "a shovel", "A durable shovel borrowed from the village");
axe = new Item(new string[] { "axe" }, "an obsidian axe", "A axe made of obsidian");
_player.Inventory.Put(sword);
_player.Inventory.Put(shovel);
_player.Inventory.Put(pickaxe);*/


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