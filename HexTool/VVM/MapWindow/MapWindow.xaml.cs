using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HexTool.VVM
{
    public partial class MapWindow : Window
    {
        private MapWindowVM _vm;

        public MapWindow(MapWindowVM vm)
        {
            InitializeComponent();

            _vm = vm;

            hxMap.DataContext = _vm;

            hxMap.SelectionChanged += HxMap_SelectionChanged;
        }

        private void HxMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                _vm.PaintHex(e.AddedItems[0] as HexContentVm);
                hxMap.SelectedIndex = -1;
            }
        }

        private void DesertButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.SetBrush(0);
        }

        private void ForestButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.SetBrush(1);
        }

        private void PlainButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.SetBrush(2);
        }
    }
}
