using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode13h.Wpf
{
    interface IGrfx
    {
        byte[] Screen { get; }
        void vretrace();

        bool Done { get; }
    }
}
