using GOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UITest
{
    internal class UIGameDrawer : IGameDrawer
    {
        MainWindow mainWindow;
        Rectangle[,] rectangles;

        public UIGameDrawer(MainWindow window, GameSettings settings)
        {
            mainWindow = window;
            rectangles = new Rectangle[settings.width, settings.height];

            for (int y = 0; y < settings.height; y++)
            {
                for (int x = 0; x < settings.width; x++)
                {
                    Rectangle rectangle = new Rectangle();
                    
                    rectangle.Fill = Brushes.Gray;
                    mainWindow.mainCanvas.Children.Add(rectangle);
                    rectangles[x, y] = rectangle;

                    placeRectangle(rectangle, x, y, 0, 10);
                }
            }
        }

        public void draw(FixedGrid<int> grid, GameSettings settings)
        {
            for (int y = 0; y < settings.height; y++)
            {
                for (int x = 0; x < settings.width; x++)
                {
                    placeRectangle(rectangles[x, y], x, y, grid.getGridSquare(x, y) * 2, 10);
                }
            }
        }

        private void placeRectangle(Rectangle rectangle,int x, int y, int width, int spacedBy)
        {
            rectangle.Width = width;
            rectangle.Height = width;
            Canvas.SetLeft(rectangle, spacedBy * x + ((spacedBy - width)/2));
            Canvas.SetTop(rectangle, spacedBy * y + ((spacedBy - width)/2));
        }
    }
}
