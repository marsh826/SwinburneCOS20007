using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Inventory 
    {
        List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach(Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            List<Item> items = new List<Item>();
            foreach(Item itm in _items)
            {
                if(id == itm.FirstId)
                {
                    items.Add(itm);
                }
            }
            var result = items.ElementAt(0);
            items.Clear();
            _items.Remove(result);
            return result;
        }

        public Item Fetch(string id)
        {
            List<Item> items = new List<Item>();
            foreach(Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    items.Add(itm);
                }
            }
            var result = items.ElementAt(0);
            items.Clear();
            return result;
        }

        public string ItemList
        {
            get
            {
                List<string> list = new List<string>();

                foreach (Item itm in _items)
                {
                    list.Add($"{itm.Name} ({itm.FirstId})");
                }

                string itemList = string.Join("\n", list);
                return itemList;
            }
        }
    }
}
