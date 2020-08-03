namespace Inheritance.MapObjects
{
	public interface IFight
	{
		void Fight();
	}

	public interface ICollect
	{
		void Collect(Player player);
	}

	public interface IAssign
	{
		void Assign(Player player);
	}
}