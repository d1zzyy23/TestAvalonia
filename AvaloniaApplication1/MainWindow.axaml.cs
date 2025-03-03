using System;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ViewHandler(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Name is string viewName)
        {
            string fullWindowName = $"{GetType().Namespace}.{viewName}";
            var viewType = Assembly.GetExecutingAssembly().GetType(fullWindowName);
            if (viewType != null && Activator.CreateInstance(viewType) is UserControl newContent)
            {
                ContentArea.Content = newContent;
            }
        }
    }

    private void ThemeToggled(object sender, RoutedEventArgs e)
    {
        var resources = Avalonia.Application.Current?.Resources;
        bool toggled = ((ToggleButton)sender).IsChecked ?? false;

        if (!toggled)
        {
            resources["PrimaryBackground"] = new SolidColorBrush(new Color(255, 22, 22, 22));
            resources["PrimaryForeground"] = new SolidColorBrush(Colors.Gainsboro);
            resources["PrimaryBackgroundColor"] = new Color(255, 22, 22, 22);
            resources["PrimaryBackgroundColor2"] = new Color(255, 11,11,11);

        }
        else
        {
            resources["PrimaryBackground"] = new SolidColorBrush(Colors.Gainsboro);
            resources["PrimaryForeground"] = new SolidColorBrush(new Color(255, 22, 22, 22));
            resources["PrimaryBackgroundColor"] = Colors.Gainsboro;
            resources["PrimaryBackgroundColor2"] = Colors.White;

        }
    }
}