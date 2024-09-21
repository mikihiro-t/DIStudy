using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows;

namespace DIStudy;

public class MainModel : NotifyBase, IDisposable
{
    #region DialogService

    private readonly IDialogService _dialogService = Ioc.Default.GetRequiredService<IDialogService>();

    public string GuidOfDialogService
    {
        get => _dialogService.WindowGuid;
        set => _dialogService.WindowGuid = value;
    }

    #endregion

    public MainModel()
    {
    }

    public void ShowMessageOnModel()
    {
        _dialogService.ShowOnWindow("ShowOnWindow Message on the Model", "view", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public void ShowMessage2OnModel()
    {
        _dialogService.Show("Show Message on the Model", "view", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public double Add(double a, double b)
    {
        var c = a + b;
        var result = _dialogService.ShowOnWindow($"{a} + {b} = {c}", "Result", MessageBoxButton.OK, MessageBoxImage.None);
        if (result != MessageBoxResult.OK) return 0;
        return c;
    }

    #region Dispose

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
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