using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class LookCommand : Command
    {
        public LookCommand(string[] ids) : base(ids)
        {

        } 
        
        public override string Execute(Player p, string[] text)
        {
            return "meh";
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            return "m";
        }
    }
}
