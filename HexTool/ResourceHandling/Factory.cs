using HexTool.Model.HexMap;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Drawing;

namespace HexTool.ResourceHandling
{
    public class Factory
    {
        private readonly ResourceRepository _resRepo;

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
            _resRepo = ResourceRepository.Instance();
        }

        public Bitmap Create(HexContent item)
        {
            SKBitmap background = _resRepo.GetImage(item.BackgroundImageId);
            SKBitmap finishedHex = new SKBitmap(background.Width, background.Height);

            SKCanvas canvas = new SKCanvas(finishedHex);

            canvas.DrawBitmap(background, 0, 0);

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

            return finishedHex.ToBitmap();
        }
    }
}
