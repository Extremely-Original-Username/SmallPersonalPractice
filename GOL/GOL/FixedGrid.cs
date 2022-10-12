using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    public class FixedGrid<TGridObject>
    {
        public TGridObject[,] gridArray;
        public int width { get; }
        public int height { get; }

        public FixedGrid(int width, int height, TGridObject defaultValue = default(TGridObject))
        {
            this.width = width;
            this.height = height;

            gridArray = new TGridObject[width, height];

            doToAllSquares((x, y) => setGridSquare(x, y, defaultValue));
        }

        public void setGridSquare(int x, int y, TGridObject value)
        {
            gridArray[x, y] = value;
        }

        public TGridObject getGridSquare(int x, int y)
        {
            return gridArray[x, y];
        }

        public List<TGridObject> getNeighbors(int xpos, int ypos)
        {
            List<TGridObject> neighbors = new List<TGridObject>();
            for (int y = ypos - 1; y < ypos + 2; y++)
            {
                for (int x = xpos - 1; x < xpos + 2; x++)
                {
                    if (x >= 0 && y >= 0 && x <= width - 1 && y <= height - 1 && (x != xpos || y != ypos))
                    {
                        neighbors.Add(getGridSquare(x, y));
                    }
                }
            }
            return neighbors;
        }

        public void doToAllSquares(Action<int, int> action)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    action(x, y);
                }
            }
        }
        public void doToAllSquares(Action action)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    action();
                }
            }
        }

        public override string ToString()
        {
            string gridSTR = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    gridSTR += " " + getGridSquare(x, y).ToString();
                }
                gridSTR += Environment.NewLine;
            }
            return gridSTR;
        }

        public FixedGrid<TGridObject> copy()
        {
            FixedGrid<TGridObject> newGrid = new FixedGrid<TGridObject>(width, height);

            doToAllSquares((x, y) => newGrid.setGridSquare(x, y, getGridSquare(x, y)));

            return newGrid;
        }
    }
}
