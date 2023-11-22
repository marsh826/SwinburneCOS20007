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
        private Location _currentLocation;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc )
        {
            _inventory = new Inventory();
            _currentLocation = null;
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
            else
            {
                var item = _currentLocation.Locate(id);
                gameOBJ.Add(item);
            }

            if (gameOBJ.Count > 0)
            {
                var result = gameOBJ.ElementAt(0);
                gameOBJ.Clear();
                return result;
            }
            else
            {
                return null;
            }

/*            var result = gameOBJ.ElementAt(0);
            gameOBJ.Clear();
            return result;*/
        }

        public string ChangeLocation(Location place)
        {
            if (place.AreYou(place.FirstId))
            {
                _currentLocation = place;
                return $"You have arrived at {_currentLocation.Name}";
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

        public Location CurrentLocation
        {
            get { return _currentLocation; }
        }

    }
}
