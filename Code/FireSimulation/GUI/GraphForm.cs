using System;
using System.Collections.Generic;
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
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                /*foreach(SimulationData sd in this.simData)
                {
                new PieSeries
                {
                    Title = sd.ToString(),
                    Values = new ChartValues<int> { sd.NrOfDeaths }
                };
                }*/
                new PieSeries
                {
                    Title = "Maria",
                    Values = new ChartValues<double> {3},
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Charles",
                    Values = new ChartValues<double> {4},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Frida",
                    Values = new ChartValues<double> {6},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Frederic",
                    Values = new ChartValues<double> {2},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void getBarChart()
        {
            List<string> dates = new List<string>();
            ChartValues<int> people = new ChartValues<int>();
            ChartValues<int> deaths = new ChartValues<int>();
            ChartValues<int> survivors = new ChartValues<int>();

            foreach (SimulationData sd in this.simData)
            {
                dates.Add(sd.DateOfSimulation.ToString("g"));
                people.Add(sd.NrOfPeople);
                deaths.Add(sd.NrOfDeaths);
                survivors.Add(sd.NrOfSurvivors);
            }

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "People",
                    Values = people
                }
            };

            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "Survivors",
                Values = survivors
            });

            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "Deaths",
                Values = deaths
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = dates
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "People/Survivors/Deaths",
                LabelFormatter = value => value.ToString("N")
            });

            cartesianChart3.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart3.Series.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            cartesianChart3.Series[1].Values.Add(48d);

            cartesianChart3.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" }
            });

            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });
        }
    }
}
