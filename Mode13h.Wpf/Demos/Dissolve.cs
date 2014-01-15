using System;
using System.Linq;
using System.Collections.Generic;

namespace Mode13h.Wpf.Demos
{
    class Dissolve
    {        
        private readonly IGrfx _grfx;
        public Dissolve(IGrfx grfx)
        {
            _grfx = grfx;
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private static IEnumerable<int> PrimeFactors(int a)
        {
            for (int b = 2; a > 1; b++)
                if (a % b == 0)
                {
                    int x = 0;
                    while (a % b == 0)
                    {
                        a /= b;
                        x++;
                    } 
                    yield return b;
                }
        }

        private void Assert(bool b)
        {
            if (!b) throw new ArgumentException("foobar");
        }

        public void Run()
        {
            const int foobar = 1612342;
            const int a = 3*5 * 4 * foobar + 1;  // 121
            const int c = 777221;
            const int m = 76800; // 2,3,5
            const int seed = 1;
            long x = seed;

            Assert(GCD(c, m) == 1);
            Assert(PrimeFactors(m).All(f => (a-1) % f == 0));
            Assert(m % 4 != 0 || (a - 1) % 4 == 0);

            byte clr = 255;
            int cnt = 0;
            while (!_grfx.Done)
            {
                for (int i = 0; i < 640*4; i++)
                {
                    _grfx.Screen[x] = clr;

                    x = (a * x + c) % m;
                    cnt++;

                    if (x == seed)
                    {
                        clr = (byte)(255 - clr);
                        x = 123;
                    }
                }
                _grfx.VRetrace();                
            }
        }
    }
}
