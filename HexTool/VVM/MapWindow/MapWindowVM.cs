using HexTool.Database;
using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;

namespace HexTool.VVM
{
    public class MapWindowVM : BaseViewModel<MapRepo>
    {
        public static readonly DependencyProperty HexesProperty = DependencyProperty.Register("Hexes", typeof(List<HexContentVm>), typeof(MapWindowVM));

        List<HexContentVm> Hexes {
            get { return (List<HexContentVm>)GetValue(HexesProperty); }
            set { SetValue(HexesProperty, value); }
        }

        public MapWindowVM(MapRepo repo) : base(repo)
        {
            //Setup test data
            _repo.ClearMap();
            _repo.CreateTestData();
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
    }
}
