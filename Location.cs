using System;
using System.Collections.Generic;
namespace SwinAdventure
{
    public class Location: GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Path _path;

        public Location(string name, string desc): base(new string[] {"room"}, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }
        }

        public override string FullDescription
        {
            get
            {
                return ("You are in the " +this.Name + "\nIn the " + this.Name + " you can see: " + _inventory.ItemList);
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Path Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }
    }
}
