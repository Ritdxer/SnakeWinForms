using System;
using System.Collections.Specialized;
using System.Drawing; // TO DO: Remove dependency on drawing

namespace WinFormsSnake
{
    public class SnakePresenter
    {
        private ISnakeView view;
        private Point food;
        private Snake snake = new Snake();
        private Random rnd = new Random();

        public SnakePresenter(ISnakeView view)
        {
            this.view = view;
            snake.Body.CollectionChanged += Body_CollectionChanged;
        }

        private void Body_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                view.DrawSnakePart((Point)e.NewItems[0]);
            }

            if (e.OldItems != null)
            {
                view.EraseSnakePart((Point)e.OldItems[0]);
            }
        }

        public void OnKeyDown(Directions direction)
        {
            snake.ChangeDirection(direction);
        }

        public void OnTimerTick()
        {
            if (food == snake.HeadPosition)
            {
                view.EraseFood(food);
                snake.Grow();
                GenerateFood();
                view.SnakeLengthText = $"Snake length: {snake.Length}";
            }
            else
            {
                snake.Move();
            }
        }

        public void StartGame()
        {
            snake.Create();
            GenerateFood();
            view.SetTimerInterval(100);
            view.StartTimer();
        }

        private void GenerateFood()
        {
            food = new Point(rnd.Next(0, view.ColumnsCount), 
                             rnd.Next(0, view.RowsCount));
            view.DrawFood(food);
        }
    }
}
