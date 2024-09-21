using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows;

namespace DIStudy;

public partial class MainView : Window, IDisposable
{
    private readonly MainViewModel vm;
    private readonly IDialogService _dialogService = Ioc.Default.GetRequiredService<IDialogService>();

    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        vm = viewModel;
        DataContext = vm;

        _dialogService.WindowGuid = vm.Model.GuidOfDialogService;
        Tag = _dialogService.WindowGuid;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _dialogService.ShowOnWindow("ShowOnWindow Message on the view", "view", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        _dialogService.Show("Show Message on the view", "view", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        Dispose();
    }

    #region Dispose View

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                vm.Dispose();
                DataContext = null;
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}