using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using Library;
using LiveCharts;
using LiveCharts.Wpf;

namespace FireSimulator
{
    public partial class GraphForm : Form
    {
        private SimulationData[] simData;

        public GraphForm(SaveItem item)
        {
            InitializeComponent();

            this.Text = $"Lit - Graphs for '{item.Name}' floorplan";

            this.simData = ((Layout)item.Item).GetSimulatioData();

            getBarChart();
            getPieChart();
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {

        }

        private void getPieChart()
        {
            ChartValues<int> firesExtingueshed = new ChartValues<int> { 0 };
            ChartValues<int> allPeopleDead = new ChartValues<int> { 0 };
            ChartValues<int> allPeopleEscaped = new ChartValues<int> { 0 };
            ChartValues<int> timeLimitReached = new ChartValues<int> { 0 };

            foreach (SimulationData sd in this.simData)
            {
                if (sd.Scenario == EScenario.ALL_FIRES_EXTINGUISHED)
                {
                    firesExtingueshed[0]++;
                }
                else if (sd.Scenario == EScenario.EVERY_PERSON_DIED)
                {
                    allPeopleDead[0]++;
                }
                else if (sd.Scenario == EScenario.EVERY_PERSON_ESCAPED)
                {
                    allPeopleEscaped[0]++;
                }
                else if (sd.Scenario == EScenario.TIME_LIMIT_REACHED)
                {
                    timeLimitReached[0]++;
                }
            }

            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "All fires extingueshed",
                    Values = firesExtingueshed,
                    PushOut = 10,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Time limit reached",
                    Values = timeLimitReached,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "All people dead",
                    Values = allPeopleDead,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "All people escaped",
                    Values = allPeopleEscaped,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void getBarChart()
        {
            int counter = 0;

            Dictionary<string, int> datesCounter = new Dictionary<string, int>();
            List<string> dates = new List<string>();
            List<string> counters = new List<string>();
            ChartValues<int> deaths = new ChartValues<int>();
            ChartValues<int> durations = new ChartValues<int>();
            ChartValues<int> simulationPerDate = new ChartValues<int>();

            foreach (SimulationData sd in this.simData)
            {
                counter++;

                if (datesCounter.ContainsKey(sd.DateOfSimulation.ToString("d")))
                {
                    datesCounter[sd.DateOfSimulation.ToString("d")]++;
                }
                else
                {
                    datesCounter.Add(sd.DateOfSimulation.ToString("d"), 1);
                }

                dates.Add(sd.DateOfSimulation.ToString("g"));
                deaths.Add(sd.NrOfDeaths);
                counters.Add(counter.ToString());
                durations.Add((int)sd.SimulationTime.TotalSeconds);
            }

            simulationPerDate.AddRange(datesCounter.Values);

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Number of simulations",
                    Values = simulationPerDate
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = datesCounter.Keys.ToList()
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Number of simulations",
                LabelFormatter = value => value.ToString("N")
            });

            cartesianChart2.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Deaths",
                    Values = deaths
                }
            };

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "",
                Labels = counters
            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Deaths",
                LabelFormatter = value => value.ToString("N")
            });

            cartesianChart3.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Duration",
                    Values = durations
                }
            };

            cartesianChart3.AxisX.Add(new Axis
            {
                Title = "",
                Labels = counters
            });

            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "Durations",
                LabelFormatter = value => value.ToString("N")
            });
        }
    }
}
