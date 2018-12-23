using HexTool.IconFactory;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HexTool.VVM
{
    public partial class MapWindow : Window
    {
        public MapWindow()
        {
            InitializeComponent();

            IEnumerable<HexContent> items = Repository.GetGridItems();

            MapWindowVM vm = new MapWindowVM();
            vm.SetContent(items);

            hxMap.DataContext = vm;

            hxMap.SelectionChanged += HxMap_SelectionChanged;
        }

        private void HxMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
