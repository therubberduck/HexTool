using System.Drawing;
using HexTool.IconFactory;

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

        public string BackgroundImagePath { get { return ImageMapper.GetImageUrl(BackgroundImageId); } }
        public string TerrainImagePath { get { return ImageMapper.GetImageUrl(TerrainImageId); } }
        public string VegetationImagePath { get { return ImageMapper.GetImageUrl(VegetationImageId); } }
        public string FeatureImagePath { get { return ImageMapper.GetImageUrl(FeatureImageId); } }

        public Bitmap MapImage { get { return new Factory().Create(this); } }
    }
}
