using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mode13h.Wpf
{
    class MainViewModel: IGrfx
    {
        private readonly byte[] _screen = new byte[320 * 200];
        private readonly WriteableBitmap _screenBitmap;
        private readonly BitmapPalette _palette = BitmapPalettes.Gray256;
        private static readonly Int32Rect _rect = new Int32Rect(0, 0, 320, 200);

        private readonly AutoResetEvent _verticalRetrace = new AutoResetEvent(false);

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

        public void VRetrace()
        {
            _verticalRetrace.WaitOne();
        }

        public bool Done { get; private set; }

        public void Quit()
        {
            Done = true;
            _verticalRetrace.Set();
        }

        public byte[] Load(string path, out int width, out int height, out int stride)
        {
            var source = new BitmapImage(new Uri("pack://application:,,,/" + path));
            width = source.PixelWidth;
            height = source.PixelHeight;

            stride = 500;
            var bytes = new byte[stride * height];
            source.CopyPixels(bytes, stride, 0);

            
            return bytes;
        }
    }
}
