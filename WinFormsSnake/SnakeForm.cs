using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsSnake
{
    public partial class SnakeForm : Form, ISnakeView
    {
        private SnakePresenter presenter;
        private Timer timer = new Timer();

        public int RowsCount => 22;
        public int ColumnsCount => 23;
        
        public string SnakeLengthText
        {
            get { return snakeLengthLabel.Text; }

            set { snakeLengthLabel.Text = value; }
        }

        public SnakeForm()
        {
            InitializeComponent();
            InitializeGrid();
            BindEventHandlers();
            presenter = new SnakePresenter(this);        
            presenter.StartGame();
        }

        private void BindEventHandlers()
        {
            timer.Tick += Timer_Tick;
            gamefieldDataGrid.KeyDown += SnakeFieldGrid_KeyDown;
        }

        private void SnakeFieldGrid_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            presenter.OnKeyDown((Directions)e.KeyCode);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            presenter.OnTimerTick();
        }
        
        private void InitializeGrid()
        {
            int cellSize = 17;

            // enable double buffering to improve food rendering time.
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, gamefieldDataGrid, new object[] { true });

            gamefieldDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            gamefieldDataGrid.ColumnCount = ColumnsCount;
            gamefieldDataGrid.Rows.Add(RowsCount);

            foreach (DataGridViewRow row in gamefieldDataGrid.Rows)
            {
                row.Height = cellSize;
            }

            foreach (DataGridViewColumn column in gamefieldDataGrid.Columns)
            {
                column.Width = cellSize;
            }
        }
        
        private void MainForm_Shown(object sender, EventArgs e)
        {
            gamefieldDataGrid.ClearSelection();
        }

        public void DrawFood(Point food)
        {
            gamefieldDataGrid[food.X, food.Y].Style.BackColor = Color.Gold;
           
        }

        public void EraseFood(Point food)
        {
            gamefieldDataGrid[food.X, food.Y].Style.BackColor = Color.White;
        }

        public void DrawSnakePart(Point snakePart)
        {
            gamefieldDataGrid[snakePart.X, snakePart.Y].Selected = true;
        }

        public void EraseSnakePart(Point snakePart)
        {
            gamefieldDataGrid[snakePart.X, snakePart.Y].Selected = false;
        }

        public void StartTimer()
        {
            timer.Start();
        }

        public void SetTimerInterval(int interval)
        {
            timer.Interval = interval;
        }
    }
}

