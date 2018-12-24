using HexTool.Model.HexMap;
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
            SKBitmap skiaBitmap = LoadBitmap(item.BackgroundImagePath);

            SKCanvas canvas = new SKCanvas(skiaBitmap);
            if (item.TerrainImagePath != null)
            {
                SKBitmap layer = LoadBitmap(item.TerrainImagePath);
                canvas.DrawBitmap(layer, 0, 0);
            }
            if (item.VegetationImagePath != null)
            {
                SKBitmap layer = LoadBitmap(item.VegetationImagePath);
                canvas.DrawBitmap(layer, 0, 0);
            }
            if (item.FeatureImagePath != null)
            {
                SKBitmap layer = LoadBitmap(item.FeatureImagePath);
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
