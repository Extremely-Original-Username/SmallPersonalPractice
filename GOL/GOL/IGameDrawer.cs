using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    internal interface IGameDrawer
    {
        void draw(FixedGrid<int> grid, GameSettings gameSettings);
    }
}
