using HexTool.Database;
using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;

namespace HexTool.VVM
{
    public class MapWindowVM : BaseViewModel
    {
        private DbInterface _db;

        public static readonly DependencyProperty HexesProperty = DependencyProperty.Register("Hexes", typeof(List<HexContentVm>), typeof(MapWindowVM));

        List<HexContentVm> Hexes {
            get { return (List<HexContentVm>)GetValue(HexesProperty); }
            set { SetValue(HexesProperty, value); }
        }

        public MapWindowVM(DbInterface db)
        {
            _db = db;

            //Setup data
            _db.HexContent.ClearTable();

            IEnumerable<HexContent> items = Repository.GetGridItems();
            foreach (HexContent hex in items)
            {
                _db.HexContent.Create(hex);
            }

            var dbItems = _db.HexContent.GetAll();

            var list = new List<HexContentVm>();
            foreach (HexContent hex in dbItems)
            {
                list.Add(new HexContentVm { Content = hex });
            }
            Hexes = list;

            //Create window
            Window = new MapWindow(this);
        }
    }
}
