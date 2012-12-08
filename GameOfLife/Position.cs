using System;

namespace Conway.GameOfLife
{
	public struct Position
	{
		private readonly int x, y;

		private Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static Position At(int x, int y)
		{
			return new Position(x, y);
		}

		public bool IsAdjacentTo(Position position)
		{
			//TODO: figure out a more functional way of doing this (e.g. one-line predicate for x and y)
			return (position.x == x - 1 && position.y == y - 1) 
				|| (position.x == x - 1 && position.y == y)
				|| (position.x == x - 1 && position.y == y + 1)
				|| (position.x == x && position.y == y - 1)
				|| (position.x == x && position.y == y + 1)
				|| (position.x == x + 1 && position.y == y - 1)
				|| (position.x == x + 1 && position.y == y)
				|| (position.x == x + 1 && position.y == y + 1);
		}
	}
}

