using HexTool.Database;
using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;
using System;

namespace HexTool.VVM
{
    public class MapWindowVM : BaseViewModel<MapRepo>
    {
        private int _brush;

        public static readonly DependencyProperty HexesProperty = DependencyProperty.Register("Hexes", typeof(List<HexContentVm>), typeof(MapWindowVM));

        List<HexContentVm> Hexes {
            get { return (List<HexContentVm>)GetValue(HexesProperty); }
            set { SetValue(HexesProperty, value); }
        }

        public MapWindowVM(MapRepo repo) : base(repo)
        {
            //Setup test data
            //_repo.ClearMap();
            //_repo.CreateTestData();
            var hexes = _repo.GetMapContent();            
            Hexes = ContertHexesToVm(hexes);

            //Create window
            Window = new MapWindow(this);
        }

        private List<HexContentVm> ContertHexesToVm(List<HexContent> hexes)
        {
            var vmItems = new List<HexContentVm>();
            foreach (HexContent hex in hexes)
            {
                vmItems.Add(new HexContentVm { Content = hex });
            }
            return vmItems;
        }

        internal void PaintHex(HexContentVm hexContentVm)
        {
            var hex = hexContentVm.Content;

            switch(_brush)
            {
                case 0:
                    hex.BackgroundImageId = 10001;
                    hex.VegetationImageId = 30001;
                    break;
                case 1:
                    hex.BackgroundImageId = 10003;
                    hex.VegetationImageId = 30003;
                    break;
                case 2:
                    hex.BackgroundImageId = 10006;
                    hex.VegetationImageId = 30004;
                    break;
            }

            hexContentVm.UpdateImage();
            _repo.UpdateHex(hex);
        }

        public void SetBrush(int brush)
        {
            _brush = brush;
        }
    }
}
