using System;
using System.Collections.Generic;
using System.Linq;

namespace Conway.GameOfLife
{
	public class LiveCellsWithTwoOrThreeLiveNeighborsLiveOn : IRule
	{
		public IEnumerable<Cell> Apply (IEnumerable<Cell> cells)
		{
			var liveCells = from cell in cells
							where cell.State == State.Alive
							let liveNeighborCount = cells.Count(otherCell => otherCell.Position.IsAdjacentTo(cell.Position)
							                                    && otherCell.State == State.Alive)
							where liveNeighborCount == 2 || liveNeighborCount == 3
							select new Cell(cell.Position, State.Alive);
			var otherCells = from cell in cells
							 where !liveCells.Any(deadCell => deadCell.Position.Equals(cell.Position))
							 select new Cell(cell.Position, cell.State);
			return liveCells.Concat(otherCells);
		}		
	}
}

