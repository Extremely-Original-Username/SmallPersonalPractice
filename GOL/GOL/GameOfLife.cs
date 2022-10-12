using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    internal class GameOfLife
    {
        FixedGrid<int> grid;
        GameSettings settings;
        IGameDrawer drawer;

        public GameOfLife(GameSettings settings, IGameDrawer drawer)
        {
            this.settings = settings;
            this.drawer = drawer;
            grid = new FixedGrid<int>(settings.width, settings.height, 0);

            randomiseCells(3);
        }

        public void randomiseCells(int cellRarity)
        {
            Random random = new Random();

            List<int> options = new List<int>() { settings.stringScale.Length - 1 };
            for (int i = 0; i < cellRarity; i++)
            {
                options.Add(0);
            }

            grid.doToAllSquares((x, y) => 
                grid.setGridSquare(x, y, options[random.Next() % cellRarity])
            );
        }

        public void update()
        {
            FixedGrid<int> oldGrid = grid.copy();
            grid.doToAllSquares((x, y) => grid.setGridSquare(x, y, Math.Max(grid.getGridSquare(x, y) - 1, 0)));

            for (int y = 0; y < grid.height; y++)
            {
                for (int x = 0; x < grid.width; x++)
                {
                    var neighbors = oldGrid.getNeighbors(x, y);
                    int livingNeighbors = 0;
                    foreach(var neighbor in neighbors)
                    {
                        if (neighbor == settings.stringScale.Length - 1)
                        {
                            livingNeighbors += 1;
                        }
                    }

                    if (oldGrid.getGridSquare(x, y) == settings.stringScale.Length - 1 && (livingNeighbors == 2 || livingNeighbors == 3))
                    {
                        grid.setGridSquare(x, y, settings.stringScale.Length - 1);
                    }
                    else if (!(oldGrid.getGridSquare(x, y) == settings.stringScale.Length - 1) && livingNeighbors == 3)
                    {
                        grid.setGridSquare(x, y, settings.stringScale.Length - 1);
                    }
                }
            }

            drawGame();
        }

        public void drawGame()
        {
            drawer.draw(grid, settings);
        }

        public void run()
        {
            while (true)
            {
                Thread.Sleep(settings.frameBuffer);
                update();
            }
        }
    }
}
