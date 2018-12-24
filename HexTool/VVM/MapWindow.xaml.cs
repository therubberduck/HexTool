using HexTool.Model.HexMap;
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

            var db = (Application.Current as App).Db;

            db.HexContent.ClearTable();

            IEnumerable<HexContent> items = Repository.GetGridItems();
            foreach(HexContent hex in items)
            {
                db.HexContent.Create(hex);
            }

            var dbItems = db.HexContent.GetAll();

            MapWindowVM vm = new MapWindowVM();
            vm.SetContent(dbItems);

            hxMap.DataContext = vm;

            hxMap.SelectionChanged += HxMap_SelectionChanged;


        }

        private void HxMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
