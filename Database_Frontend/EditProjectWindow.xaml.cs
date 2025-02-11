using System.Windows;
using Data.Entities;
using Database_Frontend.ViewModels;

namespace Database_Frontend;

public partial class EditProjectWindow : Window
{
    public EditProjectWindow(ProjectViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
