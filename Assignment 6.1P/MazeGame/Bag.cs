using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Bag : Item
    {
        private Inventory _inventory;
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDescription
        {
            get { return $"In the {Name}, you can see:\n{_inventory.ItemList}"; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public GameObject Locate(string id)
        {
            List<GameObject> list = new List<GameObject>();

            if(id == FirstId)
            {
                list.Add(this);
            }
            else if (_inventory.HasItem(id))
            {
                list.Add(_inventory.Fetch(id));
            }
            else
            {
                list.Add(null);
            }

            var result = list.ElementAt(0);
            list.Clear();
            return result;
        }
    }
}
