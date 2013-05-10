using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComatoseImp
{
	public abstract class Block
	{
		public bool CanMoveOn { get; set; }

		public int Resistance { get; set; }
	}
}
