using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FireSimulator
{
    public partial class FireSimulatorForm : Form
    {
        private TimeSpan time = new TimeSpan(0, 0, 0);
        private GridController gridController;
        private GridController gcStartingPosition;
        private bool building = true;
        private GUIElement element;
        private Pair prevCurPos;
        private Pair curCurPos;

        private Dictionary<PictureBox, GUIElement> buildSelectables =
            new Dictionary<PictureBox, GUIElement>();

        private bool testingTicks = true;
        private bool running;

        private Brush erasorBrush = new SolidBrush(Color.FromArgb(120, Color.Salmon));

        public FireSimulatorForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            tbTimer.Text = time.ToString();
            this.Text = "Fire Escape Simulator";

            buildSelectables.Add(picBoxFireExtinguisher, GUIElement.FIREEX);
            buildSelectables.Add(picBoxPerson, GUIElement.PERSON);
            buildSelectables.Add(picBoxEraser, GUIElement.ERASER);
            buildSelectables.Add(picBoxFloor, GUIElement.FLOOR);
            buildSelectables.Add(picBoxWall, GUIElement.WALL);
            buildSelectables.Add(picBoxFire, GUIElement.FIRE);

            // Grid Initialization
            var newGrid = new GridController((100, 100));
            newGrid.PutDefaultFloorPlan(1);
            //newGrid.ShouldDrawPaths = !building;
            setupGrid(newGrid);
            FillDefault();
            SaveStartingLayout();

            // TODO: Fix the AutoLoad Feature
            //if (GridController.IsLoadable())
            //{
            //    var grid = GridController.Load(GridController.defaultPath);

            //    if (grid == null)
            //        MessageBox.Show("Unable to parse the file to an object", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    else
            //    {
            //        setupGrid(grid);
            //    }
            //}

            VisualizeSimulation();
        }

        private void setupGrid(GridController newGrid)
        {
            if (this.gridController != null)
                this.gridController.Finished -= this.handleFinished;

            newGrid.Finished += this.handleFinished;
            this.gridController = newGrid;
            VisualizeSimulation();
        }

        private void SaveStartingLayout()
        {
            gcStartingPosition = new GridController(gridController.DeepCloneBlock());
            gcStartingPosition.Finished += handleFinished;
        }

        private void handleFinished(object sender, EventArgs e)
        {
            this.gridController.AddToHistory("Simulation finished");
            picBoxPlayPause_Click(null, null);
            GetStats();
            btnRerunSimulation.Visible = true;
            lblResult.Text = "Success";
            picBoxPlayPause.Enabled = false;

            MessageBox.Show("The simulation finished", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Private Methods

        private void DisableButtons()
        {
            picBoxWall.Enabled = false;
            picBoxFireExtinguisher.Enabled = false;
            picBoxFire.Enabled = false;
            picBoxPerson.Enabled = false;
            picBoxEraser.Enabled = false;
            picBoxFloor.Enabled = false;
            picBoxReset.Enabled = false;
            btnGenerate.Enabled = false;
            btnSaveLayout.Enabled = false;
            btnUploadFile.Enabled = false;
            btnCalculatePaths.Enabled = false;
            lblBuild.Enabled = false;
            lblGenerate.Enabled = false;
            pbSimulator.Enabled = false;
        }

        private void EnableButtons()
        {
            picBoxWall.Enabled = true;
            picBoxFireExtinguisher.Enabled = true;
            picBoxFire.Enabled = true;
            picBoxPerson.Enabled = true;
            picBoxEraser.Enabled = true;
            picBoxFloor.Enabled = true;
            picBoxReset.Enabled = true;
            btnGenerate.Enabled = true;
            btnSaveLayout.Enabled = true;
            btnUploadFile.Enabled = true;
            btnCalculatePaths.Enabled = true;
            lblBuild.Enabled = true;
            lblGenerate.Enabled = true;
            pbSimulator.Enabled = true;
        }

        private void UpdateHistory()
        {
            this.lbHistor.Items.Clear();

            this.lbHistor.Items.AddRange(this.gridController.GetHistory());
        }

        private void FillDefault()
        {
            Random r = new Random();

            gridController.RandomizeFire(1, r.Next());
            gridController.RandomizePersons(10, r.Next());
            gridController.RandomizeFireExtinguishers(20, r.Next());
            GetStats();
        }

        private void GetStats()
        {
            int people = gridController.GetNrOfPeople();
            int deaths = gridController.GetTotalDeaths();
            int fireExtinguishers = gridController.GetNrOfFireExtinguishers();
            int alive = people - deaths;

            if (people == deaths)
                lblResult.Text = "Fail";

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
                gridController.ShouldDrawPaths = true;

                // building icon turn of

                picBoxWall.Visible = false;
                picBoxFireExtinguisher.Visible = false;
                picBoxFire.Visible = false;
                picBoxPerson.Visible = false;
                picBoxEraser.Visible = false;
                picBoxReset.Visible = false;

                // generating icon turn on
                tbPeople.Visible = true;
                tbFireExtinguishers.Visible = true;
                lblPeople.Visible = true;
                lblFireExtinguishers.Visible = true;
                btnGenerate.Visible = true;
                lblMaxFireEx.Visible = true;
                lblMaxPeople.Visible = true;

                building = false;
                picBoxFloor.Visible = false;
            }
            else
            {
                lblGenerate.Font = new Font(lblGenerate.Font, FontStyle.Regular);
                lblBuild.Font = new Font(lblBuild.Font, FontStyle.Underline);
                gridController.ShouldDrawPaths = false;

                // building icon turn on
                picBoxWall.Visible = true;
                picBoxFireExtinguisher.Visible = true;
                picBoxFire.Visible = true;
                picBoxPerson.Visible = true;
                picBoxEraser.Visible = true;
                picBoxReset.Visible = true;

                // generating icon turn off
                tbPeople.Visible = false;
                tbFireExtinguishers.Visible = false;
                lblPeople.Visible = false;
                lblFireExtinguishers.Visible = false;
                btnGenerate.Visible = false;
                lblMaxFireEx.Visible = false;
                lblMaxPeople.Visible = false;
                building = true;
                picBoxFloor.Visible = true;
            }

            int personSpots = gridController.GetFloorBlocks().Count - gridController.GetFireExtinguisherSpot();
            int fireSpots = gridController.GetFireExtinguisherSpot();
            lblMaxPeople.Text = "Max: " + personSpots.ToString();
            lblMaxFireEx.Text = "Max: " + fireSpots.ToString();
        }

        private void VisualizeSimulation()
        {
            Bitmap bmp = gridController.Paint((6, 6));
            pbSimulator.Image = bmp;
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
                EnableButtons();
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

                try
                {
                    animationLoopTimer.Start();
                    running = true;
                    picBoxPlayPause.Image = Icons.Pause;
                    toolTipPlay.SetToolTip(picBoxPlayPause, "Pause (Spacebar)");
                    this.gridController.AddToHistory("Simulation started");
                    UpdateHistory();
                    this.lbHistor.Enabled = false;
                    btnTerminate.Visible = false;
                    DisableButtons();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName);
                }                
            }
            else
            {
                animationLoopTimer.Stop();
                running = false;
                picBoxPlayPause.Image = Icons.Play;
                toolTipPlay.SetToolTip(picBoxPlayPause, "Resume (Spacebar)");
                this.gridController.AddToHistory("Simulation paused");
                UpdateHistory();
                this.lbHistor.Enabled = true;
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
                this.gridController.Save(GridController.defaultPath);
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
                    this.gridController.Save(myDialog.FileName);
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
                        MessageBox.Show("Unable to parse the file to an object", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        setupGrid(grid);
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool isSuccess = true;
            Random r = new Random();
            // lastGrid = gridController;

            this.picBoxPlayPause.Enabled = false;

            btnTerminate.Visible = false;
            btnRerunSimulation.Visible = false;
            // clear the map
            gridController.Clear();
            // get the basic floor plan
            gridController.PutDefaultFloorPlan(1);
            // add fire to the map
            gridController.RandomizeFire(1, r.Next());

            if (!int.TryParse(tbPeople.Text, out int amountPeople))
            {
                if (amountPeople < 0)
                {
                    MessageBox.Show("Please enter more than 1 in the person field");
                }
                else
                {
                    MessageBox.Show("Please enter number in the fields!");
                }
                isSuccess &= false;
            }
            else if (!int.TryParse(tbFireExtinguishers.Text, out int amountFireEx))
            {

                if (amountPeople < 0)
                {
                    MessageBox.Show("Please enter more than 1 in the fire extinguishers field");
                }
                else
                {
                    MessageBox.Show("Please enter number in the fields!");
                }

                isSuccess &= false;
            }
            else if (!this.gridController.RandomizePersons(amountPeople, r.Next()))
            {
                isSuccess &= false;
                MessageBox.Show("Number of person exceed map capacity");
            }
            else if (!this.gridController.RandomizeFireExtinguishers(amountFireEx, r.Next()))
            {
                isSuccess &= false;
                MessageBox.Show("Number of Fire Extinguishers exceed map capacity");
            }

            // visualize the map
            // not wasting computing power if its not successfull
            if (isSuccess)
            {
                SaveStartingLayout();
                VisualizeSimulation();
                this.gridController.AddToHistory("Random generated");
                UpdateHistory();
            }
        }

        private void btnRerunSimulation_Click(object sender, EventArgs e)
        {
            gridController = gcStartingPosition;
            SaveStartingLayout();
            VisualizeSimulation();
            time = TimeSpan.Zero;
            tbTimer.Text = time.ToString();
            btnRerunSimulation.Visible = false;
            btnTerminate.Visible = false;
            lblResult.Text = "<Success/Fail>";
            trackBarSpeed.Value = 50;
            animationLoopTimer.Interval = 60;
            EnableButtons();
            GetStats();
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

        private void lbHistor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbHistor.SelectedItem != null)
            {
                History grid = (History)this.lbHistor.SelectedItem;
                this.gridController = new GridController(grid.Grid);
                VisualizeSimulation();
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to terminate the simulation?", "Terminate Simulation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (building)
                {
                    // TODO: Load the Custom User FloorPlan
                    gridController.Clear();

                    // temporary
                    gridController.PutDefaultFloorPlan(1);
                    FillDefault();
                    SaveStartingLayout();
                    //

                    VisualizeSimulation();
                }
                else
                {
                    gridController.Clear();
                    gridController.PutDefaultFloorPlan(1);
                    FillDefault();
                    SaveStartingLayout();
                    VisualizeSimulation();
                }
                time = TimeSpan.Zero;
                tbTimer.Text = time.ToString();
                GetStats();
                btnTerminate.Visible = false;
                trackBarSpeed.Value = 50;
                animationLoopTimer.Interval = 60;
                EnableButtons();
                lblResult.Text = "<Success/Fail>";
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

        private void picBoxDesigner_Click(object sender, EventArgs e)
        {
            foreach (var p in buildSelectables)
            {
                if (p.Key != sender)
                    p.Key.BackColor = Color.Transparent;
                else
                {
                    p.Key.BackColor = Color.LightGray;
                    element = p.Value;
                }
            }
        }

        private (int Width, int Height) getSizePerPixel()
        {
            return (pbSimulator.Width / gridController.GridWidth, pbSimulator.Height / gridController.GridHeight);
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

        private void pbSimulation_Paint(object sender, PaintEventArgs e)
        {
            drawBitmap(e.Graphics);
            drawSample(e.Graphics);

            if (cbGrid.Checked)
                drawGrid(e.Graphics);
        }

        private void pbSimulation_Resize(object sender, EventArgs e)
        {
            pbSimulator.Invalidate();
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
                        this.pbSimulator.MouseMove += new MouseEventHandler(this.pbSimulation_MouseMove);
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

                        string reason = string.Empty;
                        if (element == GUIElement.ERASER)
                        {
                            reason = "Eraser used";
                        }
                        else
                        {
                            string before = String.Format("{0} created", element).ToLower();
                            reason = before.Substring(0, 1).ToUpper() + before.Substring(1);
                        }

                        this.gridController.AddToHistory(reason);
                        UpdateHistory();
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

                        string before = String.Format("{0} added", element).ToLower();
                        string reason = before.Substring(0, 1).ToUpper() + before.Substring(1);
                        this.gridController.AddToHistory(reason);
                        UpdateHistory();
                    }
                }

                pbSimulator.Invalidate();
            }
        }

        private void pbSimulation_MouseMove(object sender, MouseEventArgs e)
        {
            curCurPos = getGridPosFromPbPos(e.X, e.Y);

            if (curCurPos != null)
                pbSimulator.Invalidate();
        }

        private void rb_CheckedChanged_Reset(object sender, EventArgs e)
        {
            this.pbSimulator.MouseMove -= new MouseEventHandler(this.pbSimulation_MouseMove);
            //lblEscMessage.Visible = false;
            prevCurPos = null;
            curCurPos = null;

            pbSimulator.Invalidate();
        }

        // TODO
        //private void Designer_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //        rb_CheckedChanged_Reset(null, null);
        //    else if (e.Control)
        //    {
        //        if (e.KeyCode == Keys.S)
        //        {
        //            //this.save();
        //        }
        //        else if (e.KeyCode == Keys.O)
        //        {
        //            //this.open();
        //        }
        //    }
        //}

        private void pbReset_Click(object sender, EventArgs e)
        {
            gridController.Clear();
            VisualizeSimulation();
        }

        private void cbGrid_CheckedChanged(object sender, EventArgs e)
        {
            pbSimulator.Invalidate();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Statistics formStat = new Statistics();
            formStat.Show();
        }
    }
}
