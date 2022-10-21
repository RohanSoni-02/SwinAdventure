using System;
using System.Collections.Generic;
namespace SwinAdventure
{
    public class MoveCommand: Command
    {
        Location _location;

        public MoveCommand(): base(new string[] { "move", "go", "head", "leave" })
        {}

        public string MovePlayer(Player p, string id)
        {
            if (id == "leave")
            {
                p.LeaveLocation();
                return p.Location.FullDescription;
            }

            _location = p.Location;

            Path _path = _location.Path;

            if (_path == null)
            {
                return "No path found for this location";
            }

            _location = _path.LocatePath(id);

            if (_location == null)
            {
                return "There exists no path.";
            }

            p.Location = _location;
            return p.Location.FullDescription;
        }

        public override string Execute(Player p, string[] commands)
        {
            if (commands.Length == 1 && commands[0] != "leave" || commands.Length > 3)
            {
                return "I don't know how to move like that";
            }

            if (commands[0] != "move" && commands[0] != "go" && commands[0] != "head" && commands[0] != "leave")
            {
                return "Error in move input";
            }

            if (commands[0] != "leave")
            {
                if (commands[1] != "to" || commands.Length < 3)
                {
                    return "Where do you want to go?";
                }
                else
                {
                    return MovePlayer(p, commands[2]);
                }
            }
            else
            {
                return MovePlayer(p, "leave");
            }
        }
    }
}
