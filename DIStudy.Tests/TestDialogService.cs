using System.Windows;

namespace DIStudy.Tests;

internal class TestDialogService : IDialogService
{
    public string WindowGuid { get; set; } = "";

    public MessageBoxResult Show(string message, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage)
    {
        return MessageBoxResult.OK;
    }

    public MessageBoxResult ShowOnWindow(string message, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage)
    {
        return MessageBoxResult.OK;
    }
}