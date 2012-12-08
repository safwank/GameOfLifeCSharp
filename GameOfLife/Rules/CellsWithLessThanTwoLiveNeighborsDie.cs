using System;
using System.Collections.Generic;
using System.Linq;

namespace Conway.GameOfLife
{
	/// <summary>
	/// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
	/// </summary>
	public class CellsWithLessThanTwoLiveNeighborsDie : IRule
	{
		public IEnumerable<Cell> Apply (IEnumerable<Cell> cells)
		{
			var deadCells = from cell in cells
							where cell.State == State.Alive
							let liveNeighborCount = cells.Count(otherCell => otherCell.Position.IsAdjacentTo(cell.Position)
								                                    		 && otherCell.State == State.Alive)
							where liveNeighborCount < 2
							select new Cell(cell.Position, State.Dead);
			var otherCells = from cell in cells
							 where !deadCells.Any(deadCell => deadCell.Position.Equals(cell.Position))
							 select new Cell(cell.Position, cell.State);
			return deadCells.Concat(otherCells);
		}		
	}
}

