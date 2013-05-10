using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComatoseImp.Chara
{
	public abstract class Character
	{
		public int MoveAbility { get; set; }

		public double PhysicalAttack { get; set; }

		public double PowerAttack { get; set; }

		public double PhysicalDefence { get; set; }

		public double PowerDefence { get; set; }

		public int X { get; set; }

		public int Y { get; set; }

		#region public methods

		public Point[] CalculateMoveArea(Map map) 
		{
			Point[] direction = new Point[]{
				new Point(0, 1),
				new Point(1, 0),
				new Point(0, -1),
				new Point(-1, 0)
			};
			List<Point> result = new List<Point>();
			int ability = MoveAbility;
			bool[,] visited = new bool[ability * 2 + 1, ability * 2 + 1];
			int[,] able = new int[ability * 2 + 1, ability * 2 + 1];
 			Point center = new Point(ability, ability);
			Queue<Point> queue = new Queue<Point>();
			Queue<int> queueAbility = new Queue<int>();

			visited[center.X, center.Y] = true;
			able[center.X, center.Y] = ability;
			result.Add(center);
			queue.Enqueue(center);
			queueAbility.Enqueue(ability);

			while (queue.Count > 0) 
			{
				Point current = queue.Dequeue();
				int curAble = queueAbility.Dequeue();
				for (int i = 0; i < 4; i++) 
				{
					Point newPoint = current - direction[i];
					int newAble = curAble - map.Blocks[newPoint.X, newPoint.Y].Resistance;
					if (newPoint.X < 0 || newPoint.X >= map.Width || newPoint.Y < 0 || newPoint.Y >= map.Height) continue;
					if (map.Blocks[newPoint.X, newPoint.Y].CanMoveOn == false) continue;
					if(curAble - map.Blocks[newPoint.X, newPoint.Y].Resistance < 0)continue;
					if (visited[newPoint.X - center.X, newPoint.Y - center.Y] == true && newAble <= able[newPoint.X - center.X, newPoint.Y - center.Y]) continue;

					queue.Enqueue(newPoint);
					queueAbility.Enqueue(newAble);
					if (visited[newPoint.X - center.X, newPoint.Y - center.Y] == false) result.Add(newPoint);
					visited[newPoint.X, newPoint.Y] = true;
					able[newPoint.X, newPoint.Y] = newAble;
				}
			}

			return result.ToArray();
		}

		#endregion
	}
}
