using System;
using System.Collections.Generic;
using System.Linq;
using System.Monads;

namespace Conway.GameOfLife
{
	public class World
	{
		private readonly IEnumerable<Cell> cells;
		private readonly IEnumerable<IRule> rules;

		public World(IEnumerable<Cell> cells, IEnumerable<IRule> rules)
		{
			this.cells = cells;
			this.rules = rules;
		}

		public World Tick()
		{
			var newCells = GetNewGeneration();
			return new World(newCells, rules);
		}

		private IEnumerable<Cell> GetNewGeneration()
		{
			var newCells = cells;
			rules.Do(rule => newCells = rule.Apply(newCells));
			return newCells;
		}

		public Cell GetCellAt(Position position)
		{
			return cells.SingleOrDefault(cell => cell.Position.Equals(position));
		}
	}
}

