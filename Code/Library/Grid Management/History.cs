using System;

namespace Library
{
	[Serializable]
	public class History
	{
		private string reason;
		private Block[,] grid;

		public History(string reason, Block[,] grid)
		{
			this.reason = reason;
			this.Grid = grid;
		}

		public Block[,] Grid
		{
			get
			{
				return this.grid;
			}
			set
			{
				this.grid = value;
			}
		}

		public override string ToString()
			=> reason;
	}
}
