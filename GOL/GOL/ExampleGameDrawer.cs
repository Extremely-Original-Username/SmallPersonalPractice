using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    internal class ExampleGameDrawer: IGameDrawer
    {
        public void draw(FixedGrid<int> grid, GameSettings gameSettings)
        {
            Console.SetCursorPosition(0, 0);

            string drawing = "";

            for (int y = 0; y < grid.height; y++)
            {
                for (int x = 0; x < grid.width; x++)
                {
                    drawing += gameSettings.stringScale[grid.getGridSquare(x, y)];
                }
                drawing += Environment.NewLine;
            }
            Console.WriteLine(drawing);
        }

    }
}
