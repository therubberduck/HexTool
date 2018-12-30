using HexTool.Model.HexMap;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// ReSharper disable once CheckNamespace
namespace HexTool.VVM
{
    public partial class MapWindow : Window
    {
        public static RoutedCommand RedoCommand = new RoutedCommand();
        public static RoutedCommand UndoCommand = new RoutedCommand();

        private readonly MapWindowVm _vm;

        public MapWindow(MapWindowVm vm)
        {
            InitializeComponent();

            _vm = vm;
            DataContext = _vm;

            //Shortcut keys
            RedoCommand.InputGestures.Add(new KeyGesture(Key.Y, ModifierKeys.Control));
            UndoCommand.InputGestures.Add(new KeyGesture(Key.Z, ModifierKeys.Control));

            //Commands
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

        private void BrushButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.SetBrush((sender as Button)?.DataContext as MapBrush);
        }
        
        public void Redo(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.Redo();
        }

        public void Undo(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.Undo();
        }
    }
}
