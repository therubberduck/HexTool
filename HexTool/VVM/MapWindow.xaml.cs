using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HexTool.VVM
{
    public partial class MapWindow : Window
    {
        public MapWindow(MapWindowVM vm)
        {
            InitializeComponent();

            hxMap.DataContext = vm;

            hxMap.SelectionChanged += HxMap_SelectionChanged;
        }

        private void HxMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
