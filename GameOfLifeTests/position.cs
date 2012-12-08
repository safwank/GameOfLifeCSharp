using System;
using NUnit.Framework;
using FluentAssertions;

namespace Conway.GameOfLife.Tests
{
	[TestFixture()]
	public class position
	{
		[Test()]
		public void should_know_whether_another_position_is_adjacent_to_it()
		{
			var position1 = Position.At(6, 6);
			var position2 = Position.At(6, 7);

			position1.IsAdjacentTo(position2).Should().BeTrue();
		}

		[Test()]
		public void should_know_whether_another_position_is_not_adjacent_to_it()
		{
			var position1 = Position.At(6, 6);
			var position2 = Position.At(6, 8);
			
			position1.IsAdjacentTo(position2).Should().BeFalse();
		}
	}
}

