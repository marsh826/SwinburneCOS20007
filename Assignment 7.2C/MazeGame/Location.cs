using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
  
        public Location(string[] ids, string name, string desc) : base(ids, name, desc) 
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            List<GameObject> items = new List<GameObject>();

            if(_inventory.HasItem(id))
            {
                var itm = _inventory.Fetch(id);
                items.Add(itm);
            }
            else
            {
                Item nullObj = null;
                items.Add(nullObj);
            }

            var result = items.ElementAt(0);
            items.Clear();
            return result;
        }

        public override string FullDescription
        {
            get
            {
                return $"You are in a {Name}\n" +
                    $"{Description}\n"+
                    $"In this place, you can see:\n"+
                    $"{Inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
