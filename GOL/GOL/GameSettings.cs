using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    public class GameSettings
    {
        public int width;
        public int height;
        public int frameBuffer;

        public string[] stringScale;

        public GameSettings(int width, int height, string[] stringScale, int frameBuffer = 50)
        {
            this.width = width;
            this.height = height;
            this.frameBuffer = frameBuffer;
            this.stringScale = stringScale;
        }
    }
}
