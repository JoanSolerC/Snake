using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Snake2
{
    public enum DireccioSnake
    {
        Dreta,
        Esquerre,
        Avall,
        Amunt
    }
    class SnakeGame
    {
        public const int NPOMES = 5;
        public const int X_SIZE = 10;
        public const int Y_SIZE = 10;

        public List<Point> posicioPomes = new List<Point>();
        Random rand = new Random(); 
        Point capSerp = new Point(0, 0);

        DireccioSnake direccio = DireccioSnake.Avall;

        public DireccioSnake Direccio { get => direccio; set => direccio = value; }
        public Point CapSerp { get => capSerp; set => capSerp = value; }
        List<Point> snake = new List<Point>();

        internal void moure()
        {
            if (direccio == DireccioSnake.Dreta)
            {
                capSerp = snake[0];
                Point nouCap = new Point(capSerp.X + X_SIZE, capSerp.Y);
                snake.Insert(0, nouCap);
                snake.RemoveAt(snake.Count - 1);
            }
            if (direccio == DireccioSnake.Esquerre)
            {
                Point capSerp = snake[0];
                Point nouCap = new Point(capSerp.X - X_SIZE, capSerp.Y);
                snake.Insert(0, nouCap);
                snake.RemoveAt(snake.Count - 1);
            }
            if (direccio == DireccioSnake.Amunt)
            {
                Point capSerp = snake[0];
                Point nouCap = new Point(capSerp.X, capSerp.Y - Y_SIZE);
                snake.Insert(0, nouCap);
                snake.RemoveAt(snake.Count - 1);
            }
            if (direccio == DireccioSnake.Avall)
            {
                Point capSerp = snake[0];
                Point nouCap = new Point(capSerp.X, capSerp.Y + Y_SIZE);
                snake.Insert(0, nouCap);
                snake.RemoveAt(snake.Count - 1);
            }
        }
        public void ColocarPomes()
        {
            posicioPomes.Clear();
            for (int i = 0; i < NPOMES; i++)
            {
                posicioPomes.Add(new Point(rand.Next(0, X_SIZE), rand.Next(0, Y_SIZE)));
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Up))
                direccio = DireccioSnake.Amunt;
            if (Keyboard.IsKeyDown(Key.Down))
                direccio = DireccioSnake.Avall;
            if (Keyboard.IsKeyDown(Key.Left))
                direccio = DireccioSnake.Esquerre;
            if (Keyboard.IsKeyDown(Key.Right))
                direccio = DireccioSnake.Dreta;
        }
        public void MirarSiPerd()
        {

            if (capSerp.Y > Y_SIZE || capSerp.Y < 0 || capSerp.X < 0 || capSerp.X > X_SIZE)
            {
                MessageBox.Show("Has perdut");
            }
        }
        public void JocNou()
        {
            direccio = DireccioSnake.Dreta;

            snake = new List<Point>();
            snake.Add(new Point(X_SIZE * 10, Y_SIZE));
            snake.Add(new Point(X_SIZE * 10, Y_SIZE * 2));
            snake.Add(new Point(X_SIZE * 10, Y_SIZE * 3));
            snake.Add(new Point(X_SIZE * 10, Y_SIZE * 4));
        }
    }
}
