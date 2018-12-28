using HexTool.Database;
using HexTool.ResourceHandling;
using HexTool.VVM;
using System;
using System.Diagnostics;
using System.Windows;

namespace HexTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DbInterface _db;

        App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            PresentationTraceSources.Refresh();
            PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
            PresentationTraceSources.DataBindingSource.Listeners.Add(new DebugTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning | SourceLevels.Error;
            base.OnStartup(e);
        }

        [STAThread]
        static void Main()
        {
            App app = new App();

            _db = new DbInterface("db.sqlite");

            ResourceRepository.Init(); //Set before factory as factory uses it
            Factory.Init();

            var rootVm = new MapWindowVm(new MapRepo(_db));

            app.MainWindow = rootVm.Window;
            app.MainWindow?.Show();
            app.Run();
        }
    }

    //From https://spin.atomicobject.com/2013/12/11/wpf-data-binding-debug/
    public class DebugTraceListener : TraceListener
    {
        public override void Write(string message)
        {
        }

        public override void WriteLine(string message)
        {
            Debugger.Break();
        }
    }
}
