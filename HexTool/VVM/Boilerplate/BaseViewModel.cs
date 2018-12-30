using System.Windows;

// ReSharper disable once CheckNamespace
namespace HexTool.VVM
{
    public abstract class BaseViewModel<T> : DependencyObject
    {
        public Window Window {get; protected set;}

        protected T _repo;

        protected BaseViewModel(T repo)
        {
            _repo = repo;
        }

        public void SetAsMainAndRun(App app)
        {
            app.MainWindow = Window;
            app.MainWindow?.Show();
            app.Run();
        }
    }
}
