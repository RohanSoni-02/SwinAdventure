using System;
namespace SwinAdventure
{
    public class TakeCommand: Command
    {
        public TakeCommand(): base(new string[] {"take", "pickup"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            Item i;
            IHaveInventory invent;
            if (text.Length == 2)
            {
                invent = p.Location;
                i = invent.Inventory.Take(text[1]);
                
                if (i == null)
                {
                    return ("I cannot find the item: " + text[1]);
                }
                else
                {
                    p.Inventory.Put(i);
                    return ("Successful take! You have now taken the " + i.Name + " from the " + invent.Name);
                }
            }
            else if (text.Length == 4)
            {
                invent = FetchContainer(p, text[3]);
                if (invent == null)
                {
                    return ("I cannot find the invent: " + text[3]);
                }
                else
                {
                    i = invent.Inventory.Take(text[1]);
                    if (i == null)
                    {
                        return ("I cannot find the item: " + text[1] + " in the " + text[3]);
                    }
                    else
                    {
                        p.Inventory.Put(i);
                        return ("Successful take! You have now taken the " + i.Name + " from the " + invent.Name);
                    }
                }
            }
            else
            {
                return ("I do not know how to take like that.");
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Locate(containerID) as IHaveInventory;
        }
    }
}
