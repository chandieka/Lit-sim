namespace GridInterface
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBGrid = new System.Windows.Forms.PictureBox();
            this.BTTick = new System.Windows.Forms.Button();
            this.BTAutoTick = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PBGrid
            // 
            this.PBGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBGrid.Location = new System.Drawing.Point(12, 12);
            this.PBGrid.Name = "PBGrid";
            this.PBGrid.Size = new System.Drawing.Size(610, 426);
            this.PBGrid.TabIndex = 0;
            this.PBGrid.TabStop = false;
            // 
            // BTTick
            // 
            this.BTTick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTTick.Location = new System.Drawing.Point(671, 35);
            this.BTTick.Name = "BTTick";
            this.BTTick.Size = new System.Drawing.Size(75, 23);
            this.BTTick.TabIndex = 1;
            this.BTTick.Text = "Tick";
            this.BTTick.UseVisualStyleBackColor = true;
            // 
            // BTAutoTick
            // 
            this.BTAutoTick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTAutoTick.Appearance = System.Windows.Forms.Appearance.Button;
            this.BTAutoTick.Location = new System.Drawing.Point(671, 64);
            this.BTAutoTick.Name = "BTAutoTick";
            this.BTAutoTick.Size = new System.Drawing.Size(75, 23);
            this.BTAutoTick.TabIndex = 2;
            this.BTAutoTick.Text = "Auto";
            this.BTAutoTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BTAutoTick.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTAutoTick);
            this.Controls.Add(this.BTTick);
            this.Controls.Add(this.PBGrid);
            this.Name = "MainForm";
            this.Text = "Grid";
            ((System.ComponentModel.ISupportInitialize)(this.PBGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBGrid;
        private System.Windows.Forms.Button BTTick;
        private System.Windows.Forms.CheckBox BTAutoTick;
    }
}

