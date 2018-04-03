namespace WinFormsSnake
{
    partial class SnakeForm
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
            this.gamefieldDataGrid = new System.Windows.Forms.DataGridView();
            this.snakeLengthLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamefieldDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gamefieldDataGrid
            // 
            this.gamefieldDataGrid.AllowUserToResizeColumns = false;
            this.gamefieldDataGrid.AllowUserToResizeRows = false;
            this.gamefieldDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gamefieldDataGrid.ColumnHeadersVisible = false;
            this.gamefieldDataGrid.Location = new System.Drawing.Point(18, 71);
            this.gamefieldDataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gamefieldDataGrid.Name = "gamefieldDataGrid";
            this.gamefieldDataGrid.RowHeadersVisible = false;
            this.gamefieldDataGrid.RowHeadersWidth = 17;
            this.gamefieldDataGrid.Size = new System.Drawing.Size(591, 606);
            this.gamefieldDataGrid.TabIndex = 0;
            // 
            // snakeLengthLabel
            // 
            this.snakeLengthLabel.AutoSize = true;
            this.snakeLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snakeLengthLabel.Location = new System.Drawing.Point(14, 25);
            this.snakeLengthLabel.Name = "snakeLengthLabel";
            this.snakeLengthLabel.Size = new System.Drawing.Size(149, 25);
            this.snakeLengthLabel.TabIndex = 1;
            this.snakeLengthLabel.Text = "Snake length: 1";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 691);
            this.Controls.Add(this.snakeLengthLabel);
            this.Controls.Add(this.gamefieldDataGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameWindow";
            this.Text = "Sneaky Snake";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gamefieldDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gamefieldDataGrid;
        private System.Windows.Forms.Label snakeLengthLabel;
    }
}

