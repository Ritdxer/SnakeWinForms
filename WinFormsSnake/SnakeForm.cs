using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsSnake
{
    public partial class SnakeForm : Form
    {
        private Timer timer = new Timer();
        private Snake snake = new Snake();
        private Point food;
        private Random rnd = new Random();

        private const int columnsCount = 23;
        private const int rowsCount = 22;
        private const int initialGameSpeed = 150;

        public SnakeForm()
        {
            InitializeComponent();
            InitializeGrid();

            timer.Tick += Timer_Tick;
            snake.Body.CollectionChanged += Body_CollectionChanged;

            StartGame();
        }

        private void StartGame()
        {
            snake.Create();
            GenerateFood();
            timer.Interval = initialGameSpeed;
            timer.Start();
        }

        private void StopGame()
        {
            timer.Stop();
        }

        private void SnakeFieldGrid_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            snake.ChangeDirection((Directions)e.KeyCode);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (food == snake.HeadPosition)
            {
                gamefieldDataGrid[food.X, food.Y].Style.BackColor = Color.White;
                snake.Grow();
                GenerateFood();
                snakeLengthLabel.Text = $"Snake length: {snake.Length}";
            }
            else
            {
                snake.Move();
            }
        }

        private void Body_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                gamefieldDataGrid[((Point)e.NewItems[0]).X, ((Point)e.NewItems[0]).Y]
                  .Selected = true;
            }   

            if (e.OldItems != null)
            {
                gamefieldDataGrid[((Point)e.OldItems[0]).X, ((Point)e.OldItems[0]).Y]
                  .Selected = false;
            }
        }

        private void InitializeGrid()
        {
            int cellSize = 17;

            // enable double buffering to improve food rendering time.
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, gamefieldDataGrid, new object[] { true });

            gamefieldDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            gamefieldDataGrid.KeyDown += SnakeFieldGrid_KeyDown;
            gamefieldDataGrid.ColumnCount = columnsCount;
            gamefieldDataGrid.Rows.Add(rowsCount);

            foreach (DataGridViewRow row in gamefieldDataGrid.Rows)
            {
                row.Height = cellSize;
            }

            foreach (DataGridViewColumn column in gamefieldDataGrid.Columns)
            {
                column.Width = cellSize;
            }
        }

        private void GenerateFood()
        {
            food = new Point(rnd.Next(0, columnsCount), rnd.Next(0, columnsCount));
            gamefieldDataGrid[food.X, food.Y].Style.BackColor = Color.Gold;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            gamefieldDataGrid.ClearSelection();
        }
    }
}

