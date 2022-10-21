using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SwinAdventure
{
    public class Player: GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        private Location _previousloc;

        public Player(string name, string desc): base(new string[] {"me","inventory"}, name,desc)
        {
            _inventory = new Inventory();
            _location = null;
            _previousloc = null;
        }

        public GameObject Locate(string id)
        {
            if(AreYou(id))
            {
                return this;
            }
            else
            {
                if (Location is not null)
                {
                    return Location.Locate(id);
                }
                return _inventory.Fetch(id);
            }
            
        }

        public override string FullDescription
        {
            get
            {
                return("You are " + this.Name + " the mighty programmer \n You are carrying " + _inventory.ItemList);
            }
        }

        public void LeaveLocation()
        {
            _location = _previousloc;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
                if (_location == null)
                {
                    _previousloc = value;
                }
                else
                {
                    _previousloc = _location;
                }
            }
            
        }

    }
}
