using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridInterface
{
    public partial class MainForm : Form
    {
        private readonly IPaintable[] paintables;

        private readonly int gridRows;
        private readonly int gridColumns;

        private readonly double playfieldWidth;
        private readonly double playfieldHeight;

        public MainForm()
        {
            InitializeComponent();

            // set the variables for this session
            this.gridRows = 30;
            this.gridColumns = 30;

            this.playfieldWidth = 150d;
            this.playfieldHeight = 150d;

            Person p1 = new Person(0d * this.playfieldWidth, 0d * this.playfieldHeight);
            p1.On_Tick = () =>
            {
                // move from 0%, 0% of the playfield to 50%, 100% of the playfield 
                p1.WalkToward(_2DPoint.MakeNew(.5d * this.playfieldWidth, 1d * this.playfieldHeight));
            };

            Person p2 = new Person(1d * this.playfieldWidth, 1d * this.playfieldHeight);
            p2.On_Tick = () =>
            {
                // move from 100%, 100% to 75%, 50% of the playfield
                p2.WalkToward(_2DPoint.MakeNew(.75d * this.playfieldWidth, .5d * this.playfieldHeight));
            };

            FireExtinguisher fe1 = new FireExtinguisher(.5d * this.playfieldWidth, .3d * this.playfieldHeight);

            Fire f1 = new Fire(_2DPoint.MakeNew(.7d * this.playfieldWidth, .2d * this.playfieldHeight));

            Fire f2 = new Fire(_2DPoint.MakeNew(.1d * this.playfieldWidth, .6d * this.playfieldHeight));

            // create a list of paintable objects
            this.paintables = new IPaintable[] {p1, p2, fe1, f1, f2};

            // the method for painting the paintable objects on the picturebox
            this.PBGrid.Paint += (s, e) =>
            {
                float pixelsPerColumn = this.PBGrid.Width / this.gridColumns;
                float pixelsPerRow = this.PBGrid.Height / this.gridRows;

                double anglePrecision = .05d;

                Pen gridlinePen = Pens.Gray;

                List<(int column, int row, Brush brush)> coloredCells = new List<(int column, int row, Brush brush)>();

                foreach (IPaintable p in this.paintables)
                {
                    // add the representing cells to the list
                    (int column, int row, Brush brush) cell = (0, 0, null);

                    switch (p)
                    {
                        case _2DPoint pnt:
                            // get the relative location on the grid
                            cell.column = (int)((pnt.X / this.playfieldWidth) * this.gridColumns);
                            cell.row = (int)((pnt.Y / this.playfieldHeight) * this.gridRows);

                            // set the right color
                            if (p is Person) cell.brush = new SolidBrush(Color.Blue);
                            if (p is FireExtinguisher) cell.brush = new SolidBrush(Color.Green);

                            coloredCells.Add(cell);
                            break;
                        case _2DCircle crl:
                            double rowsInRadius = (crl.Radius / this.playfieldHeight) * this.gridRows;
                            double colsInRadius = (crl.Radius / this.playfieldWidth) * this.gridColumns;

                            double radiusSteps = crl.Radius / Math.Max(rowsInRadius, colsInRadius);

                            // do a sweep around the circle's center for every step of the radius
                            for (double radius = 0d; radius <= crl.Radius; radius += radiusSteps)
                            {
                                for (double angle = 0d; angle < Math.PI * 2; angle += anglePrecision)
                                {
                                    // get the location of the sweeper end
                                    double x = crl.Center.X + (Math.Cos(angle) * radius);
                                    double y = crl.Center.Y + (Math.Sin(angle) * radius);

                                    // get the relative location on the grid
                                    cell.column = (int)((x / this.playfieldWidth) * this.gridColumns);
                                    cell.row = (int)((y / this.playfieldHeight) * this.gridRows);

                                    // set the right color
                                    if (p is Fire) cell.brush = new SolidBrush(Color.Red);

                                    coloredCells.Add(cell);
                                }
                            }
                            break;
                        case _2DLine ln:
                            // TODO
                            break;
                    }
                }

                // paint the cells' backgrounds
                foreach ((int column, int row, Brush brush) cell in coloredCells)
                {
                    e.Graphics.FillRectangle(
                        cell.brush,
                        pixelsPerColumn * cell.column,
                        pixelsPerRow * cell.row,
                        pixelsPerColumn,
                        pixelsPerRow
                    );
                }

                // paint the grid lines

                for (int column = 1; column <= this.gridColumns; column++)
                {
                    float x = column * pixelsPerColumn;
                    e.Graphics.DrawLine(gridlinePen, x, 0f, x, this.PBGrid.Height);
                }
                for (int row = 1; row <= this.gridRows; row++)
                {
                    float y = row * pixelsPerRow;
                    e.Graphics.DrawLine(gridlinePen, 0f, y, this.PBGrid.Width, y);
                }
            };

            // paint the picturebox for the first time
            this.PBGrid.Refresh();

            void MoveObjects()
            {
                foreach (IPaintable p in this.paintables)
                {
                    switch (p)
                    {
                        case IChangeableObject co:
                            co.Tick();
                            break;
                            // case <type> <name>: 
                            // do something else...
                    }
                }

                this.PBGrid.Refresh();
            }

            // this button will simulate a timer for moving objects
            this.BTTick.Click += (s, e) => MoveObjects();

            Timer timer = new Timer() { Enabled = false, Interval = 400 };
            timer.Tick += (s, e) => MoveObjects();
            // the button to activate the actual timer
            this.BTAutoTick.Click += (s, e) => timer.Enabled = !timer.Enabled;
        }
    }
}
