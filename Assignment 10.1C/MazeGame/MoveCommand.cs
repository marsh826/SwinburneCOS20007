using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class MoveCommand : Command
    {
        public MoveCommand(string[] ids) : base(ids)
        {
            
        }
        public override string Execute(Player p, string[] text)
        {
            string searchID;
            Location container;

            if (text.Length == 2)
            {
                container = p.CurrentLocation;
                searchID = text[1];

/*                if (string.Equals(text[0], "move", StringComparison.OrdinalIgnoreCase)||
                    string.Equals(text[0], "go", StringComparison.OrdinalIgnoreCase)||
                    string.Equals(text[0], "head", StringComparison.OrdinalIgnoreCase)||
                    string.Equals(text[0], "leave", StringComparison.OrdinalIgnoreCase)
                    )*/
                if(string.Equals(text[0], FirstId, StringComparison.OrdinalIgnoreCase))
                {
                    Paths newWay = ScanPaths(container, searchID);

                    if (newWay != null)
                    {
                        p.ChangeLocation(newWay.LinkedArea);
                        return $"You travelled towards {newWay.Name}\n" +
                            $"{newWay.Description}\n" +
                            $"Items available in this area:\n{newWay.LinkedArea.Inventory.ItemList}\n";
                    }
                    else
                    {
                        return "I can't find path: " + searchID + "\n";
                    }
                }
                else
                {
                    return "Error in move input\n";
                }
            }
            else
            {
                return "I don't know how to move like that\n";
            }
        }

        private Paths ScanPaths(IHaveInventory l, string pathID)
        {
            var scanned = l.Locate(pathID);
            return (Paths)scanned;
        }
    }
}
