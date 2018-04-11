using System;
using System.Windows.Forms;

namespace WinFormsSnake
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new SnakeForm();
            var presenter = new SnakePresenter(view);

            Application.Run(view);
        }
    }
}
