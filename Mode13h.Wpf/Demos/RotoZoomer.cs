using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode13h.Wpf.Demos
{
    class RotoZoomer
    {
        private readonly IGrfx _grfx;

        public RotoZoomer(IGrfx grfx)
        {
            _grfx = grfx;
        }

        internal void Run()
        {
            int c = 0;
            for (int y = 0; y < 200; y++)
            {
                for (int x = 0; x < 320; x++)
                {
                    _grfx.Screen[c++] = (byte)(x + y);
                }
            }
        }
    }
}
