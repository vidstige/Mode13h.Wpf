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
        
        byte[] Load(string path, out int width, out int height, out int stride);

        bool Done { get; }
    }
}
