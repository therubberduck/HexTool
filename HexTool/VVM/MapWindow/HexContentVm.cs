using HexTool.Model.HexMap;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

// ReSharper disable once CheckNamespace
namespace HexTool.VVM
{
    public class HexContentVm : DependencyObject
    {
        public int X => _content.X;
        public int Y => _content.Y;

        public static readonly DependencyProperty BitmapImageProperty = DependencyProperty.Register("Source", typeof(BitmapImage), typeof(HexContentVm));

        public BitmapImage Source => (BitmapImage)GetValue(BitmapImageProperty);

        private HexContent _content;
        public HexContent Content
        {
            get => _content;
            set
            {
                _content = value;
                UpdateImage();
            }
        }

        public void UpdateImage()
        {
            SetValue(BitmapImageProperty, BitmapToImageSource(_content.MapImage));
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        public MapBrush CreateBrush()
        {
            return new MapBrush("Brush" + X + "," + Y, 
                _content.BackgroundImageId, _content.TerrainImageId,
                _content.VegetationImageId, _content.FeatureImageId);
        }
    }
}
