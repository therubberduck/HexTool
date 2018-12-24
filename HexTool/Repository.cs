using HexTool.IconFactory;
using HexTool.Model.HexMap;
using System;
using System.Collections.Generic;

namespace HexTool
{
    public class Repository
    {        
        public static IEnumerable<HexContent> GetGridItems()
        {
            Factory f = new Factory();
            List<HexContent> items = new List<HexContent>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    HexContent item = new HexContent { X = i, Y = j };
                    int t = r.Next(3);
                    switch (t)
                    {
                        case 0:
                            item.BackgroundImageId = 10006;
                            item.VegetationImageId = 30004;
                            break;
                        case 1:
                            item.BackgroundImageId = 10004;
                            item.TerrainImageId = 20001;
                            item.VegetationImageId = 30003;
                            break;
                        case 2:
                            item.BackgroundImageId = 10001;
                            item.VegetationImageId = 30001;
                            if (item.X % 2 == 0 && item.Y % 2 == 0)
                            {
                                item.FeatureImageId = 40005;
                            }
                            break;
                    }
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
