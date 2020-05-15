using System;
using System.Collections.Generic;

namespace Library
{
	[Serializable]
	public class Layout : Grid
	{
		private readonly List<SimulationData> simulationData = new List<SimulationData>();
		public Guid Id { get; } = Guid.NewGuid();

		public Layout(Block[,] grid)
		{
			this.grid = grid;
		}

		public void AddSimulationData(SimulationData data)
		{
			simulationData.Add(data);
		}

		public SimulationData[] GetSimulatioData()
		{
			return simulationData.ToArray();
		}

		public decimal GetAverageDeathAmount()
		{
			decimal value = 0;

			foreach (SimulationData data in simulationData)
				value += data.NrOfDeaths;

			return value / simulationData.Count;
		}

		public decimal GetAverageSurviverAmount()
		{
			decimal value = 0;

			foreach (SimulationData data in simulationData)
				value += data.NrOfSurvivers;

			return value / simulationData.Count;
		}

		public TimeSpan GetAverageElapsedTime()
		{
			TimeSpan time = TimeSpan.Zero;

			foreach (SimulationData data in simulationData)
				time += data.SimulationTime;

			return new TimeSpan(time.Ticks / simulationData.Count);
		}

		public Block[,] DeepCloneBlock()
			=> Grid.DeepCloneBlock(this.grid);
	}
}
