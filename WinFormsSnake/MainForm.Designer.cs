namespace WinFormsSnake
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
            this.SnakeFieldGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.SnakeFieldGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SnakeFieldGrid
            // 
            this.SnakeFieldGrid.AllowUserToResizeColumns = false;
            this.SnakeFieldGrid.AllowUserToResizeRows = false;
            this.SnakeFieldGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SnakeFieldGrid.ColumnHeadersVisible = false;
            this.SnakeFieldGrid.Location = new System.Drawing.Point(12, 27);
            this.SnakeFieldGrid.Name = "SnakeFieldGrid";
            this.SnakeFieldGrid.RowHeadersVisible = false;
            this.SnakeFieldGrid.Size = new System.Drawing.Size(394, 394);
            this.SnakeFieldGrid.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 437);
            this.Controls.Add(this.SnakeFieldGrid);
            this.Name = "MainForm";
            this.Text = "Sneaky Snake";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.SnakeFieldGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SnakeFieldGrid;
    }
}

