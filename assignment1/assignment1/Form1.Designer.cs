namespace assignment1
{
    partial class Form1
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
            this.tbProgram = new System.Windows.Forms.TextBox();
            this.lbCommand = new System.Windows.Forms.Label();
            this.tbCMD = new System.Windows.Forms.TextBox();
            this.lbCommandLine = new System.Windows.Forms.Label();
            this.DrawArea = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawArea)).BeginInit();
            this.SuspendLayout();
            // 
            // tbProgram
            // 
            this.tbProgram.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbProgram.Location = new System.Drawing.Point(12, 34);
            this.tbProgram.Multiline = true;
            this.tbProgram.Name = "tbProgram";
            this.tbProgram.Size = new System.Drawing.Size(382, 340);
            this.tbProgram.TabIndex = 1;
            // 
            // lbCommand
            // 
            this.lbCommand.AutoSize = true;
            this.lbCommand.Location = new System.Drawing.Point(9, 18);
            this.lbCommand.Name = "lbCommand";
            this.lbCommand.Size = new System.Drawing.Size(77, 13);
            this.lbCommand.TabIndex = 2;
            this.lbCommand.Text = "Enter Program:";
            // 
            // tbCMD
            // 
            this.tbCMD.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbCMD.Location = new System.Drawing.Point(105, 383);
            this.tbCMD.Name = "tbCMD";
            this.tbCMD.Size = new System.Drawing.Size(289, 20);
            this.tbCMD.TabIndex = 3;
            this.tbCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCMD_KeyDown);
            // 
            // lbCommandLine
            // 
            this.lbCommandLine.AutoSize = true;
            this.lbCommandLine.Location = new System.Drawing.Point(23, 386);
            this.lbCommandLine.Name = "lbCommandLine";
            this.lbCommandLine.Size = new System.Drawing.Size(76, 13);
            this.lbCommandLine.TabIndex = 4;
            this.lbCommandLine.Text = "Command line:";
            // 
            // DrawArea
            // 
            this.DrawArea.Location = new System.Drawing.Point(416, 34);
            this.DrawArea.Name = "DrawArea";
            this.DrawArea.Size = new System.Drawing.Size(570, 340);
            this.DrawArea.TabIndex = 14;
            this.DrawArea.TabStop = false;
            this.DrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 422);
            this.Controls.Add(this.DrawArea);
            this.Controls.Add(this.lbCommandLine);
            this.Controls.Add(this.tbCMD);
            this.Controls.Add(this.lbCommand);
            this.Controls.Add(this.tbProgram);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DrawArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProgram;
        private System.Windows.Forms.Label lbCommand;
        private System.Windows.Forms.TextBox tbCMD;
        private System.Windows.Forms.Label lbCommandLine;
        public System.Windows.Forms.PictureBox DrawArea;
    }
}

