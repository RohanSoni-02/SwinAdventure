using System;
namespace SwinAdventure
{
    public enum GameState
    {
        inputName,
        inputDesc,
        Gameplay
    }

    public class GUISwin
    {
        string _output;
        GameState _gamestate;
        string pName;
        string pDesc;
        Player p1;
        Item shovel;
        Item sword;

        Bag b1;

        Item gun;

        Location lightRoom;
        Location darkRoom;
        Location bigRoom;

        Path path1;
        Path path2;
        Path path3;
        CommandProcessor comm;
        LookCommand look;
        MoveCommand move;
        PutCommand put;
        TakeCommand take;
        QuitCommand quit;

        public GUISwin()
        {
            shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "a sword", "This is a might fine sword");
            
            b1 = new Bag(new string[] { "backpack" }, "Player's backpack", "Big backpack");
            
            gun = new Item(new string[] { "gun" }, "a gun", "This is an AR gun");
            
            lightRoom = new Location("lightRoom", "a light room");
            darkRoom = new Location("darkRoom", "a dark room");
            bigRoom = new Location("bigRoom", "a big room");

            path1 = new Path(new string[] { "lightRoom", "path" });
            path2 = new Path(new string[] { "darkRoom", "path" });
            path3 = new Path(new string[] { "bigRoom", "path" });

            lightRoom.Path = path1;
            path1.SetLocation("west", darkRoom);
            path1.SetLocation("north", bigRoom);

            darkRoom.Path = path2;
            path2.SetLocation("east", lightRoom);
            path2.SetLocation("north_east", bigRoom);

            bigRoom.Path = path3;
            path3.SetLocation("south", lightRoom);
            path3.SetLocation("south_west", darkRoom);

            

            lightRoom.Inventory.Put(sword);
            darkRoom.Inventory.Put(gun);
            bigRoom.Inventory.Put(shovel);

            comm = new CommandProcessor();
            look = new LookCommand();
            move = new MoveCommand();
            put = new PutCommand();
            take = new TakeCommand();
            quit = new QuitCommand();

            comm.AddCommands(look);
            comm.AddCommands(move);
            comm.AddCommands(put);
            comm.AddCommands(take);
            comm.AddCommands(quit);
            _gamestate = GameState.inputName;

            _output = "Welcome to SwinAdventure !\n " +
                "Please enter player's name: \n";
        }

        public string Output
        {
            get
            {
                return _output;
            }
        }

        public string InputCommand(string cmd)
        {
            switch (_gamestate)
            {
                case GameState.inputName:
                    pName = cmd;
                    _gamestate = GameState.inputDesc;
                    return pName + "\nPlease enter player's description: \n";

                case GameState.inputDesc:
                    pDesc = cmd;
                    _gamestate = GameState.Gameplay;
                    p1 = new Player(pName, pDesc);
                    p1.Inventory.Put(shovel);
                    p1.Inventory.Put(sword);
                    p1.Location = lightRoom;
                    b1.Inventory.Put(gun);
                    p1.Inventory.Put(b1);

                    return "Welcome, " + pName + ", " + pDesc + "! \nYou are currently in a lightRoom.\nIf you go west, you will enter a darkRoom.\nIf you go north, you will enter a bigRoom.\n";
            }
            return comm.Execute(p1, cmd.Split());
        }
    }
}
