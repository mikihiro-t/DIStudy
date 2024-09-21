using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DIStudy;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Ioc.Default.ConfigureServices(
            new ServiceCollection()
            .AddTransient<IDialogService, DialogService>()
            .BuildServiceProvider());

        var model= new MainModel();
        var viewModel = new MainViewModel(model);
        var view = new MainView(viewModel);
        view.Show();

        
    }
}