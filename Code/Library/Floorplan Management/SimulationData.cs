using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SimulationData
    {
        public readonly Guid Id = Guid.NewGuid();
        public int NrOfDeath { get; private set;}
        public TimeSpan DateOfSimulation { get; private set; }
        public int NrOfSurviver { get; private set; }
        public TimeSpan SimulationTime { get; private set; }

        public SimulationData(int nrOfDeath, TimeSpan dateOfSimulation, int nrOfSurviver, TimeSpan simulationTime)
        {
            NrOfDeath = nrOfDeath;
            DateOfSimulation = dateOfSimulation;
            NrOfSurviver = nrOfSurviver;
            SimulationTime = simulationTime;
        }

    }
}
