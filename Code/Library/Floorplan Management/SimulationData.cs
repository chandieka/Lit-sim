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
		public readonly bool IsSuccessful;
		public readonly EScenario Scenario;

		public int NrOfSurvivors { get { return NrOfPeople - NrOfDeaths; } }

		public SimulationData(int nrOfDeaths, int nrOfPeople, DateTime date, TimeSpan time, bool isSuccessful, EScenario scenario)
		{
			this.NrOfPeople = nrOfPeople;
			this.NrOfDeaths = nrOfDeaths;
			this.DateOfSimulation = date;
			this.SimulationTime = time;
			this.IsSuccessful = isSuccessful;
			this.Scenario = scenario;
		}
	}
}
