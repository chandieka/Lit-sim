using Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FireSimulator
{
    public partial class FireSimulatorForm : Form
    {
        private TimeSpan time = new TimeSpan(0, 0, 0);
        private GridController gridController;
        private bool building = true;
        private GUIElement element;
        private Pair prevCurPos;
        private Pair curCurPos;

        private bool running;

        private Brush erasorBrush = new SolidBrush(Color.FromArgb(120, Color.Salmon));
        // private GridController lastGrid;

        private bool testingTicks = true;

        public FireSimulatorForm()
        {
            InitializeComponent();
          //  WindowState = FormWindowState.Maximized;
            tbTimer.Text = time.ToString();
            this.Text = "Fire Escape Simulator";
            this.gridController = new GridController((100, 100));   
        
        }

        #region Private Methods

        private void FillDefault()
        {
            gridController.RandomizeFire(1);
            gridController.RandomizePersons(10);
            gridController.RandomizeFireExtinguishers(20);
            GetStats();
        }

        private void GetStats()
        {
            int people = gridController.GetNrOfPeople();
            int deaths = gridController.GetTotalDeaths();
            int fireExtinguishers = gridController.GetNrOfFireExtinguishers();
            int alive = people - deaths;

            if (people == deaths)
            {
                lblResult.Text = "Fail";
            }

            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblElapsedTime.Text = time.ToString();
            lblPeopleTotal.Text = people.ToString();
            lblFireExTotal.Text = fireExtinguishers.ToString();
            lblDeaths.Text = deaths.ToString();
            lblAlive.Text = alive.ToString();
        }

        private void switchInput()
        {
            if (building == true)
            {
                lblGenerate.Font = new Font(lblGenerate.Font, FontStyle.Underline);
                lblBuild.Font = new Font(lblBuild.Font, FontStyle.Regular);
                picBoxWall.Visible = false;
                picBoxFireExtinguisher.Visible = false;
                picBoxFire.Visible = false;
                picBoxPerson.Visible = false;
                picBoxEraser.Visible = false;
                tbPeople.Visible = true;
                tbFireExtinguishers.Visible = true;
                lblPeople.Visible = true;
                lblFireExtinguishers.Visible = true;
                btnGenerate.Visible = true;
                building = false;
                pbFloor.Visible = false;

                gridController.PutDefaultFloorPlan(1);

                if (testingTicks)
                    FillDefault();

                // paint the grid to the picturebox
                VisualizeSimulation();


                if (this.gridController.IsLoadable())
                {
                    using (AutoSaveLoadDialog autoLoadDialog = new AutoSaveLoadDialog(false))
                    {
                        autoLoadDialog.ShowDialog();
                        if (autoLoadDialog.DialogResult == DialogResult.Yes)
                        {
                            var grid = GridController.Load(GridController.defaultPath);

                            if (grid != null)
                            {
                                this.gridController = grid;
                                VisualizeSimulation();
                            }
                        }
                    }
                }
            }
            else
            {
                lblGenerate.Font = new Font(lblGenerate.Font, FontStyle.Regular);
                lblBuild.Font = new Font(lblBuild.Font, FontStyle.Underline);
                picBoxWall.Visible = true;
                picBoxFireExtinguisher.Visible = true;
                picBoxFire.Visible = true;
                picBoxPerson.Visible = true;
                picBoxEraser.Visible = true;
                tbPeople.Visible = false;
                tbFireExtinguishers.Visible = false;
                lblPeople.Visible = false;
                lblFireExtinguishers.Visible = false;
                btnGenerate.Visible = false;
                building = true;
                pbFloor.Visible = true;

                gridController.Clear();
                VisualizeSimulation();
            }
        }

        private void VisualizeSimulation()
        {
            Bitmap bmp = gridController.Paint((6, 6));
            pbSimulation.Image = bmp;
        }

        #endregion

        #region Private EventHandlers

        private void animationLoopTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan second = new TimeSpan(0, 0, 10);
            time = time.Add(second);
            tbTimer.Text = time.ToString();

            // Testing purpose
            if (testingTicks)
            {
                gridController.Tick();
                GetStats();
            }
            else
            {
                gridController.Clear();
                gridController.PutDefaultFloorPlan(1);
                gridController.RandomizePersons(20);
                gridController.RandomizeFireExtinguishers(20);
            }

            VisualizeSimulation();

            if (gridController.Ended())
            {
                picBoxPlayPause_Click(null, null);
                GetStats();
                btnRerunSimulation.Visible = true;
            }
        }

        private void picBoxPlayPause_Click(object sender, EventArgs e)
        {
            if (!picBoxPlayPause.Enabled)
                return;

            if (running == false)
            {
                if (gridController.IsSavable())
                {
                    using (AutoSaveLoadDialog autoSaveDialog = new AutoSaveLoadDialog(true))
                    {
                        autoSaveDialog.ShowDialog();
                        if (autoSaveDialog.DialogResult == DialogResult.Yes)
                        {
                            this.gridController.Save(GridController.defaultPath);
                        }
                    }
                }

                animationLoopTimer.Start();
                // lastGrid = (GridController)gridController.Clone();
                running = true;
                picBoxPlayPause.Image = Icons.Pause;
                toolTipPlay.SetToolTip(picBoxPlayPause, "Pause (Spacebar)");
                btnTerminate.Visible = false;
            }
            else
            {
                animationLoopTimer.Stop();
                running = false;
                picBoxPlayPause.Image = Icons.Play;
                toolTipPlay.SetToolTip(picBoxPlayPause, "Resume (Spacebar)");
                btnTerminate.Visible = true;
            }
        }


        private void lblGenerate_Click(object sender, EventArgs e)
        {
            switchInput();
        }

        private void lblBuild_Click(object sender, EventArgs e)
        {
            switchInput();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gridController.IsSavable())
            {
                using (AutoSaveLoadDialog autoSaveDialog = new AutoSaveLoadDialog(true))
                {
                    autoSaveDialog.ShowDialog();
                    if (autoSaveDialog.DialogResult == DialogResult.Yes)
                    {
                        this.gridController.Save(GridController.defaultPath);
                    }
                    else if (autoSaveDialog.DialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }

            gridController.Stop();
        }

        #endregion

        private void btnCloseStatistics_Click(object sender, EventArgs e)
        {
            gBoxStatistics.Visible = false;
        }

        private void btnSaveLayout_Click(object sender, EventArgs e)
        {
            string fomatNum(int number)
            {
                if (number < 10)
                    return "0" + number;
                else
                    return number.ToString();
            }

            using (SaveFileDialog myDialog = new SaveFileDialog())
            {
                DateTime time = DateTime.Now;

                myDialog.DefaultExt = "bin";
                myDialog.AddExtension = true;
                myDialog.Filter = "Binary|.bin";
                myDialog.CheckPathExists = true;
                myDialog.FileName = $"Lit export [{fomatNum(time.Hour)}.{fomatNum(time.Minute)}.{fomatNum(time.Second)} {time.Year}-{fomatNum(time.Month)}-{fomatNum(time.Day)}].bin";

                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    this.gridController.Save(myDialog.FileName);
                    this.gridController.Save(GridController.defaultPath);
                }
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog myDialog = new OpenFileDialog())
            {
                myDialog.Filter = "Binary|*.bin|All|*";
                myDialog.DefaultExt = "bin";

                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    var grid = GridController.Load(myDialog.FileName);

                    if (grid == null)
                        MessageBox.Show("Could not parse the selected file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.gridController = grid;
                        VisualizeSimulation();
                    }
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool isSuccess = true;
            Random r = new Random();
           // lastGrid = gridController;

            btnTerminate.Visible = false;
            btnRerunSimulation.Visible = false;
            // clear the map
            gridController.Clear();
            // get the basic floor plan
            gridController.PutDefaultFloorPlan(1);
            // add fire to the map
            gridController.RandomizeFire(1, r.Next());

            if (!int.TryParse(tbPeople.Text, out int amountPeople))
                isSuccess &= false; // TODO: show error message

            if (!int.TryParse(tbFireExtinguishers.Text, out int amountFireEx))
                isSuccess &= false; // TODO: show error message

            if (!this.gridController.RandomizePersons(amountPeople, r.Next()))
                isSuccess &= false; // TODO: show error message

            if (!this.gridController.RandomizeFireExtinguishers(amountFireEx, r.Next()))
                isSuccess &= false; // TODO: show error message

            // visualize the map
            // not wasting computing power if its not successfull
            if (isSuccess)
                VisualizeSimulation();
        }

        private void btnRerunSimulation_Click(object sender, EventArgs e)
        {
            gridController.Clear();
            // this.gridController = lastGrid;
            gridController.PutDefaultFloorPlan(1);
            FillDefault();
            VisualizeSimulation();
            time = TimeSpan.Zero;
            tbTimer.Text = time.ToString();
            btnRerunSimulation.Visible = false;
            btnTerminate.Visible = false;
            lblResult.Text = "<Success/Fail>";
            trackBarSpeed.Value = 50;
            animationLoopTimer.Interval = 60;
            this.picBoxPlayPause.Enabled = false;
        }

        // For shortcuts
        private void FireSimulatorForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                picBoxPlayPause_Click(null, null);
            else if (e.Control)
            {
                if (e.KeyCode == Keys.O)
                    btnUploadFile_Click(null, null);
                else if (e.KeyCode == Keys.S)
                    btnSaveLayout_Click(null, null);
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to terminate the simulation?", "Terminate Simulation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (building)
                {
                    this.gridController = new GridController((100, 100));
                }
                else
                {
                    gridController.Clear();
                    // this.gridController = lastGrid;
                    gridController.PutDefaultFloorPlan(1);
                    FillDefault();
                    VisualizeSimulation();
                }               
                time = TimeSpan.Zero;
                tbTimer.Text = time.ToString();
                GetStats();
                btnTerminate.Visible = false;
                trackBarSpeed.Value = 50;
                animationLoopTimer.Interval = 60;
                this.picBoxPlayPause.Enabled = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                //does nothing
            }

        }
        private void btnCalculatePaths_Click(object sender, EventArgs e)
        {
            if (running)
                return;

            var dialog = new ProgressDialog();
            var cancelMethod = gridController.SetupInDifferentThread(cancelled =>
            {
                if (!cancelled)
                    this.picBoxPlayPause.Enabled = true;

                VisualizeSimulation();

                dialog.Close();
                dialog.Dispose();
            }, dialog.SetPercentage, dialog.SetProgressReport);

            dialog.Cancelled += (object s, EventArgs a) => cancelMethod();
            dialog.ShowDialog();
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            lblSpeed.Text = trackBarSpeed.Value.ToString();
            animationLoopTimer.Interval = 10 + (100 - trackBarSpeed.Value);
        }

        private void picBoxWall_Click(object sender, EventArgs e)
        {
            element = GUIElement.WALL;
            picBoxWall.BackColor = Color.DimGray;
            picBoxFireExtinguisher.BackColor = Color.Transparent;
            picBoxFire.BackColor = Color.Transparent;
            picBoxPerson.BackColor = Color.Transparent; 
            picBoxEraser.BackColor = Color.Transparent;
            pbFloor.BackColor = Color.Transparent;
        }

        private void picBoxFireExtinguisher_Click(object sender, EventArgs e)
        {
            element = GUIElement.FIREEX;
            picBoxFireExtinguisher.BackColor = Color.DimGray;
            picBoxWall.BackColor = Color.Transparent;
            picBoxFire.BackColor = Color.Transparent;
            picBoxPerson.BackColor = Color.Transparent; 
            picBoxEraser.BackColor = Color.Transparent;
            pbFloor.BackColor = Color.Transparent;
        }

        private void picBoxFire_Click(object sender, EventArgs e)
        {
            element = GUIElement.FIRE;
            picBoxFire.BackColor = Color.DimGray;
            picBoxWall.BackColor = Color.Transparent;
            picBoxFireExtinguisher.BackColor = Color.Transparent;
            picBoxPerson.BackColor = Color.Transparent; 
            picBoxEraser.BackColor = Color.Transparent;
            pbFloor.BackColor = Color.Transparent;
        }

        private void picBoxPerson_Click(object sender, EventArgs e)
        {
            element = GUIElement.PERSON;
            picBoxPerson.BackColor = Color.DimGray;
            picBoxWall.BackColor = Color.Transparent;
            picBoxFireExtinguisher.BackColor = Color.Transparent;
            picBoxFire.BackColor = Color.Transparent;
            picBoxEraser.BackColor = Color.Transparent;
            pbFloor.BackColor = Color.Transparent;
        }

        private void picBoxEraser_Click(object sender, EventArgs e)
        {
            element = GUIElement.ERASER;
            picBoxEraser.BackColor = Color.DimGray;
            picBoxWall.BackColor = Color.Transparent;
            picBoxFireExtinguisher.BackColor = Color.Transparent;
            picBoxFire.BackColor = Color.Transparent;
            picBoxPerson.BackColor = Color.Transparent; 
            pbFloor.BackColor = Color.Transparent;
        }

        private void pbFloor_Click(object sender, EventArgs e)
        {
            element = GUIElement.FLOOR;
            pbFloor.BackColor = Color.DimGray;
            picBoxWall.BackColor = Color.Transparent;
            picBoxFireExtinguisher.BackColor = Color.Transparent;
            picBoxFire.BackColor = Color.Transparent;
            picBoxPerson.BackColor = Color.Transparent; 
            picBoxEraser.BackColor = Color.Transparent;
        }

        private (int Width, int Height) getSizePerPixel()
        {
            return (pbSimulation.Width / gridController.GridWidth, pbSimulation.Height / gridController.GridHeight);
        }

        private (int Width, int Height) getMaxSize()
        {
            var sizePixel = getSizePerPixel();
            return (sizePixel.Width * gridController.GridWidth, sizePixel.Height * gridController.GridHeight);
        }

        private Pair getGridPosFromPbPos(int x, int y)
        {
            var sizePerPixel = getSizePerPixel();
            var maxSize = getMaxSize();

            int yVal = y / sizePerPixel.Height;
            int xVal = x / sizePerPixel.Width;

            if (xVal > maxSize.Width || yVal > maxSize.Height || xVal > gridController.GridWidth - 1 || yVal > gridController.GridHeight - 1)
                return null;

            return new Pair(xVal, yVal);
        }

        private void drawGrid(Graphics g)
        {
            var sizePerPixel = getSizePerPixel();
            var maxSize = getMaxSize();

            int k = 0;

            for (int x = 0; x <= gridController.GridWidth; x++)
            {
                int pos = x * sizePerPixel.Width;
                g.DrawLine(Pens.Black, pos, 0, pos, maxSize.Height);

                k += pos;
            }

            for (int y = 0; y <= gridController.GridHeight; y++)
            {
                int pos = y * sizePerPixel.Height;
                g.DrawLine(Pens.Black, 0, pos, maxSize.Width, pos);
            }
        }

        private void drawBitmap(Graphics g)
        {
            var bitmap = gridController.Paint(getSizePerPixel());
            var maxSize = getMaxSize();

            g.DrawImage(bitmap, 0, 0, maxSize.Width, maxSize.Height);
        }

        private void drawSample(Graphics g)
        {
            var sizePerPixel = getSizePerPixel();

            if (prevCurPos != null && curCurPos != null)
            {
                if (element == GUIElement.WALL)
                {
                    var orderedPoints = orderPoints(prevCurPos, curCurPos, sizePerPixel);
                    Brush brush = new SolidBrush(Color.FromArgb(190, Wall.Color));

                    if (orderedPoints.Width > orderedPoints.Height)
                        g.FillRectangle(brush, orderedPoints.X, prevCurPos.Y * sizePerPixel.Height, orderedPoints.Width, sizePerPixel.Height);
                    else
                        g.FillRectangle(brush, prevCurPos.X * sizePerPixel.Width, orderedPoints.Y, sizePerPixel.Width, orderedPoints.Height);

                    g.FillRectangle(Brushes.Gray, prevCurPos.X * sizePerPixel.Width, prevCurPos.Y * sizePerPixel.Height, sizePerPixel.Width, sizePerPixel.Height);
                }
                else if (element == GUIElement.FLOOR || element == GUIElement.ERASER)
                {
                    Brush brush;

                    if (element == GUIElement.FLOOR)
                        brush = new SolidBrush(Color.FromArgb(190, Floor.Color));
                    else
                        brush = this.erasorBrush;

                    g.FillRectangle(brush, orderPoints(prevCurPos, curCurPos, sizePerPixel));
                    g.FillRectangle(Brushes.Gray, prevCurPos.X * sizePerPixel.Width, prevCurPos.Y * sizePerPixel.Height, sizePerPixel.Width, sizePerPixel.Height);
                }
            }
        }

        private Rectangle orderPoints(Pair prevCurPos, Pair curCurPos, (int Width, int Height)? sizePerPixel = null)
        {
            int leftmostX = Math.Min(prevCurPos.X, curCurPos.X);
            int topmostY = Math.Min(prevCurPos.Y, curCurPos.Y);
            int rightmostX = Math.Max(prevCurPos.X, curCurPos.X);
            int bottommostY = Math.Max(prevCurPos.Y, curCurPos.Y);

            if (sizePerPixel == null)
                return new Rectangle(
                    leftmostX,
                    topmostY,
                    (rightmostX - leftmostX + 1),
                    (bottommostY - topmostY + 1)
                );
            else
                return new Rectangle(
                    leftmostX * (int)sizePerPixel?.Width,
                    topmostY * (int)sizePerPixel?.Height,
                    (rightmostX - leftmostX + 1) * (int)sizePerPixel?.Width,
                    (bottommostY - topmostY + 1) * (int)sizePerPixel?.Height
                );
        }

        //private void save()
        //{
        //    using (var dialog = new SaveFileDialog())
        //    {
        //        dialog.Filter = "Binary|*.bin";
        //        dialog.CheckPathExists = true;
        //        dialog.AddExtension = true;
        //        dialog.DefaultExt = ".bin";

        //        if (dialog.ShowDialog() == DialogResult.OK)
        //            this.gridController.Save(dialog.FileName);
        //    }
        //}

        //private void open()
        //{
        //    using (var dialog = new OpenFileDialog())
        //    {
        //        dialog.Filter = "Binary|*.bin|All|*";
        //        dialog.CheckPathExists = true;
        //        dialog.CheckFileExists = true;
        //        dialog.DefaultExt = ".bin";

        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            var grid = GridController.Load(dialog.FileName);

        //            if (grid == null)
        //                MessageBox.Show("The file could not be parsed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            else
        //            {
        //                this.gridController = grid;
        //                pbSimulation.Invalidate();
        //            }
        //        }
        //    }
        //}

        
        private void pbSimulation_Paint(object sender, PaintEventArgs e)
        {
            drawBitmap(e.Graphics);
            drawSample(e.Graphics);
            drawGrid(e.Graphics);
        }

       
        private void pbSimulation_Resize(object sender, EventArgs e)
        {
            pbSimulation.Invalidate();
        }

        
        private void pbSimulation_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = getGridPosFromPbPos(e.X, e.Y);

            if (pos != null)
            {
                if (element == GUIElement.FLOOR || element == GUIElement.WALL || element == GUIElement.ERASER)
                {
                    if (prevCurPos == null)
                    {
                        this.pbSimulation.MouseMove += new MouseEventHandler(this.pbSimulation_MouseMove);
                        //lblEscMessage.Visible = true;
                        prevCurPos = pos;
                    }
                    else
                    {
                        var orderedPoints = orderPoints(prevCurPos, pos);

                        if (element == GUIElement.FLOOR)
                            gridController.FillFloor((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, orderedPoints.Height);
                        else if (element == GUIElement.ERASER)
                            gridController.ClearArea((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, orderedPoints.Height);
                        else if (element == GUIElement.WALL)
                        {
                            if (orderedPoints.Width > orderedPoints.Height)
                                gridController.FillWall((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, true);
                            else
                                gridController.FillWall((orderedPoints.X, orderedPoints.Y), orderedPoints.Height, false);
                        }

                        rb_CheckedChanged_Reset(null, null);
                    }
                }
                else
                {
                    rb_CheckedChanged_Reset(null, null);

                    var posTuple = pos.ToTuple();
                    if (gridController.GetAt(posTuple) is Floor)
                    {
                        if (element == GUIElement.FIRE)
                            gridController.PutFire(posTuple);
                        else if (element == GUIElement.PERSON)
                            gridController.PutPerson(posTuple);
                        else if (element == GUIElement.FIREEX)
                            gridController.PutFireExtinguisher(posTuple);
                    }
                }

                pbSimulation.Invalidate();
            }
        }

        
        private void pbSimulation_MouseMove(object sender, MouseEventArgs e)
        {
            curCurPos = getGridPosFromPbPos(e.X, e.Y);

            if (curCurPos != null)
                pbSimulation.Invalidate();
        }

        private void rb_CheckedChanged_Reset(object sender, EventArgs e)
        {
            this.pbSimulation.MouseMove -= new MouseEventHandler(this.pbSimulation_MouseMove);
            //lblEscMessage.Visible = false;
            prevCurPos = null;
            curCurPos = null;

            pbSimulation.Invalidate();
        }

        //private void Designer_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //        rb_CheckedChanged_Reset(null, null);
        //    else if (e.Control)
        //    {
        //        if (e.KeyCode == Keys.S)
        //            this.save();
        //        else if (e.KeyCode == Keys.O)
        //            this.open();
        //    }
        //}

        private enum GUIElement
        {
            FLOOR, 
            WALL,
            FIRE,
            PERSON,
            ERASER,
            FIREEX
        }

        internal class Pair
        {
            public readonly int X, Y;

            public Pair(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public Pair((int x, int y) tuple)
            {
                this.X = tuple.x;
                this.Y = tuple.y;
            }

            public (int X, int Y) ToTuple()
            {
                return (this.X, this.Y);
            }

            public override string ToString()
            {
                return $"({this.X}, {this.Y})";
            }
        }

       
    }
}
