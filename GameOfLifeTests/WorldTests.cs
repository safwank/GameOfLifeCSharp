using System;
using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace Conway.GameOfLife.Tests
{
	[TestFixture()]
	public class WorldTests
	{
		[Test()]
		public void Should_Kill_Any_Live_Cell_With_Fewer_Than_Two_Live_Neighbors()
		{
			var cells = new List<Cell>();
			var currentWorld = new World(cells);

			var newWorld = currentWorld.Tick();

			var cell = newWorld.GetCellAt(new Position(6, 6));
			cell.State.ShouldBeEquivalentTo(DeadState.Value);
		}

		[Test()]
		public void Should_Keep_Any_Live_Cell_With_Two_Or_Three_Life_Neighbors()
		{
		}

		[Test()]
		public void Should_Kill_Any_Live_Cell_With_More_Than_Three_Live_Neighbors()
		{
		}

		[Test()]
		public void Should_Reincarnate_Any_Dead_Cell_With_Exactly_Three_Live_Neighbors ()
		{
		}
	}
}

