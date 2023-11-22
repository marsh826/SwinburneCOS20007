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
        private List<Paths> _paths;
  
        public Location(string[] ids, string name, string desc) : base(ids, name, desc) 
        {
            _inventory = new Inventory();
            _paths = new List<Paths>();
        }

        public GameObject Locate(string id)
        {
            List<GameObject> items = new List<GameObject>();

            if(_inventory.HasItem(id))
            {
                var itm = _inventory.Fetch(id);
                items.Add(itm);
            }
            else if (!_inventory.HasItem(id))
            {
                foreach(Paths path in _paths)
                {
                    if(id == path.FirstId || String.Equals(id, path.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        var itm = path;
                        items.Add(itm);
                    }
                }
            }               
            else
            {
                Item nullObj = null;
                items.Add(nullObj);
            }

            if(items.Count > 0)
            {
                var result = items.ElementAt(0);
                items.Clear();
                return result;
            }
            else
            {
                return null;
            }
        }

      /*  public GameObject Locate(string id)
        {
            List<GameObject> items = new List<GameObject>();

            if (_inventory.HasItem(id))
            {
                var itm = _inventory.Fetch(id);
                items.Add(itm);
            }
            else
            {
                foreach (Paths path in _paths)
                {
                    if (id == path.FirstId || String.Equals(id, path.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        var itm = path;
                        items.Add(itm);
                    }
                }
            }

            if (items.Count > 0)
            {
                var result = items.ElementAt(0);
                items.Clear();
                return result;
            }
            else
            {
                return null;
            }
        }*/

        public override string FullDescription
        {
            get
            {
                List<string> ways = new List<string>();
                foreach (var way in PathList)
                {
                    ways.Add(way.Name);
                }
                string[] arr = ways.ToArray();
                string availWays = string.Join("\n", arr);


                return $"You are in a {Name}\n" +
                $"{Description}\n" +
                $"There are {PathList.Count} available pathways: \n{availWays}\n" +
                $"Items available in this area:\n" +
                $"{Inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public List<Paths> PathList 
        { 
            get { return _paths; } 
        }
    }
}
