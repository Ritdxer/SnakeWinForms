using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace WinFormsSnake
{
    public class Snake
    {
        public ObservableCollection<Point> Body { get; set; }
        public Directions Direction { get; set; }
        public Point HeadPosition { get { return Body[Body.Count - 1];  } }

        public Snake()
        {
            Body = new ObservableCollection<Point>();
            Direction = Directions.Right;
        }

        public void CreateSnake(int length, Point position)
        {
            for (int i = 0; i < length; i++)
            {
                Body.Add(new Point(position.X + i, position.Y));
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
                case Directions.Left:
                    head.X--; break;
                case Directions.Up:
                    head.Y--; break;
                case Directions.Right:
                    head.X++; break;
                case Directions.Down:
                    head.Y++; break;
            }
            Body.Add(head);
        }

        public void ChangeDirection(Directions newDirection)
        {
            if (Enum.IsDefined(typeof(Directions), newDirection))
            {
                Direction = newDirection;
            }
        }

    }
}
