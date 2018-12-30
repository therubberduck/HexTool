using HexTool.Model.HexMap;
using System.Collections.Generic;
using System.Windows;
using HexTool.VVM.UndoRedo;

// ReSharper disable once CheckNamespace
namespace HexTool.VVM
{
    public class MapWindowVm : BaseViewModel<MapRepo>
    {
        public static readonly DependencyProperty BrushesProperty =
            DependencyProperty.Register("Brushes", typeof(List<MapBrush>), typeof(MapWindowVm));

        List<MapBrush> Brushes
        {
            set => SetValue(BrushesProperty, value);
        }

        public static readonly DependencyProperty HexesProperty =
            DependencyProperty.Register("Hexes", typeof(List<HexContentVm>), typeof(MapWindowVm));

        List<HexContentVm> Hexes
        {
            set => SetValue(HexesProperty, value);
        }

        private readonly CommandHandler _commandHandler = new CommandHandler();

        private MapBrush _activeBrush;

        public MapWindowVm(MapRepo repo) : base(repo)
        {
            //Setup test data
            //_repo.ClearMap();
            //_repo.CreateTestData();
            var hexes = _repo.GetMapContent();
            Hexes = ConvertHexesToVm(hexes);
            hexes.Clear(); //Cleanup

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
            var command = new PaintCommand(_repo, hexContentVm, _activeBrush);
            _commandHandler.Execute(command);
        }

        public void SetBrush(MapBrush brush)
        {
            _activeBrush = brush;
        }

        public void Redo()
        {
            _commandHandler.Redo();
        }

        public void Undo()
        {
            _commandHandler.Undo();
        }
    }

    public class PaintCommand : Command
    {
        public PaintCommand(MapRepo repo, HexContentVm hexVm, MapBrush newBrush)
        {
            var oldBrush = hexVm.CreateBrush();
            Redo = () =>
            {
                var hex = hexVm.Content;
                hex.Paint(newBrush);
                hexVm.UpdateImage();
                repo.UpdateHex(hex);
            };
            Undo = () =>
            {
                var hex = hexVm.Content;
                hex.Paint(oldBrush);
                hexVm.UpdateImage();
                repo.UpdateHex(hex);
            };
        }
    }
}