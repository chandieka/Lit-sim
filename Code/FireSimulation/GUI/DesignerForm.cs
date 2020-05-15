using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Library;

namespace FireSimulator
{
	public partial class DesignerForm : Form
	{
		private Designer designer;
		private GUIElement element;
		private Dictionary<PictureBox, GUIElement> buildSelectables =
			new Dictionary<PictureBox, GUIElement>();

		private Pair prevCurPos;
		private Pair curCurPos;

		private Brush erasorBrush = new SolidBrush(Color.FromArgb(120, Color.Salmon));

		private bool isFloorplan = false;

		public DesignerForm(int width, int height)
		{
			InitializeComponent();
			designer = new Designer(new GridController((width, height)), pictureBoxGrid.Width, pictureBoxGrid.Height);
			FormInit();
		}

		public DesignerForm(FloorplanController fpc)
		{
			InitializeComponent();
			designer = new Designer(new GridController((100, 100)), pictureBoxGrid.Width, pictureBoxGrid.Height);
			FormInit();
			isFloorplan = true;
		}

		public DesignerForm(Floorplan f)
		{
			InitializeComponent();
			designer = new Designer(f.ToGridController(), pictureBoxGrid.Width, pictureBoxGrid.Height);
			FormInit();
			isFloorplan = false;
		}

		private void FormInit()
		{
			buildSelectables.Add(picBoxFireExtinguisher, GUIElement.FIREEX);
			buildSelectables.Add(picBoxPerson, GUIElement.PERSON);
			buildSelectables.Add(picBoxEraser, GUIElement.ERASER);
			buildSelectables.Add(picBoxFloor, GUIElement.FLOOR);
			buildSelectables.Add(picBoxWall, GUIElement.WALL);
			buildSelectables.Add(picBoxFire, GUIElement.FIRE);
			picBoxFloor.BackColor = Color.LightGray;
		}

		private void pictureBoxGrid_Paint(object sender, PaintEventArgs e)
		{
			designer.drawBitmap(e.Graphics);
			designer.drawSample(e.Graphics, element, curCurPos, prevCurPos);
			if (cbGrid.Checked)
				designer.drawGrid(e.Graphics);
		}

		private void pictureBoxGrid_Resize(object sender, EventArgs e)
		{
			pictureBoxGrid.Invalidate();
		}

		private void pictureBoxGrid_MouseClick(object sender, MouseEventArgs e)
		{
			var pos = designer.getGridPosFromPbPos(e.X, e.Y);

			if (pos != null)
			{
				if (element == GUIElement.FLOOR || element == GUIElement.WALL || element == GUIElement.ERASER)
				{
					if (prevCurPos == null)
					{
						this.pictureBoxGrid.MouseMove += new MouseEventHandler(this.pictureBoxGrid_MouseMove);
						lblEscMessage.Visible = true;
						prevCurPos = pos;
					}
					else
					{
						var orderedPoints = designer.orderPoints(prevCurPos, pos);

						if (element == GUIElement.FLOOR)
							designer.FillFloor((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, orderedPoints.Height);
						else if (element == GUIElement.ERASER)
							designer.ClearArea((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, orderedPoints.Height);
						else if (element == GUIElement.WALL)
						{
							if (orderedPoints.Width > orderedPoints.Height)
								designer.FillWall((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, true);
							else
								designer.FillWall((orderedPoints.X, orderedPoints.Y), orderedPoints.Height, false);
						}

						rb_CheckedChanged_Reset(null, null);
					}
				}
				else
				{
					rb_CheckedChanged_Reset(null, null);

					var posTuple = pos.ToTuple();
					if (designer.GetAt(posTuple) is Floor)
					{
						if (element == GUIElement.FIRE)
							designer.PutFire(posTuple);
						else if (element == GUIElement.PERSON)
							designer.PutPerson(posTuple);
						else if (element == GUIElement.FIREEX)
							designer.PutFireExtinguisher(posTuple);
					}
				}

				pictureBoxGrid.Invalidate();
			}
		}

		private void pictureBoxGrid_MouseMove(object sender, MouseEventArgs e)
		{
			curCurPos = designer.getGridPosFromPbPos(e.X, e.Y);

			if (curCurPos != null)
				pictureBoxGrid.Invalidate();
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

		private void rb_CheckedChanged_Reset(object sender, EventArgs e)
		{
			this.pictureBoxGrid.MouseMove -= new MouseEventHandler(this.pictureBoxGrid_MouseMove);
			lblEscMessage.Visible = false;
			prevCurPos = null;
			curCurPos = null;

			pictureBoxGrid.Invalidate();
		}

		private void Designer_KeyUp(object sender, KeyEventArgs e)
		{
			/*if (e.KeyCode == Keys.Escape)
				rb_CheckedChanged_Reset(null, null);
			else if (e.Control)
			{
				if (e.KeyCode == Keys.S)
					designer.SaveAsLayout();
				else if (e.KeyCode == Keys.O)
					designer.open();
			}*/
		}

		private void pbReset_Click(object sender, EventArgs e)
		{
			designer.ClearAll();
			pictureBoxGrid.Invalidate();
		}

		private void cbGrid_CheckedChanged(object sender, EventArgs e)
		{
			pictureBoxGrid.Invalidate();
		}
	}
}
