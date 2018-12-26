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

        public Bitmap MapImage { get { return Factory.Instance().Create(this); } }
    }
}
