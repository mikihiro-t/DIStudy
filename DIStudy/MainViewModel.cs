using CommunityToolkit.Mvvm.DependencyInjection;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Diagnostics;
using System.Reactive.Disposables;

namespace DIStudy;

public class MainViewModel : NotifyBase, IDisposable
{
    public MainModel Model { get; set; }

    public ReactiveCommand ShowMessageOnModelCommand { get; } = new();
    public ReactiveCommand ShowMessage2OnModelCommand { get; } = new();

    public ReactiveCommand AddCommand { get; } = new();

    public ReactiveProperty<string> Text1 { get; set; } = new("1");
    public ReactiveProperty<string> Text2 { get; set; } = new("2");

    #region DialogService

    private readonly IDialogService _dialogService = Ioc.Default.GetRequiredService<IDialogService>();

    public string GuidOfDialogService
    {
        get => _dialogService.WindowGuid;
        set => _dialogService.WindowGuid = value;
    }

    #endregion

    public MainViewModel(MainModel model)
    {
        Model = model;
        _dialogService.WindowGuid = Model.GuidOfDialogService;

        ShowMessageOnModelCommand.Subscribe(ShowMessageOnModel).AddTo(Disposable);
        ShowMessage2OnModelCommand.Subscribe(ShowMessage2OnModel).AddTo(Disposable);
        AddCommand.Subscribe(Add).AddTo(Disposable);
    }

    public void ShowMessageOnModel()
    {
        Model.ShowMessageOnModel();
    }

    public void ShowMessage2OnModel()
    {
        Model.ShowMessage2OnModel();
    }

    public void Add()
    {
        Model.Add(double.Parse(Text1.Value), double.Parse(Text2.Value));
    }

    #region Dispose

    private bool disposedValue;
    private CompositeDisposable Disposable { get; } = [];

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Debug.WriteLine("MainViewModel Disposed");
                Disposable.Dispose();
                Model.Dispose();
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