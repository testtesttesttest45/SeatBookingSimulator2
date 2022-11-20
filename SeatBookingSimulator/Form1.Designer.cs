namespace SeatBookingSimulator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGenerateSeats = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panelSeats = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textRow = new System.Windows.Forms.TextBox();
            this.textCol = new System.Windows.Forms.TextBox();
            this.textBox_RowDiv = new System.Windows.Forms.TextBox();
            this.textBox_ColDiv = new System.Windows.Forms.TextBox();
            this.textBox_MaxSeats = new System.Windows.Forms.TextBox();
            this.ButtonA = new System.Windows.Forms.Button();
            this.ButtonB = new System.Windows.Forms.Button();
            this.ButtonC = new System.Windows.Forms.Button();
            this.ButtonD = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGenerateSeats
            // 
            this.buttonGenerateSeats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGenerateSeats.Location = new System.Drawing.Point(26, 284);
            this.buttonGenerateSeats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGenerateSeats.Name = "buttonGenerateSeats";
            this.buttonGenerateSeats.Size = new System.Drawing.Size(389, 41);
            this.buttonGenerateSeats.TabIndex = 0;
            this.buttonGenerateSeats.Text = "Smart Safe Distance Mode";
            this.buttonGenerateSeats.UseVisualStyleBackColor = true;
            this.buttonGenerateSeats.Click += new System.EventHandler(this.CreateSeats);
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMessage.Location = new System.Drawing.Point(13, 725);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(453, 196);
            this.labelMessage.TabIndex = 1;
            // 
            // panelSeats
            // 
            this.panelSeats.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeats.Location = new System.Drawing.Point(474, 14);
            this.panelSeats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(1294, 1007);
            this.panelSeats.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Khaki;
            this.label6.Location = new System.Drawing.Point(615, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(970, 50);
            this.label6.TabIndex = 10;
            this.label6.Text = "Screen";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(210, 5);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(135, 56);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoad.Location = new System.Drawing.Point(26, 5);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(135, 56);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(26, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seats  per row";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(26, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Row divider(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(26, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Column divider(s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(42, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Max Seats";
            // 
            // textRow
            // 
            this.textRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRow.Location = new System.Drawing.Point(195, 80);
            this.textRow.Name = "textRow";
            this.textRow.Size = new System.Drawing.Size(150, 31);
            this.textRow.TabIndex = 6;
            this.textRow.TextChanged += new System.EventHandler(this.TextRow_TextChanged);
            // 
            // textCol
            // 
            this.textCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCol.Location = new System.Drawing.Point(195, 121);
            this.textCol.Name = "textCol";
            this.textCol.Size = new System.Drawing.Size(150, 31);
            this.textCol.TabIndex = 6;
            this.textCol.TextChanged += new System.EventHandler(this.TextCol_TextChanged);
            // 
            // textBox_RowDiv
            // 
            this.textBox_RowDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RowDiv.Location = new System.Drawing.Point(195, 163);
            this.textBox_RowDiv.Name = "textBox_RowDiv";
            this.textBox_RowDiv.Size = new System.Drawing.Size(150, 31);
            this.textBox_RowDiv.TabIndex = 6;
            this.textBox_RowDiv.TextChanged += new System.EventHandler(this.TextBox_RowDiv_TextChanged);
            // 
            // textBox_ColDiv
            // 
            this.textBox_ColDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ColDiv.Location = new System.Drawing.Point(195, 202);
            this.textBox_ColDiv.Name = "textBox_ColDiv";
            this.textBox_ColDiv.Size = new System.Drawing.Size(150, 31);
            this.textBox_ColDiv.TabIndex = 6;
            this.textBox_ColDiv.TextChanged += new System.EventHandler(this.TextBox_ColDiv_TextChanged);
            // 
            // textBox_MaxSeats
            // 
            this.textBox_MaxSeats.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_MaxSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_MaxSeats.Enabled = false;
            this.textBox_MaxSeats.Location = new System.Drawing.Point(149, 385);
            this.textBox_MaxSeats.Name = "textBox_MaxSeats";
            this.textBox_MaxSeats.Size = new System.Drawing.Size(187, 31);
            this.textBox_MaxSeats.TabIndex = 6;
            this.textBox_MaxSeats.TextChanged += new System.EventHandler(this.MaxSeatsChanged);
            // 
            // ButtonA
            // 
            this.ButtonA.BackColor = System.Drawing.Color.Gold;
            this.ButtonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonA.Location = new System.Drawing.Point(61, 438);
            this.ButtonA.Name = "ButtonA";
            this.ButtonA.Size = new System.Drawing.Size(284, 34);
            this.ButtonA.TabIndex = 7;
            this.ButtonA.Text = "Person A Booking";
            this.ButtonA.UseVisualStyleBackColor = false;
            this.ButtonA.Click += new System.EventHandler(this.ButtonA_Click);
            // 
            // ButtonB
            // 
            this.ButtonB.BackColor = System.Drawing.Color.SteelBlue;
            this.ButtonB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonB.Location = new System.Drawing.Point(61, 478);
            this.ButtonB.Name = "ButtonB";
            this.ButtonB.Size = new System.Drawing.Size(284, 34);
            this.ButtonB.TabIndex = 7;
            this.ButtonB.Text = "Person B Booking";
            this.ButtonB.UseVisualStyleBackColor = false;
            this.ButtonB.Click += new System.EventHandler(this.ButtonB_Click);
            // 
            // ButtonC
            // 
            this.ButtonC.BackColor = System.Drawing.Color.Crimson;
            this.ButtonC.Location = new System.Drawing.Point(61, 518);
            this.ButtonC.Name = "ButtonC";
            this.ButtonC.Size = new System.Drawing.Size(284, 34);
            this.ButtonC.TabIndex = 7;
            this.ButtonC.Text = "Person C Booking";
            this.ButtonC.UseVisualStyleBackColor = false;
            this.ButtonC.Click += new System.EventHandler(this.ButtonC_Click);
            // 
            // ButtonD
            // 
            this.ButtonD.BackColor = System.Drawing.Color.Teal;
            this.ButtonD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonD.Location = new System.Drawing.Point(65, 558);
            this.ButtonD.Name = "ButtonD";
            this.ButtonD.Size = new System.Drawing.Size(284, 34);
            this.ButtonD.TabIndex = 7;
            this.ButtonD.Text = "Person D Booking";
            this.ButtonD.UseVisualStyleBackColor = false;
            this.ButtonD.Click += new System.EventHandler(this.ButtonD_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Silver;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonReset.Location = new System.Drawing.Point(65, 633);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(284, 34);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.Text = "Reset Simulation";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonUndo.Location = new System.Drawing.Point(354, 27);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(112, 34);
            this.buttonUndo.TabIndex = 9;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRedo.Location = new System.Drawing.Point(355, 75);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(112, 34);
            this.buttonRedo.TabIndex = 9;
            this.buttonRedo.Text = "Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonRedo);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.ButtonD);
            this.Controls.Add(this.ButtonC);
            this.Controls.Add(this.ButtonB);
            this.Controls.Add(this.ButtonA);
            this.Controls.Add(this.textBox_MaxSeats);
            this.Controls.Add(this.textBox_ColDiv);
            this.Controls.Add(this.textBox_RowDiv);
            this.Controls.Add(this.textCol);
            this.Controls.Add(this.textRow);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panelSeats);
            this.Controls.Add(this.buttonGenerateSeats);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateSeats;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Panel panelSeats;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRow;
        private System.Windows.Forms.TextBox textCol;
        private System.Windows.Forms.TextBox textBox_RowDiv;
        private System.Windows.Forms.TextBox textBox_ColDiv;
        private System.Windows.Forms.TextBox textBox_MaxSeats;
        private System.Windows.Forms.Button ButtonA;
        private System.Windows.Forms.Button ButtonB;
        private System.Windows.Forms.Button ButtonC;
        private System.Windows.Forms.Button ButtonD;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.Label label6;
    }
}
