namespace Inheritance.MapObjects
{
	public class Dwelling: IAssign
	{
		public int Owner { get; set; }
		
		public void Assign(Player player)
		{
			Owner = player.Id;
		}
	}
}