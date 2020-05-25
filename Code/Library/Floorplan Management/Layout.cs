using System;
using System.Collections.Generic;

namespace Library
{
	[Serializable]
	public class Layout : Thumbnailable, ISavable
	{
		private readonly List<SimulationData> simulationData = new List<SimulationData>();
		public Guid Id { get; } = Guid.NewGuid();

		public bool IsDeletable => simulationData.Count <= 0;

		public Layout(Block[,] grid)
			: base(grid) { }

		public void AddSimulationData(SimulationData data)
			=> simulationData.Add(data);

		public SimulationData[] GetSimulatioData()
			=> simulationData.ToArray();

		public void DeleteAllChildren()
			=> simulationData.Clear();

		public decimal GetAverageDeathAmount()
		{
			if (simulationData.Count < 1)
				return -1;

			decimal value = 0;

			foreach (SimulationData data in simulationData)
				value += data.NrOfDeaths;

			return value / simulationData.Count;
		}

		public decimal GetAverageSurviverAmount()
		{
			decimal value = 0;

			foreach (SimulationData data in simulationData)
				value += data.NrOfPeople - data.NrOfDeaths;

			return value / simulationData.Count;
		}

		public TimeSpan? GetAverageElapsedTime()
		{
			if (simulationData.Count < 1)
				return null;

			TimeSpan time = TimeSpan.Zero;

			foreach (SimulationData data in simulationData)
				time += data.SimulationTime;

			return new TimeSpan(time.Ticks / simulationData.Count);
		}
	}
}
