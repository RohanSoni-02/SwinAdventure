using System;
namespace SwinAdventure
{
    public class LookCommand: Command
    {
        public LookCommand(): base(new string[] {"look"})
        {}

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0] == "look")
            {
                return p.Location.FullDescription;
            }
                
            if (text.Length != 1 && text.Length != 3 && text.Length !=5)
            {
                return ("I dont know how to look like that");
            }
            if (text[0] != "look")
            {
                return ("Error in look input");
            }
            if (text[1] != "at")
            {
                return ("What do you want to look at");
            }
            if(text.Length == 3)
            {
                if (LookAtIn(text[2], p as IHaveInventory) == null)
                {
                    return LookAtIn(text[2], p.Location);
                }
                return LookAtIn(text[2], p as IHaveInventory);
            }
            if(text.Length == 5)
            {
                if(text[3] != "in")
                {
                    return ("What do you want to look in?");
                }
                IHaveInventory cont = FetchContainer(p,text[4]);
                if (cont is null)
                {
                    return ("I cannot find the " + text[4]);
                }
                return LookAtIn(text[2], cont);
            }
            
            return null;
        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return p.Locate(containerID) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject result = container.Locate(thingId);
            if ( result != null)
            {
                return result.FullDescription;
            }
            else
            {
                return ("I cannot find the " + thingId);
            }
        }
    }
}
