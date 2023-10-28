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
            IHaveInventory container;
            string itemID;

            if (text[0] == "look")
            {
                if (text.Length == 3 || text.Length == 5)
                {
                    if (text[1] == "at")
                    {
                        if (text.Length == 3)
                        {
                            container = p;
                            itemID = text[2];
                           
                            return LookAtIn(itemID, container);
                        }
                        else if (text.Length == 5 && text[3] == "in")
                        {
                            string containerID = text[4];
                            container = FetchContainer(p, containerID);
                            string itmReturn;
                            if(container != null)
                            {
                                itemID = text[2];
                                itmReturn = LookAtIn(itemID, container);

                                if(itmReturn == ("I can't find the " + itemID))
                                {
                                    return $"I can't find the {itemID} in {container.Name}";
                                }
                                else
                                {
                                    return itmReturn;
                                }
                            }
                            else
                            {
                                return "I can't find the " + containerID;
                            }
                        }
                        else
                        {
                            return "What do you want to looking in?";
                        }
                    }
                    else
                    {
                        return "What do you want to look at?";
                    }
                }
                else
                {
                    return "I don't know how to look like that";
                }
            }
            else if (text[0] == "Look")
            {
                return p.Location.FullDescription;
            }
            else
            {
                return "Error in look input";
            }
        }

        private IHaveInventory FetchContainer (Player p, string containerID)
        {
            var result = p.Locate(containerID);
            return (IHaveInventory)result;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            var result = container.Locate(thingId);

            if(result != null)
            {
                return result.FullDescription;
            }
            else
            {
                return "I can't find the " + thingId;
            }
        }
    }
}
