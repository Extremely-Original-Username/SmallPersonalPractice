﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    public interface IGameDrawer
    {
        void draw(FixedGrid<int> grid, GameSettings gameSettings);
    }
}
