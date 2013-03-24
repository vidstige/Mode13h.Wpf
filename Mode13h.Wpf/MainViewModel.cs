using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mode13h.Wpf
{
    class MainViewModel: IGrfx
    {
        private byte[] _screen = new byte[320 * 200];
        private readonly WriteableBitmap _screenBitmap;
        private readonly BitmapPalette _palette = BitmapPalettes.Gray256;
        private static Int32Rect _rect = new Int32Rect(0, 0, 320, 200);

        private AutoResetEvent _verticalRetrace = new AutoResetEvent(false);

        public MainViewModel()
        {
            _screenBitmap = new WriteableBitmap(320, 200, 96, 96, PixelFormats.Indexed8, _palette);
        }

        public WriteableBitmap ScreenBitmap { get { return _screenBitmap; } }

        public void Draw()
        {
            _screenBitmap.WritePixels(_rect, _screen, 320, 0);
            _verticalRetrace.Set();
        }

        public byte[] Screen { get { return _screen; } }

        public void vretrace()
        {
            _verticalRetrace.WaitOne();
        }
    }
}
