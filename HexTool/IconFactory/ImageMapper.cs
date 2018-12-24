using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTool.IconFactory
{
    public class ImageMapper
    {
        public static string GetImageUrl(int imageId)
        {
            switch(imageId)
            {
                case 10001:
                    return "Images/BDesert.png";
                case 10002:
                    return "Images/BFarmland.png";
                case 10003:
                    return "Images/BForest.png";
                case 10004:
                    return "Images/BHills.png";
                case 10005:
                    return "Images/BMountains.png";
                case 10006:
                    return "Images/BPlains.png";
                case 10007:
                    return "Images/BSea.png";
                case 20001:
                    return "Images/THills.png";
                case 20002:
                    return "Images/TMountains.png";
                case 30001:
                    return "Images/VDesert.png";
                case 30002:
                    return "Images/VFarmland.png";
                case 30003:
                    return "Images/VForest.png";
                case 30004:
                    return "Images/VGrassland.png";
                case 40001:
                    return "Images/IcCave.png";
                case 40002:
                    return "Images/IcHamlet.png";
                case 40003:
                    return "Images/IcCity.png";
                case 40004:
                    return "Images/IcTower.png";
                case 40005:
                    return "Images/IcMonument.png";
                default:
                    return null;
            }
        }
    }
}
