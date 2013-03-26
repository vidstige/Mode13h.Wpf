using System;

namespace Mode13h.Wpf.Demos
{
    class Plasma
    {
        private readonly IGrfx _grfx;

        public Plasma(IGrfx grfx)
        {
            _grfx = grfx;
        }

        public void Run()
        {
            double t = 0;
            while (!_grfx.Done)
            {
                int count = 0;
                for (int y = 0; y < 200; y++)
                {
                    for (int x = 0; x < 320; x++)
                    {
                        double dx = (x - 160) / 320.0;
                        double dy = (y - 100) / 200.0;
                        double a = Math.Sin(t+ dx*10);
                        double b = Math.Sin(10* (dx*Math.Cos(t/2) + dy*Math.Sin(t/3)) + t);

                        double cx = dx + 0.5*Math.Sin(t/5);
                        double cy = dy + 0.5*Math.Cos(t/3);
                        double c = Math.Sin(Math.Sqrt(100 * (cx*cx + cy*cy) + 1) + t);
                        
                        _grfx.Screen[count++] = (byte)((a+b+c+3) * 42);
                    }
                }
                _grfx.VRetrace();

                t += 0.1;
            }
        }
    }
}
