using System;
using System.Drawing;

namespace Library
{
	[Serializable]
	public class Block
	{
		public static readonly Block Empty = new Block();
		public static readonly Color Color = Color.DarkGray;
	}
}
