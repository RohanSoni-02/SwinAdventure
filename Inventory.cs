using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {
        }

        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
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
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    _items.Remove(itm);
                    return itm;
                }
            }
            return null;
            
        }

        public Item Fetch(string id)
        {
            foreach(Item itm in _items)
            {
                if(itm.AreYou(id))
                {
                    return itm;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string LiItems = "";
                foreach(Item itm in _items)
                {
                    LiItems += itm.ShortDescription + "\n"; 
                }
                return LiItems;
            }
        }
    }
}
