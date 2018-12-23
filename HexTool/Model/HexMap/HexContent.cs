using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HexTool
{
    public class HexContent
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Bitmap Image { get; set; }

        public string Background;
        public string Terrain;
        public string Vegetation;
        public string Feature;
    }
}
