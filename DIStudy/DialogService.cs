using System.Windows;

namespace DIStudy;

public class DialogService : IDialogService
{
    public string WindowGuid { get; set; } = Guid.NewGuid().ToString("N");

    public MessageBoxResult Show(string message, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage)
    {
        return MessageBox.Show(message, caption, messageBoxButton, messageBoxImage);
    }

    public MessageBoxResult ShowOnWindow(string message, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage)
    {
        var w = GetWindow();
        if (w is not null)
        {
            w.Opacity = 0.7;
            var r = MessageBox.Show(w, message, caption, messageBoxButton, messageBoxImage);
            w.Opacity = 1;
            return r;
        }
        else
            return MessageBox.Show(message, caption, messageBoxButton, messageBoxImage);
    }

    private Window? GetWindow()
    {
        if (!string.IsNullOrEmpty(WindowGuid))
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Tag?.ToString() == WindowGuid)
                    return window;
            }
        }
        return null;
    }
}

public interface IDialogService
{
    string WindowGuid { get; set; }

    MessageBoxResult Show(string message, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage);

    MessageBoxResult ShowOnWindow(string message, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage);
}