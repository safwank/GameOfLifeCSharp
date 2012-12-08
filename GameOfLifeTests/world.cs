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
		public void should_return_a_cell_at_a_specific_position_if_it_exits()
		{
			var cells = new List<Cell> { new Cell(Position.At(6, 6), State.Alive) };
			var world = new World(cells, null);

			var cell = world.GetCellAt(Position.At(6, 6));

			cell.Should().NotBeNull();
		}

		[Test()]
		public void should_return_null_if_a_specific_position_is_empty()
		{
			var cells = new List<Cell>();
			var world = new World(cells, null);
			
			var cell = world.GetCellAt(Position.At(6, 6));
			
			cell.Should().BeNull();
		}

		[Test()]
		public void should_kill_any_live_cell_with_fewer_than_two_live_neighbors ()
		{
			var cells = new List<Cell>
						{
							new Cell(Position.At(6,6), State.Alive),
							new Cell(Position.At(6,7), State.Alive)
						};
			var rules = new List<IRule> { new CellsWithLessThanTwoLiveNeighborsDie() };
			var currentWorld = new World (cells, rules);

			var newWorld = currentWorld.Tick();

			newWorld.GetCellAt(Position.At(6, 6)).State.Should().Be(State.Dead);
			newWorld.GetCellAt(Position.At(6, 7)).State.Should().Be(State.Dead);
		}

		[Test()]
		public void should_keep_any_live_cell_with_two_or_three_life_neighbors ()
		{
		}

		[Test()]
		public void should_kill_any_live_cell_with_more_than_three_live_neighbors ()
		{
		}

		[Test()]
		public void should_reincarnate_any_dead_cell_with_exactly_three_live_neighbors ()
		{
		}
	}
}
