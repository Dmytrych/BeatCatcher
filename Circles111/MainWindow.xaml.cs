using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Circles111
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Привязка кружка к мыши
        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas.SetTop(CursorFollower, e.GetPosition(MainCanv).Y - CursorFollower.Height / 2);
            Canvas.SetLeft(CursorFollower, e.GetPosition(MainCanv).X - CursorFollower.Width / 2);
        }
        //Cпавн тестового блока
        private void SpawnBlock(object sender, RoutedEventArgs e)
        {
            Block bl = new Block(MainCanv, 10, 10);
            (sender as UIElement).Visibility = Visibility.Hidden;
        }
    }

    //Квадраты, кторые вылетают
    class Block
    {
        private Rectangle block;
        public Block(Canvas Canv, double PosX, double PosY)
        {
            block = new Rectangle();
            block.Width = 20;
            block.Height = 20;
            block.Fill = Brushes.Blue;
            Canvas.SetLeft(block, PosX);
            Canvas.SetTop(block, PosY);
            Canv.Children.Add(block);
            block.MouseMove += KillBlock;
        }
        //Удаление блока
        public void KillBlock(object sender, MouseEventArgs e)
        {
            block.Visibility = Visibility.Hidden;
        }
    }
}
