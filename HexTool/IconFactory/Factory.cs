using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Drawing;
using System.IO;

namespace HexTool.IconFactory
{
    public class Factory
    {
        public Bitmap Create(HexContent item)
        {
            SKBitmap skiaBitmap = LoadBitmap(item.Background);

            SKCanvas canvas = new SKCanvas(skiaBitmap);
            if (item.Terrain != null)
            {
                SKBitmap layer = LoadBitmap(item.Terrain);
                canvas.DrawBitmap(layer, 0, 0);
            }
            if (item.Vegetation != null)
            {
                SKBitmap layer = LoadBitmap(item.Vegetation);
                canvas.DrawBitmap(layer, 0, 0);
            }
            if (item.Feature != null)
            {
                SKBitmap layer = LoadBitmap(item.Feature);
                canvas.DrawBitmap(layer, 0, 0);
            }

            return skiaBitmap.ToBitmap();
        }

        public SKBitmap LoadBitmap(string url)
        {
            SKBitmap bitmap;
            using (Stream stream = File.OpenRead(url))
            {
                bitmap = SKBitmap.Decode(stream);
            }
            return bitmap;
        }
    }
}
