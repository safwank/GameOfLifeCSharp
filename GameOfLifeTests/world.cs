using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

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
							new Cell(Position.At(6, 6), State.Alive),
							new Cell(Position.At(6, 7), State.Alive)
						};
			var rules = new List<IRule> { new LiveCellsWithLessThanTwoLiveNeighborsDie() };
			var currentWorld = new World (cells, rules);

			var newWorld = currentWorld.Tick();

			newWorld.GetCellAt(Position.At(6, 6)).State.Should().Be(State.Dead);
			newWorld.GetCellAt(Position.At(6, 7)).State.Should().Be(State.Dead);
		}

		[Test()]
		public void should_keep_any_live_cell_with_two_or_three_life_neighbors ()
		{
			var cells = new List<Cell>
			{
				new Cell(Position.At(6, 6), State.Alive),
				new Cell(Position.At(6, 7), State.Alive),
				new Cell(Position.At(7, 6), State.Alive),
			};
			var rules = new List<IRule> { new LiveCellsWithTwoOrThreeLiveNeighborsLiveOn() };
			var currentWorld = new World (cells, rules);
			
			var newWorld = currentWorld.Tick();
			
			newWorld.GetCellAt(Position.At(6, 6)).State.Should().Be(State.Alive);
			newWorld.GetCellAt(Position.At(6, 7)).State.Should().Be(State.Alive);
			newWorld.GetCellAt(Position.At(7, 6)).State.Should().Be(State.Alive);
		}

		[Test()]
		public void should_kill_any_live_cell_with_more_than_three_live_neighbors ()
		{
			var cells = new List<Cell>
			{
				new Cell(Position.At(6, 6), State.Alive),
				new Cell(Position.At(6, 7), State.Alive),
				new Cell(Position.At(7, 6), State.Alive),
				new Cell(Position.At(7, 7), State.Alive),
				new Cell(Position.At(7, 8), State.Alive),
				new Cell(Position.At(8, 6), State.Alive),
			};
			var rules = new List<IRule> { new LiveCellsWithMoreThanThreeLiveNeighborsDie() };
			var currentWorld = new World (cells, rules);
			
			var newWorld = currentWorld.Tick();

			newWorld.GetCellAt(Position.At(6, 6)).State.Should().Be(State.Alive);
			newWorld.GetCellAt(Position.At(6, 7)).State.Should().Be(State.Dead);
			newWorld.GetCellAt(Position.At(7, 6)).State.Should().Be(State.Dead);
			newWorld.GetCellAt(Position.At(7, 7)).State.Should().Be(State.Dead);
			newWorld.GetCellAt(Position.At(7, 8)).State.Should().Be(State.Alive);
			newWorld.GetCellAt(Position.At(8, 6)).State.Should().Be(State.Alive);
		}

		[Test()]
		public void should_reincarnate_any_dead_cell_with_exactly_three_live_neighbors ()
		{
			var cells = new List<Cell>
			{
				new Cell(Position.At(6, 6), State.Alive),
				new Cell(Position.At(6, 7), State.Alive),
				new Cell(Position.At(7, 6), State.Dead),
				new Cell(Position.At(7, 7), State.Alive)
			};
			var rules = new List<IRule> { new DeadCellsWithThreeLiveNeighborsBecomeAlive() };
			var currentWorld = new World (cells, rules);
			
			var newWorld = currentWorld.Tick();
			
			newWorld.GetCellAt(Position.At(6, 6)).State.Should().Be(State.Alive);
			newWorld.GetCellAt(Position.At(6, 7)).State.Should().Be(State.Alive);
			newWorld.GetCellAt(Position.At(7, 6)).State.Should().Be(State.Alive);
			newWorld.GetCellAt(Position.At(7, 7)).State.Should().Be(State.Alive);
		}
	}
}

