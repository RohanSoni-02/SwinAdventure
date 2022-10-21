using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SwinAdventure
{
    public class PutCommand: Command
    {
        public PutCommand(): base(new string[] {"put","drop"})
        {

        }
        public override string Execute(Player p, string[] text)
        {
            Item i;
            IHaveInventory invent;

            if (text.Length == 2)
            {
                invent = p.Location;
                i = p.Inventory.Take(text[1]);

                if (i == null)
                {
                    return ("I cannot find the item: " + text[1]);
                }
                else
                {
                    invent.Inventory.Put(i);
                    return ("Successful put! You have now put the " + i.Name + " in the " + invent.Name);
                }
                    
            }
            else if (text.Length == 4)
            {
                i = p.Inventory.Take(text[1]);
                invent = FetchContainer(p, text[3]);
                if (invent == null)
                {
                    return ("I cannot find the invent: " + text[3]);
                }
                else
                {
                    if (i == null)
                    {
                        return ("I cannot find the item: " + text[1] + " in the " + text[3]);
                    }
                    else
                    {
                        invent.Inventory.Put(i);
                        return ("Successful put! You have now put the " + i.Name + " in the " + invent.Name);
                    }
                }   
            }
            else
            {
                return "I don't know how to put like that";
            }
           
        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Locate(containerID) as IHaveInventory;
        }
    }
}
