namespace Inheritance.MapObjects
{
	public static class Interaction
	{
		public static void Make(Player player, object mapObject)
		{
			if (mapObject is IAssign assignObject)
			{
				assignObject.Assign(player);
			}

			if (mapObject is Mine)
			{
				if (player.CanBeat(((Mine) mapObject).Army))
				{
					((Mine) mapObject).Owner = player.Id;
					player.Consume(((Mine) mapObject).Treasure);
				}
				else player.Die();

				return;
			}

			if (mapObject is Creeps)
			{
				if (player.CanBeat(((Creeps) mapObject).Army))
					player.Consume(((Creeps) mapObject).Treasure);
				else
					player.Die();
				return;
			}

			if (mapObject is ResourcePile)
			{
				player.Consume(((ResourcePile) mapObject).Treasure);
				return;
			}

			if (mapObject is Wolfs)
			{
				if (!player.CanBeat(((Wolfs) mapObject).Army))
					player.Die();
			}
		}
	}
}