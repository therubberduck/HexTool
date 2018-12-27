using HexTool.Database;
using HexTool.ResourceHandling;
using HexTool.VVM;
using System;
using System.Windows;

namespace HexTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DbInterface _db;
        public DbInterface Db { get { return _db; } }

        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();

            _db = new DbInterface("db.sqlite");

            ResourceRepository.Init(); //Set before factory as factory uses it
            Factory.Init();

            var rootVm = new MapWindowVM(new MapRepo(_db));

            app.MainWindow = rootVm.Window;
            app.MainWindow.Show();
            app.Run();
        }
    }
}
