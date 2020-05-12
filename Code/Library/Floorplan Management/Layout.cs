using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Layout
    {
        public Block[,] Grid { get; private set; }
        public int NrOfPeople { get; private set; }
        public int NrOfFireExtinguisher { get; private set; }
        public int NrOfFire { get; private set; }
        private List<SimulationData> SimulationDatas;

        public Layout(Block[,] grid, int nrOfPeople, int nrOfFireExtinguisher, int nrOfFire)
        {
            Grid = grid;
            NrOfPeople = nrOfPeople;
            NrOfFire = nrOfFire;
            NrOfFireExtinguisher = nrOfFireExtinguisher;
            SimulationDatas = new List<SimulationData>();
        }

        public void AddSimulationData(SimulationData data)
        {
            if (data != null)
            {
                SimulationDatas.Add(data);
            }
        }

        public SimulationData[] GetSimulatioDatas()
        {
            return SimulationDatas.ToArray();
        }

        public decimal GetAverageDeath()
        {
            decimal value = 0;

            foreach (SimulationData data in SimulationDatas)
            {
                value += data.NrOfDeath;
            }

            return value / SimulationDatas.Count;
        }

        public decimal GetAverageSurviver()
        {
            decimal value = 0;

            foreach (SimulationData data in SimulationDatas)
            {
                value += data.NrOfSurviver;
            }

            return value / SimulationDatas.Count;
        }

        public TimeSpan GetAverageElapseTime()
        {
            TimeSpan time = TimeSpan.Zero;

            foreach (SimulationData data in SimulationDatas)
            {
                time += data.SimulationTime;
            }

            return new TimeSpan(time.Ticks / SimulationDatas.Count);
        }
    }
}
