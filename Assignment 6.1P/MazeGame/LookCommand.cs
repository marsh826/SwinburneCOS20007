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
/*            for(int i = 0; i < text.Length; i++)
            {*/
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0] == "look")
                {
                    if (text[1] == "at")
                    {
                        if (text.Length >= 3)
                        {
                            Player container = p;
                            string itemID = text[2];
                            if(text.Length == 5)
                            {
                                string containerID = text[3];
                                FetchContainer(container, containerID);
                            }
                            LookAtIn(itemID, container);
                        }
                    }
                    else
                    {
                        return "What do you want to look at?";
                    }
                }
                else
                {
                    return "Error in look input";
                }
            }
            //}


            return "I don't know how to look like that";
        }

        public IHaveInventory FetchContainer (Player p, string containerID)
        {
            IHaveInventory container;
            var result = p.Locate(containerID);
            container = result as IHaveInventory;
            return container;
            //return (IHaveInventory)result;
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            var result = container.Locate(thingId);

            if(result != null)
            {
                return result.FullDescription;
            }

            return "I can't find the " + thingId;
        }
    }
}
