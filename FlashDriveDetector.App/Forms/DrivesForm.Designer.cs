namespace FlashDriveDetector.Forms
{
    partial class DrivesForm
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
            this.cmdExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdEject = new System.Windows.Forms.Button();
            this.drivesList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdExit.Location = new System.Drawing.Point(0, 44);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(416, 35);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Выйти";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdEject);
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 223);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 79);
            this.panel1.TabIndex = 1;
            // 
            // cmdEject
            // 
            this.cmdEject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdEject.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdEject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdEject.Location = new System.Drawing.Point(0, 0);
            this.cmdEject.Name = "cmdEject";
            this.cmdEject.Size = new System.Drawing.Size(416, 35);
            this.cmdEject.TabIndex = 1;
            this.cmdEject.Text = "Извлечь";
            this.cmdEject.UseVisualStyleBackColor = false;
            this.cmdEject.Click += new System.EventHandler(this.cmdEject_Click);
            // 
            // drivesList
            // 
            this.drivesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.drivesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.drivesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drivesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drivesList.FormattingEnabled = true;
            this.drivesList.ItemHeight = 20;
            this.drivesList.Location = new System.Drawing.Point(0, 0);
            this.drivesList.Margin = new System.Windows.Forms.Padding(0);
            this.drivesList.Name = "drivesList";
            this.drivesList.Size = new System.Drawing.Size(416, 223);
            this.drivesList.TabIndex = 2;
            // 
            // DrivesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(416, 302);
            this.ControlBox = false;
            this.Controls.Add(this.drivesList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DrivesForm";
            this.Text = "DrivesForm";
            this.Activated += new System.EventHandler(this.DrivesForm_Activated);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox drivesList;
        private System.Windows.Forms.Button cmdEject;
    }
}