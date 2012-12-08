using System;

namespace Conway.GameOfLife
{
	public struct DeadState : IState
	{
		public static IState Value {
			get {
				return new DeadState();
			}
		}
	}
}

