using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HexTool
{
    public class GridItem : DependencyObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static readonly DependencyProperty BitmapImageProperty = DependencyProperty.Register("Source", typeof(BitmapImage), typeof(DependencyObject));

        public BitmapImage Source {
            get { return (BitmapImage)GetValue(BitmapImageProperty); }
        }

        public Bitmap Image
        {
            set {
                var bitmapimage = BitmapToImageSource(value);
                SetValue(BitmapImageProperty, bitmapimage);
            }
        }

        public string Background;
        public string Terrain;
        public string Vegetation;
        public string Feature;

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
