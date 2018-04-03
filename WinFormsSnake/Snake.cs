using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace WinFormsSnake
{
    public class Snake
    {
        public int Length => Body.Count;
        public Point HeadPosition => Body[Body.Count - 1]; 
        public Directions Direction { get; set; } = Directions.Right;
        public ObservableCollection<Point> Body { get; set; } = new ObservableCollection<Point>();

        public void Create(int length = 1)
        {
            for (int i = 1; i <= length; i++)
            {
                Body.Add(new Point(i, 1));
            }
        }

        public void Move()
        {
            Grow();
            Body.RemoveAt(0);
        }

        public void Grow()
        {
            Point head = HeadPosition;

            switch (Direction)
            {
                case Directions.Left:  head.X--; break;
                case Directions.Up:    head.Y--; break;
                case Directions.Right: head.X++; break;
                case Directions.Down:  head.Y++; break;
            }
            Body.Add(head);
        }

        public void ChangeDirection(Directions direction)
        {
            if (Enum.IsDefined(typeof(Directions), direction))
            {
                Direction = direction;
            }
        }

    }
}
