using System;
using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace Conway.GameOfLife.Tests
{
	[TestFixture()]
	public class world
	{
		[Test()]
		public void should_kill_any_live_cell_with_fewer_than_two_live_neighbors()
		{
			var cells = new List<Cell>();
			var currentWorld = new World(cells);

			var newWorld = currentWorld.Tick();

			var cell = newWorld.GetCellAt(new Position(6, 6));
			cell.State.ShouldBeEquivalentTo(DeadState.Value);
		}

		[Test()]
		public void should_keep_any_live_cell_with_two_or_three_life_neighbors()
		{
		}

		[Test()]
		public void should_kill_any_live_cell_with_more_than_three_live_neighbors()
		{
		}

		[Test()]
		public void should_reincarnate_any_dead_cell_with_exactly_three_live_neighbors ()
		{
		}
	}
}

