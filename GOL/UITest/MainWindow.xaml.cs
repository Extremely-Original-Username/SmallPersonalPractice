using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using GOL;

namespace UITest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameOfLife game;
        public MainWindow()
        {
            InitializeComponent();
            mainCanvas.Focus();


            GameSettings settings = new GameSettings(125, 60, new string[] { ".", "o", "O", "@" });
            game = new GameOfLife(settings, new UIGameDrawer(this, settings));
            game.randomiseCells(2);

            game.drawGame();
        }

        private void mainCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                beginGame();
            }
        }

        private void mainCanvas_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void mainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        public void beginGame()
        {
            Task.Run(() =>
            {
                bool over = false;

                while (!over)
                {
                    Thread.Sleep(100);
                    this.Dispatcher.Invoke(() =>
                    {
                        game.update();
                    });
                }

            });
        }
    }
}
