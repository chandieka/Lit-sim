using System;

namespace Library
{
	[Serializable]
	public readonly struct SimulationData
	{
		public readonly DateTime DateOfSimulation;
		public readonly TimeSpan SimulationTime;
		public readonly int NrOfPeople;
		public readonly int NrOfDeaths;

		public int NrOfSurvivors { get { return NrOfPeople - NrOfDeaths; } }

		public SimulationData(int nrOfDeaths, int nrOfPeople, DateTime date, TimeSpan time)
		{
			this.NrOfPeople = nrOfPeople;
			this.NrOfDeaths = nrOfDeaths;
			this.DateOfSimulation = date;
			this.SimulationTime = time;
		}
	}
}
