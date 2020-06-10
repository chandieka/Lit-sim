using System;
using System.Collections.Generic;

namespace Library
{
	public class FinishedEventArgs : EventArgs
	{
		public readonly EScenario Scenario;
		public readonly bool IsSuccess;

		public readonly static Dictionary<EScenario, string> ScenarioMessageList = new Dictionary<EScenario, string>
		{
			{ EScenario.ALL_FIRES_EXTINGUISHED, "All fires were extinguished" },
			{ EScenario.EVERY_PERSON_ESCAPED, "Every person escaped" },
			{ EScenario.TIME_LIMIT_REACHED, "Time limit was reached" },
			{ EScenario.EVERY_PERSON_DIED, "Every person died" }
		};

		public FinishedEventArgs(EScenario scenario, bool isSuccess)
		{
			this.IsSuccess = isSuccess;
			this.Scenario = scenario;
		}

		public override string ToString()
			=> ScenarioMessageList[Scenario];
	}
}
