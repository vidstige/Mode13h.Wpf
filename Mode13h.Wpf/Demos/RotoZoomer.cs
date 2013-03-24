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
        private readonly byte[] _img;
        private double _a = 0;
        private double _s = 1;
        private double _ox = 0;
        private double _oy = 0;

        public RotoZoomer(IGrfx grfx)
        {
            _grfx = grfx;
            _img = new byte[160 * 100];
            Random r = new Random();
            for (int i = 0; i < 160 * 100; i++)
            {
                _img[i] = (byte)r.Next();
            }
        }

        internal void Run()
        {
            while (!_grfx.Done)
            {
                int c = 0;
                for (int y = 0; y < 200; y++)
                {
                    for (int x = 0; x < 320; x++)
                    {
                        int px = Clamp(Math.Cos(_a) * (x-_ox) * _s - Math.Sin(_a) * (y-_oy) * _s, 160);
                        int py = Clamp(Math.Sin(_a) * (x-_ox) * _s + Math.Cos(_a) * (y-_oy) * _s, 100);
                        
                        if (px >= 0 && px < 160 && py >= 0 && py < 100)
                        {
                            _grfx.Screen[c++] = _img[px + py * 160];
                        }
                        else
                        {
                            _grfx.Screen[c++] = 128;
                        }
                    }
                }
                _grfx.vretrace();

                _a += 0.03;
                //_s = Math.Sin(_a) + 1.2;
                _s = 1;
                _ox = Math.Cos(_a) * 160;
                _oy = Math.Sin(_a) * 100;
            }
        }

        private int Clamp(double d, int w)
        {
            int tmp = (int)d;
            while (tmp < 0) tmp += w;
            while (tmp >= w) tmp -= w;
            return (int)tmp;
        }
    }
}
