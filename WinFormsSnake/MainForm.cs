using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsSnake
{
    public partial class MainForm : Form
    {
        private Timer timer = new Timer();
        private Snake snake = new Snake();
        private Point food;
        private Random rnd = new Random();

        private int fieldWidth = 23;
        private int fieldHeight = 22;
        private int cellSize = 17;
        private int gameSpeed = 100;
        private int snakeLength = 3;
        private Point initialPosition = new Point(5, 9);

        public MainForm()
        {
            InitializeComponent();
            InitializeGrid();
            
            snake.Body.CollectionChanged += Body_CollectionChanged;
            snake.CreateSnake(snakeLength, initialPosition);
            
            timer.Tick += Timer_Tick;
            timer.Interval = gameSpeed;
            timer.Start();
        }
        
        private void SnakeFieldGrid_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            snake.ChangeDirection((Directions)e.KeyCode);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // if head == food, then grow, else move
            if (food == snake.HeadPosition)
            {
                snake.Grow();
                SnakeFieldGrid[food.X, food.Y].Style.BackColor = Color.White;
                GenerateFood();
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
                SnakeFieldGrid[((Point)e.NewItems[0]).X, ((Point)e.NewItems[0]).Y]
                  .Selected = true;
            }

            if (e.OldItems != null)
            {
                SnakeFieldGrid[((Point)e.OldItems[0]).X, ((Point)e.OldItems[0]).Y]
                  .Selected = false;
            }
        }

        private void InitializeGrid()
        {
            // enable double buffering to improve food rendering time.
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, SnakeFieldGrid, new object[] { true });
            
            SnakeFieldGrid.ColumnCount = fieldWidth;
            SnakeFieldGrid.Rows.Add(fieldHeight);

            foreach (DataGridViewColumn column in SnakeFieldGrid.Columns)
            {
                column.Width = cellSize;
            }

            foreach (DataGridViewRow row in SnakeFieldGrid.Rows)
            {
                row.Height = cellSize;
            }
            
            SnakeFieldGrid.KeyDown += SnakeFieldGrid_KeyDown;
            GenerateFood();
        }
        
        private void GenerateFood()
        {
            food = new Point(rnd.Next(0, fieldWidth), 
                             rnd.Next(0, fieldWidth));

            SnakeFieldGrid[food.X, food.Y]
                .Style.BackColor = Color.Gold;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SnakeFieldGrid.ClearSelection();
        }
    }
}

