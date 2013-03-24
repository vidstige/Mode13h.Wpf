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

        private readonly int _width;
        private readonly int _height;
        private readonly int _stride;

        public RotoZoomer(IGrfx grfx)
        {
            _grfx = grfx;
            _img = _grfx.Load("Demos/rebtel.png", out _width, out _height, out _stride);
        }

        internal void Run()
        {
            int t = 0;
            while (!_grfx.Done)
            {
                int c = 0;
                for (int y = 0; y < 200; y++)
                {
                    for (int x = 0; x < 320; x++)
                    {
                        int px = Clamp(Math.Cos(_a) * (x-_ox) * _s - Math.Sin(_a) * (y-_oy) * _s, _width);
                        int py = Clamp(Math.Sin(_a) * (x-_ox) * _s + Math.Cos(_a) * (y-_oy) * _s, _height);
                        
                        _grfx.Screen[c++] = _img[px + py * _stride];
                    }
                }
                _grfx.vretrace();

                _a = Math.Cos(t/100.0) * Math.Sin(t/130.0) * 2 * Math.PI;
                _s = Math.Sin(t/20.0) / 2.0 + 1.4;
                //_s = 1;
                _ox = Math.Cos(t/20.0) * 320;
                _oy = Math.Sin(t/20.0) * 200;

                t++;
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
