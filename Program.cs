using System;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SwinAdventure!");

            Console.WriteLine("Please enter player's name: ");
            string pName = Console.ReadLine();

            Console.WriteLine("Please enter player's description: ");
            string pDesc= Console.ReadLine();

            Item shovel = new Item(new string[] {"shovel"}, "a shovel", "This is a might fine shovel");
            Item sword = new Item(new string[] { "sword" }, "a sword", "This is a might fine sword");
            Player p1 = new Player(pName,pDesc);
            p1.Inventory.Put(shovel);
            p1.Inventory.Put(sword);
            Bag b1 = new Bag(new string[] { "backpack" }, "Player's backpack", "Big backpack");
            p1.Inventory.Put(b1);
            Item gun = new Item(new string[] { "gun" }, "a gun", "This is an AR gun");
            b1.Inventory.Put(gun);

            Location lightRoom = new Location("lightRoom", "a light room");
            Location darkRoom = new Location("darkRoom", "a dark room");
            Location bigRoom = new Location("bigRoom", "a big room");

            Path path1 = new Path(new string[] { "lightRoom", "path" });
            Path path2 = new Path(new string[] { "darkRoom", "path" });
            Path path3 = new Path(new string[] { "bigRoom", "path" });

            lightRoom.Path = path1;
            path1.SetLocation("west", darkRoom);
            path1.SetLocation("north", bigRoom);

            darkRoom.Path = path2;
            path2.SetLocation("east", lightRoom);
            path2.SetLocation("north_east", bigRoom);

            bigRoom.Path = path3;
            path3.SetLocation("south", lightRoom);
            path3.SetLocation("south_west", darkRoom);

            p1.Location = lightRoom;

            lightRoom.Inventory.Put(sword);
            darkRoom.Inventory.Put(gun);
            bigRoom.Inventory.Put(shovel);

            CommandProcessor comm = new CommandProcessor();
            LookCommand look = new LookCommand();
            MoveCommand move = new MoveCommand();
            PutCommand put = new PutCommand();
            TakeCommand take = new TakeCommand();
            QuitCommand quit = new QuitCommand();

            comm.AddCommands(look);
            comm.AddCommands(move);
            comm.AddCommands(put);
            comm.AddCommands(take);
            comm.AddCommands(quit);

            while (true)
            {
                Console.WriteLine("Please enter your command => ");
                string inputCmd = Console.ReadLine();
                string[] Cmd = inputCmd.Split(' ');

                Console.WriteLine(comm.Execute(p1, Cmd));
                if(Cmd[0] == "quit")
                {
                    break;
                }
            }

        }
    }
}
