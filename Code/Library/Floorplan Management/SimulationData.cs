using System;

namespace Library
{
	[Serializable]
	public readonly struct SimulationData
	{
		public readonly TimeSpan DateOfSimulation;
		public readonly TimeSpan SimulationTime;
		public readonly int NrOfSurvivers;
		public readonly int NrOfPeople;
		public readonly int NrOfDeaths;

		public SimulationData(int nrOfSurvivers, int nrOfDeaths, int nrOfPeople, TimeSpan date, TimeSpan time)
		{
			this.NrOfSurvivers = nrOfSurvivers;
			this.NrOfPeople = nrOfPeople;
			this.NrOfDeaths = nrOfDeaths;
			this.DateOfSimulation = date;
			this.SimulationTime = time;
		}
	}
}
