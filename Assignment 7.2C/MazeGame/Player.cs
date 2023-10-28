using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeGame
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc )
        {
            _inventory = new Inventory();
            _location = null;
        }

        public GameObject Locate(string id)
        {
            List<GameObject> gameOBJ = new List<GameObject>();

            if (id == "me" || id == "inventory")
            {
                gameOBJ.Add(this);
            } 
            else if (_inventory.HasItem(id))
            {
                var item = _inventory.Fetch(id);
                gameOBJ.Add(item);
            }
            else if (!_inventory.HasItem(id))
            {
                var item = _location.Locate(id);
                gameOBJ.Add(item);
            }
            else
            {
                Item nullObj = null;
                gameOBJ.Add(nullObj);
            }

            var result = gameOBJ.ElementAt(0);
            gameOBJ.Clear();
            return result;
        }

        public string ChangeLocation(Location place)
        {
            if (place.AreYou(place.FirstId))
            {
                _location = place;
                return $"You have arrived at {_location.Name}";
            }
            else
            {
                return "I don't know where that is";
            }
        }

        public override string FullDescription
        {
            get 
            { 
                return 
                    $"You are {Name} {Description}\n" +
                    $"You are carrying: \n{_inventory.ItemList}"; 
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Location Location
        {
            get { return _location; }
        }

    }
}
