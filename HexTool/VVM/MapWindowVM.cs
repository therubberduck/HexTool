using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;

namespace HexTool.VVM
{
    public class MapWindowVM : DependencyObject
    {

        public static readonly DependencyProperty HexesProperty = DependencyProperty.Register("Hexes", typeof(List<HexContentVm>), typeof(MapWindowVM));

        List<HexContentVm> Hexes {
            get { return (List<HexContentVm>)GetValue(HexesProperty); }
            set { SetValue(HexesProperty, value); }
        }

        public void SetContent(IEnumerable<HexContent> hexes)
        {
            var list = new List<HexContentVm>();
            foreach(HexContent hex in hexes)
            {
                list.Add(new HexContentVm { Content = hex });
            }
            Hexes = list;
        }
    }
}
