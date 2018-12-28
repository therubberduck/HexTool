using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;

// ReSharper disable once CheckNamespace
namespace HexTool.VVM
{
    public class MapWindowVm : BaseViewModel<MapRepo>
    {
        public static readonly DependencyProperty BrushesProperty = DependencyProperty.Register("Brushes", typeof(List<MapBrush>), typeof(MapWindowVm));
        List<MapBrush> Brushes
        {
            get => (List<MapBrush>)GetValue(BrushesProperty);
            set => SetValue(BrushesProperty, value);
        }

        private MapBrush _activeBrush;

        public static readonly DependencyProperty HexesProperty = DependencyProperty.Register("Hexes", typeof(List<HexContentVm>), typeof(MapWindowVm));
        List<HexContentVm> Hexes {
            get => (List<HexContentVm>)GetValue(HexesProperty);
            set => SetValue(HexesProperty, value);
        }

        public MapWindowVm(MapRepo repo) : base(repo)
        {
            //Setup test data
            //_repo.ClearMap();
            //_repo.CreateTestData();
            var hexes = _repo.GetMapContent();            
            Hexes = ConvertHexesToVm(hexes);
            hexes.Clear();//Cleanup

            Brushes = _repo.GetBrushes();

            //Create window
            Window = new MapWindow(this);
        }

        private List<HexContentVm> ConvertHexesToVm(List<HexContent> hexes)
        {
            var vmItems = new List<HexContentVm>();
            foreach (var hex in hexes)
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
