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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataDmx = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataDmx)).BeginInit();
            this.SuspendLayout();
            // 
            // dataDmx
            // 
            this.dataDmx.AllowUserToAddRows = false;
            this.dataDmx.AllowUserToDeleteRows = false;
            this.dataDmx.AllowUserToResizeColumns = false;
            this.dataDmx.AllowUserToResizeRows = false;
            this.dataDmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataDmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1});
            this.dataDmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataDmx.Location = new System.Drawing.Point(0, 0);
            this.dataDmx.Name = "dataDmx";
            this.dataDmx.Size = new System.Drawing.Size(324, 290);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Value";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 59;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 290);
            this.Controls.Add(this.dataDmx);
            this.Name = "FormMain";
            this.Text = "Artnet Display";
            ((System.ComponentModel.ISupportInitialize)(this.dataDmx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataDmx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

