using System;

namespace Library
{
	[Serializable]
	// TODO
	public class History : Grid
	{
		private string reason;
		private DateTime time;

		public History(string reason, Block[,] grid)
			: base(grid)
		{
			this.reason = reason;
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
