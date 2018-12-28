using System.Drawing;
using HexTool.ResourceHandling;

namespace HexTool.Model.HexMap
{
    public class HexContent
    {
        public long Id { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int BackgroundImageId;
        public int TerrainImageId;
        public int VegetationImageId;
        public int FeatureImageId;

        public Bitmap MapImage => Factory.Instance().Create(this);

        internal void Paint(MapBrush activeBrush)
        {
            if (activeBrush.BackgroundId != -1)
            {
                BackgroundImageId = activeBrush.BackgroundId;
            }
            if (activeBrush.TerrainId != -1)
            {
                TerrainImageId = activeBrush.TerrainId;
            }
            if (activeBrush.VegetationId != -1)
            {
                VegetationImageId = activeBrush.VegetationId;
            }
            if (activeBrush.FeatureId != -1)
            {
                FeatureImageId = activeBrush.FeatureId;
            }
        }
    }
}
