using System;
using System.Drawing;

namespace Library
{
	[Serializable]
	public class FireExtinguisher : Block
	{
		new public static readonly Color Color = Color.Green;
		public static readonly int SpreadRadius = 20; // TODO: This should be according to the grid size?
	}
}
