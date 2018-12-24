using HexTool.Database;
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

            app.MainWindow = new MapWindow();
            app.MainWindow.Show();
            app.Run();
        }
    }
}
