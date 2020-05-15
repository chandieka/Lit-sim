using System;

namespace Library
{
	// TODO
	public class History
	{
		private string reason;
		private DateTime time;
		private Block[,] grid;

		public History(string reason, Block[,] grid)
		{
			this.reason = reason;
			this.Grid = grid;
			this.time = DateTime.Now;
		}

		public Block[,] Grid
		{
			get
			{
				return this.grid;
			}
			private set
			{
				this.grid = value;
			}
		}

		public override string ToString()
		{
			return reason + " - " + this.time.ToShortTimeString();
		}
	}
}
