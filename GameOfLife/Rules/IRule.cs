using System;
using System.Collections.Generic;

namespace Conway.GameOfLife
{
	public interface IRule
	{
		IEnumerable<Cell> Apply(IEnumerable<Cell> cells);
	}
}

