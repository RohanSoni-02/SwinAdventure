using System;
using System.Collections.Generic;
namespace SwinAdventure
{
    public class CommandProcessor: Command
    {
		private List<Command> _commands = new List<Command>();

		public CommandProcessor(): base(new string[] {"Command Processor"})
		{}

		public override string Execute(Player p, string[] text)
		{
			foreach (Command command in _commands)
			{
				if (command.AreYou(text[0]))
				{
					return command.Execute(p, text);
				}
			}

			return "There exists no command.";
		}

		public void AddCommands(Command NewComm)
		{
			_commands.Add(NewComm);
		}
	}
}
