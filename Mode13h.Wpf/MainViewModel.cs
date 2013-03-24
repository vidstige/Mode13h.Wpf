using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mode13h.Wpf
{
    class MainViewModel
    {
        private byte[] _screen = new byte[320 * 200];
        private readonly WriteableBitmap _screenBitmap;
        private readonly BitmapPalette _palette = BitmapPalettes.Gray256;
        private static Int32Rect _rect = new Int32Rect(0, 0, 320, 200);

        public MainViewModel()
        {
            _screenBitmap = new WriteableBitmap(320, 200, 96, 96, PixelFormats.Indexed8, _palette);
        }

        public WriteableBitmap Screen { get { return _screenBitmap; } }

        public void Draw()
        {
            int c=0;
            for (int y = 0; y < 200; y++)
            {
                for (int x = 0; x < 200; x++)
                {
                    _screen[c++] = (byte)c;
                }
            }

            _screenBitmap.WritePixels(_rect, _screen, 320, 0);
        }
    }
}
