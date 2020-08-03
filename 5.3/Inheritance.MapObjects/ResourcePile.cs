namespace Inheritance.MapObjects
{
	public class ResourcePile: ICollect
	{
		public Treasure Treasure { get; set; }
		
		public void Collect(Player player)
		{
			player.Consume(Treasure);
		}
	}
}