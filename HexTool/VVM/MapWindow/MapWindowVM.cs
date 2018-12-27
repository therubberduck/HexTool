using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;
using HexTool.ResourceHandling;
using System;

namespace HexTool.VVM
{
    public class MapWindowVM : BaseViewModel<MapRepo>
    {
        public static readonly DependencyProperty BrushesProperty = DependencyProperty.Register("Brushes", typeof(List<MapBrush>), typeof(MapWindowVM));
        List<MapBrush> Brushes
        {
            get { return (List<MapBrush>)GetValue(BrushesProperty); }
            set { SetValue(BrushesProperty, value); }
        }

        private MapBrush _activeBrush;

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
            hexes = null;

            Brushes = _repo.GetBrushes();

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

            hex.Paint(_activeBrush);

            hexContentVm.UpdateImage();
            _repo.UpdateHex(hex);
        }

        public void SetBrush(MapBrush brush)
        {
            _activeBrush = brush;
        }
    }
}
