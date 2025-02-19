using System.Windows;
using Business.Interfaces;
using Data.Entities;


namespace Database_Frontend;

public partial class EditProjectWindow : Window
{

    private readonly IProjectService _projectService;
    public ProjectEntity Project { get; set; }

    public EditProjectWindow(IProjectService projectService, ProjectEntity project)
    {
        InitializeComponent();
        _projectService = projectService;
        Project = project;
        DataContext = this;
    }

    private async void SaveChanges_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await _projectService.UpdateAsync(Project);
            MessageBox.Show("Projektet har uppdaterats!", "Klart", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CloseWindow_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}

