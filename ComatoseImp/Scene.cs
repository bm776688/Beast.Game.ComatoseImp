using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComatoseImp.Chara;
namespace ComatoseImp
{
	public class Scene
	{
		public Map Map { get; set; }

		public List<Character> Characters { get; set; }

		public int Round { get; set; }
	}
}
