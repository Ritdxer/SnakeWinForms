using System;
using System.Drawing;

namespace WinFormsSnake
{
    public interface ISnakeView
    {
        int ColumnsCount { get; }
        int RowsCount { get; }
        string SnakeLengthText { get; set; }
        void DrawFood(Point food);
        void EraseFood(Point food);
        void DrawSnakePart(Point snakePart);
        void EraseSnakePart(Point snakePart);
        void StartTimer();
        void SetTimerInterval(int interval);
    }
}