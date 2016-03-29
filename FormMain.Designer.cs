namespace ArtnetDisplay {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataDmx = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.light = new System.Windows.Forms.Panel();
            this.labelIP = new System.Windows.Forms.Label();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataDmx)).BeginInit();
            this.SuspendLayout();
            // 
            // dataDmx
            // 
            this.dataDmx.AllowUserToAddRows = false;
            this.dataDmx.AllowUserToDeleteRows = false;
            this.dataDmx.AllowUserToResizeColumns = false;
            this.dataDmx.AllowUserToResizeRows = false;
            this.dataDmx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataDmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataDmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1});
            this.dataDmx.Location = new System.Drawing.Point(0, 27);
            this.dataDmx.Name = "dataDmx";
            this.dataDmx.RowHeadersVisible = false;
            this.dataDmx.Size = new System.Drawing.Size(324, 263);
            this.dataDmx.TabIndex = 0;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Channel";
            this.Column2.HeaderText = "Channel";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 71;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Value";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.HeaderText = "Value";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 59;
            // 
            // light
            // 
            this.light.Location = new System.Drawing.Point(1, 2);
            this.light.Name = "light";
            this.light.Size = new System.Drawing.Size(22, 21);
            this.light.TabIndex = 1;
            this.light.Paint += new System.Windows.Forms.PaintEventHandler(this.light_Paint);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(28, 8);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(0, 13);
            this.labelIP.TabIndex = 2;
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 500;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 290);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.light);
            this.Controls.Add(this.dataDmx);
            this.Name = "FormMain";
            this.Text = "Artnet Display";
            ((System.ComponentModel.ISupportInitialize)(this.dataDmx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataDmx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel light;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Timer timerTick;
    }
}

