using HexTool.IconFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTool
{
    public class Repository
    {        
        public static IEnumerable<HexContent> GetGridItems()
        {
            Factory f = new Factory();
            List<HexContent> items = new List<HexContent>();
            Random r = new Random();
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    HexContent item = new HexContent { X = i, Y = j };
                    int t = r.Next(3);
                    switch (t)
                    {
                        case 0:
                            item.Background = "Images/BPlains.png";
                            item.Vegetation = "Images/VGrassland.png";
                            break;
                        case 1:
                            item.Background = "Images/BForestHills.png";
                            item.Terrain = "Images/THills.png";
                            item.Vegetation = "Images/VForest.png";
                            break;
                        case 2:
                            item.Background = "Images/BDesert.png";
                            if (item.X % 2 == 0 && item.Y % 2 == 0)
                            {
                                item.Feature = "Images/IcMonument.png";
                            }
                            break;
                    }
                    item.Image = f.Create(item);
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
