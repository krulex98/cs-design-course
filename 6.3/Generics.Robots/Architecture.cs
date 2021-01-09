using System;
using System.Collections.Generic;

namespace Generics.Robots
{
	public interface IRobotAI<out TCommand> where TCommand : IMoveCommand
	{
		TCommand GetCommand();
	}

	public class ShooterAI : IRobotAI<ShooterCommand>
	{
		int counter = 1;

		public ShooterCommand GetCommand()
		{
			return ShooterCommand.ForCounter(counter++);
		}
	}

	public class BuilderAI : IRobotAI<BuilderCommand>
	{
		int counter = 1;

		public BuilderCommand GetCommand()
		{
			return BuilderCommand.ForCounter(counter++);
		}
	}

	public interface IDevice<in TCommand> where TCommand : IMoveCommand
	{
		string ExecuteCommand(TCommand command);
	}

	public class Mover : IDevice<IMoveCommand>
	{
		public string ExecuteCommand(IMoveCommand command)
		{
			if (command == null)
				throw new ArgumentException();
			return $"MOV {command.Destination.X}, {command.Destination.Y}";
		}
	}

	public class ShooterMover : IDevice<IShooterMoveCommand>
	{
		public string ExecuteCommand(IShooterMoveCommand command)
		{
			var hide = command.ShouldHide ? "YES" : "NO";
			return $"MOV {command.Destination.X}, {command.Destination.Y}, USE COVER {hide}";
		}
	}

	public class Robot<TCommand> where TCommand : IMoveCommand
	{
		private readonly IRobotAI<TCommand> ai;
		private readonly IDevice<TCommand> device;

		public Robot(IRobotAI<TCommand> ai, IDevice<TCommand> executor)
		{
			this.ai = ai;
			this.device = executor;
		}

		public IEnumerable<string> Start(int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				var command = ai.GetCommand();
				if (command == null)
					break;
				yield return device.ExecuteCommand(command);
			}
		}
	}

	public static class Robot
	{
		public static Robot<T> Create<T>(IRobotAI<T> ai, IDevice<T> executor) where T : IMoveCommand
		{
			return new Robot<T>(ai, executor);
		}
	}
}