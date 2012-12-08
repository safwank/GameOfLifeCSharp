using System;
using System.Collections.Generic;

namespace Conway.GameOfLife
{
	public class World
	{
		public World(IEnumerable<Cell> cells)
		{
		}

		public World Tick()
		{
			//TODO
			var newCells = new List<Cell>();
			return new World(newCells);
		}

		public Cell GetCellAt(Position position)
		{
			//TODO
			return new Cell();
		}
	}
}

