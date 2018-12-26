using HexTool.Model.HexMap;
using Newtonsoft.Json;
using SkiaSharp;
using System.Collections.Generic;
using System.IO;

namespace HexTool.ResourceHandling
{
    enum ResourceImageType { Background = 10, Terrain = 20, Vegetation = 30, Feature = 40}

    public class ResourceRepository
    {
        private List<MapBrush> _brushes = new List<MapBrush>();
        private Dictionary<int, SKBitmap> _imageBitmaps = new Dictionary<int, SKBitmap>();

        public void Init()
        {
            var jsonText = File.ReadAllText("Resources/res.txt");
            var jsonDo = JsonConvert.DeserializeObject<JsonDO>(jsonText);
            
            foreach(int imageId in jsonDo.Images.Keys)
            {
                var path = jsonDo.Images[imageId];
                var bitmap = LoadBitmap("Resources/"+path);
                _imageBitmaps.Add(imageId, bitmap);
            }

            foreach(string name in jsonDo.Brushes.Keys)
            {
                int[] imageIds = jsonDo.Brushes[name];

                int background = -1;
                int terrain = -1;
                int vegetation = -1;
                int feature = -1;
                foreach(int imageId in imageIds)
                {
                    var imageType = (ResourceImageType)(imageId / 1000); //Get the first two numbers of our 5-digit number
                    switch (imageType)
                    {
                        case ResourceImageType.Background:
                            background = imageId;
                            break;
                        case ResourceImageType.Terrain:
                            terrain = imageId;
                            break;
                        case ResourceImageType.Vegetation:
                            vegetation = imageId;
                            break;
                        case ResourceImageType.Feature:
                            feature = imageId;
                            break;
                        default:
                            throw new InvalidDataException("No ImageType exists matching the given id");
                    }                                     
                }

                var brush = new MapBrush(name, background, terrain, vegetation, feature);
            }
        }

        public SKBitmap GetImage(int imageId)
        {
            if (IsImageIdForNull(imageId))
            {
                return null;
            }
            return _imageBitmaps[imageId];
        }

        private SKBitmap LoadBitmap(string url)
        {
            SKBitmap bitmap;
            using (Stream stream = File.OpenRead(url))
            {
                bitmap = SKBitmap.Decode(stream);
            }
            return bitmap;
        }
        
        private bool IsImageIdForNull(int imageId)
        {
            //Check if the final 3 numbers of our 5-digit number is 000 (replace existing texture with nothing)
            //Or if the entire number is -1 (do nothing to existing texture)
            return imageId %1000 == 0 || imageId % 1000 == -1; 
        }
    }
}
