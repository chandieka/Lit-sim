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
		public readonly EScenario Scenario;

		public bool IsSuccessful { get { return this.Scenario == EScenario.ALL_FIRES_EXTINGUISHED || this.Scenario == EScenario.EVERY_PERSON_ESCAPED; } }
		public int NrOfSurvivors { get { return NrOfPeople - NrOfDeaths; } }

		public SimulationData(int nrOfDeaths, int nrOfPeople, DateTime date, TimeSpan time, EScenario scenario)
		{
			this.NrOfPeople = nrOfPeople;
			this.NrOfDeaths = nrOfDeaths;
			this.DateOfSimulation = date;
			this.SimulationTime = time;
			this.Scenario = scenario;
		}
	}
}
