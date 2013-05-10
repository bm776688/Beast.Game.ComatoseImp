using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComatoseImp
{
	public class Map
	{
		public int Height { get; set; }

		public int Width { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public Block[,] Blocks { get; set; }
	}
}
