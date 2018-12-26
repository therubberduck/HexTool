using HexTool.Model.HexMap;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Drawing;

namespace HexTool.ResourceHandling
{
    public class Factory
    {
        private ResourceRepository _resRepo;

        private static Factory _instance;
        public static Factory Instance()
        {
            return _instance;
        }

        public static void Init()
        {
            _instance = new Factory();
        }

        private Factory()
        {
            _resRepo = new ResourceRepository();
            _resRepo.Init();
        }

        public Bitmap Create(HexContent item)
        {
            SKBitmap skiaBitmap = _resRepo.GetImage(item.BackgroundImageId);

            SKCanvas canvas = new SKCanvas(skiaBitmap);
            var terrain = _resRepo.GetImage(item.TerrainImageId);
            if (terrain != null)
            {
                canvas.DrawBitmap(terrain, 0, 0);
            }
            var vegetation = _resRepo.GetImage(item.VegetationImageId);
            if (vegetation != null)
            {
                canvas.DrawBitmap(vegetation, 0, 0);
            }
            var feature = _resRepo.GetImage(item.FeatureImageId);
            if (feature != null)
            {
                canvas.DrawBitmap(feature, 0, 0);
            }

            return skiaBitmap.ToBitmap();
        }
    }
}
