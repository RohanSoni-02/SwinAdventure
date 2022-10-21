using System;
namespace SwinAdventure
{
	public class Path : IdentifiableObject
	{
		Location _north;
		Location _south;
		Location _east;
		Location _west;
		Location _northEast;
		Location _southEast;
		Location _northWest;
		Location _southWest;
		public Path(string[] idents) : base(idents)
		{
			_north = null;
			_south = null;
			_east = null;
			_west = null;
			_northEast = null;
			_southEast = null;
			_northWest = null;
			_southWest = null;

		}

		public void SetLocation(string direction, Location location)
		{
			if (location == null)
			{
				Console.WriteLine("No location found");
			}
			switch (direction)
			{
				case "north":
					_north = location;
					break;
				case "south":
					_south = location;
					break;
				case "east":
					_east = location;
					break;
				case "west":
					_west = location;
					break;
				case "north_east":
					_northEast = location;
					break;
				case "north_west":
					_northWest = location;
					break;
				case "south_east":
					_southEast = location;
					break;
				case "south_west":
					_southWest = location;
					break;
			}
		}

		public Location LocatePath(string direction)
		{
			if (direction == "up" || direction == "north")
			{
				return _north;
			}
			else if (direction == "down" || direction == "south")
			{
				return _south;
			}
			else if (direction == "right" || direction == "east")
			{
				return _east;
			}
			else if (direction == "left" || direction == "west")
			{
				return _west;
			}
			else if (direction == "north_east")
			{
				return _northEast;
			}
			else if (direction == "north_west")
			{
				return _northWest;
			}
			else if (direction == "south_east")
			{
				return _southEast;
			}
			else if (direction == "south_west")
			{
				return _southWest;
			}
			else
			{
				if (_north != null)
				{
					if (_north.AreYou(direction))
					{
						return _north;
					}
				}
				if (_south != null)
				{
					if (_south.AreYou(direction))
					{
						return _south;
					}
				}
				if (_east != null)
				{
					if (_east.AreYou(direction))
					{
						return _east;
					}
				}
				if (_west != null)
				{
					if (_west.AreYou(direction))
					{
						return _west;
					}
				}
				if (_northEast != null)
				{
					if (_northEast.AreYou(direction))
					{
						return _northEast;
					}
				}
				if (_northWest != null)
				{
					if (_northWest.AreYou(direction))
					{
						return _northWest;
					}
				}
				if (_southEast != null)
				{
					if (_southEast.AreYou(direction))
					{
						return _southEast;
					}
				}
				if (_southWest != null)
				{
					if (_southWest.AreYou(direction))
					{
						return _southWest;
					}
				}
				return null;
			}


		}
	}
}
