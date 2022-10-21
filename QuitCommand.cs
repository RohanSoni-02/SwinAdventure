using System;
namespace SwinAdventure
{
    public class QuitCommand: Command
    {
        public QuitCommand(): base(new string[] {"quit"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if(text[0] == "quit")
            {
                return ("Bye.");
            }
            return null;
        }
    }
}
