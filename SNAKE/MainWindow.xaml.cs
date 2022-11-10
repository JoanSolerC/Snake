using Snake2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SNAKE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SnakeGame jocSerp;
        
        public MainWindow()
        {
            InitializeComponent();
            jocSerp = new SnakeGame();
            jocSerp.ColocarPomes();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int tamanyXCasella = (int)(canvas.ActualWidth / SnakeGame.X_SIZE);
            int tamanyYCasella = (int)(canvas.ActualHeight / SnakeGame.Y_SIZE);
            canvas.Children.Clear();
            foreach(var poma in jocSerp.posicioPomes)
            {
                Ellipse dibuixPoma = new Ellipse();
                dibuixPoma.Fill = Brushes.Red;
                dibuixPoma.Width = tamanyXCasella;
                dibuixPoma.Height = tamanyYCasella;
                Canvas.SetLeft(dibuixPoma, poma.X * tamanyXCasella);
                Canvas.SetTop(dibuixPoma, poma.Y * tamanyYCasella);
                canvas.Children.Add(dibuixPoma);
            }
            
            Ellipse ellSerp = new Ellipse()
            {
                Fill = Brushes.Black,
                Width = tamanyXCasella,
                Height = tamanyYCasella
            };
            canvas.Children.Add(ellSerp);
            Canvas.SetTop(ellSerp, jocSerp.CapSerp.Y * tamanyYCasella);
            Canvas.SetLeft(ellSerp, jocSerp.CapSerp.X / tamanyXCasella);

            jocSerp.MirarSiPerd();
        }
        private void canvas_KeyDown_1(object sender, KeyEventArgs e)
        {
            jocSerp.moure();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            jocSerp.JocNou();
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            jocSerp.moure();
        }
    }
}
