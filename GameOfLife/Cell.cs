using System;

namespace Conway.GameOfLife
{
	public class Cell
	{
		public Cell(Position position, State state)
		{
			Position = position;
			State = state;
		}

		public Position Position { get; private set; }
		public State State { get; private set; }
	}
}

