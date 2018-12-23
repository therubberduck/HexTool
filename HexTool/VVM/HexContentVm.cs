using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HexTool.VVM
{
    public class HexContentVm : DependencyObject
    {
        public int X { get { return _content.X; } }
        public int Y { get { return _content.Y; } }

        public static readonly DependencyProperty BitmapImageProperty = DependencyProperty.Register("Source", typeof(BitmapImage), typeof(HexContentVm));

        public BitmapImage Source
        {
            get { return (BitmapImage)GetValue(BitmapImageProperty); }
        }

        private HexContent _content;
        public HexContent Content
        {
            get { return _content; }
            set
            {
                _content = value;
                SetValue(BitmapImageProperty, BitmapToImageSource(value.Image));
            }
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
