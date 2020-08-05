namespace Inheritance.MapObjects
{
	public interface IOwner
	{
		int Owner { get; set; }
	}

	public interface IArmy
	{
		Army Army { get; set; }
	}

	public interface ITreasure
	{
		Treasure Treasure { get; set; }
	}

	public class Mine: IArmy, IOwner, ITreasure
	{
		public int Owner { get; set; }
		public Treasure Treasure { get; set; }
		public Army Army { get; set; }
	}
	
	public class Creeps: IArmy, ITreasure
	{
		public Army Army { get; set; }
		public Treasure Treasure { get; set; }
	}
	
	public class Wolfs: IArmy
	{
		public Army Army { get; set; }
	}
	
	public class Dwelling: IOwner
	{
		public int Owner { get; set; }
	}
	
	public class ResourcePile: ITreasure
	{
		public Treasure Treasure { get; set; }
	}
	
	public static class Interaction
	{
		public static void Make(Player player, object mapObject)
		{
			if (mapObject is IArmy army)
			{
				if (!player.CanBeat(army.Army))
				{
					player.Die();
					return;	
				}
			}
			
			if (mapObject is ITreasure treasure)
			{
				player.Consume(treasure.Treasure);
			}

			if (mapObject is IOwner owner)
			{
				owner.Owner = player.Id;
			}
		}
	}
}