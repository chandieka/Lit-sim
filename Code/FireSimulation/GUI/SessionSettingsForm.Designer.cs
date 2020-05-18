namespace FireSimulator.GUI
{
    partial class SessionSettingsForm
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
            this.lbTimeLimit = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tbTimeLimitSeconds = new System.Windows.Forms.TextBox();
            this.tbTimeLimitMinutes = new System.Windows.Forms.TextBox();
            this.tbTimeLimitHours = new System.Windows.Forms.TextBox();
            this.lbTimeSpacer = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTimeLimit
            // 
            this.lbTimeLimit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTimeLimit.AutoSize = true;
            this.lbTimeLimit.Location = new System.Drawing.Point(105, 62);
            this.lbTimeLimit.Name = "lbTimeLimit";
            this.lbTimeLimit.Size = new System.Drawing.Size(54, 13);
            this.lbTimeLimit.TabIndex = 0;
            this.lbTimeLimit.Text = "Time Limit";
            // 
            // btSave
            // 
            this.btSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSave.Location = new System.Drawing.Point(14, 132);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(228, 33);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btCancel.Location = new System.Drawing.Point(248, 132);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(228, 33);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // tbTimeLimitSeconds
            // 
            this.tbTimeLimitSeconds.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTimeLimitSeconds.Location = new System.Drawing.Point(393, 59);
            this.tbTimeLimitSeconds.Name = "tbTimeLimitSeconds";
            this.tbTimeLimitSeconds.Size = new System.Drawing.Size(25, 20);
            this.tbTimeLimitSeconds.TabIndex = 4;
            // 
            // tbTimeLimitMinutes
            // 
            this.tbTimeLimitMinutes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTimeLimitMinutes.Location = new System.Drawing.Point(347, 59);
            this.tbTimeLimitMinutes.Name = "tbTimeLimitMinutes";
            this.tbTimeLimitMinutes.Size = new System.Drawing.Size(25, 20);
            this.tbTimeLimitMinutes.TabIndex = 5;
            // 
            // tbTimeLimitHours
            // 
            this.tbTimeLimitHours.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTimeLimitHours.Location = new System.Drawing.Point(300, 59);
            this.tbTimeLimitHours.Name = "tbTimeLimitHours";
            this.tbTimeLimitHours.Size = new System.Drawing.Size(25, 20);
            this.tbTimeLimitHours.TabIndex = 6;
            // 
            // lbTimeSpacer
            // 
            this.lbTimeSpacer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTimeSpacer.AutoSize = true;
            this.lbTimeSpacer.BackColor = System.Drawing.Color.Transparent;
            this.lbTimeSpacer.Location = new System.Drawing.Point(331, 62);
            this.lbTimeSpacer.Name = "lbTimeSpacer";
            this.lbTimeSpacer.Size = new System.Drawing.Size(10, 13);
            this.lbTimeSpacer.TabIndex = 7;
            this.lbTimeSpacer.Text = ":";
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(156, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(193, 29);
            this.lbTitle.TabIndex = 9;
            this.lbTitle.Text = "Session Settings";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(378, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = ":";
            // 
            // SessionSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 177);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbTimeSpacer);
            this.Controls.Add(this.tbTimeLimitHours);
            this.Controls.Add(this.tbTimeLimitMinutes);
            this.Controls.Add(this.tbTimeLimitSeconds);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lbTimeLimit);
            this.Name = "SessionSettingsForm";
            this.Text = "Session Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTimeLimit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox tbTimeLimitSeconds;
        private System.Windows.Forms.TextBox tbTimeLimitMinutes;
        private System.Windows.Forms.TextBox tbTimeLimitHours;
        private System.Windows.Forms.Label lbTimeSpacer;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
    }
}