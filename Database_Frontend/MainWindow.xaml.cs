using Business.Interfaces;
using Business.Services;
using Data.Entities;
using Data.Repositories;
using Database_Frontend.ViewModels;
using System.Windows;
namespace Database_Frontend;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(ProjectViewModel viewModel) 
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void ProjectDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {

    }
}