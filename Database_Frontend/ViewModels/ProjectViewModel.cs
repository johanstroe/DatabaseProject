using Business.Factories;
using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data.Entities;
using Database_Frontend.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace Database_Frontend.ViewModels;

public partial class ProjectViewModel : ObservableObject
{
    private readonly IProjectService _projectService;
    private readonly IStatusService _statusService;

    [ObservableProperty]
    private ObservableCollection<ProjectEntity> _projects;

    [ObservableProperty]
    private ObservableCollection<ProjectStatusEntity> _statusOptions;

    public ProjectViewModel(IProjectService projectService, IStatusService statusService)
    {
        _projectService = projectService;
        _statusService = statusService;
        _projects = new ObservableCollection<ProjectEntity>();
        _statusOptions = new ObservableCollection<ProjectStatusEntity>();

        LoadProjects();
        LoadStatusOptions();
    }

    private async void LoadProjects()
    {
        var projectsFromDb = await _projectService.GetAllAsync();
        Projects = new ObservableCollection<ProjectEntity>(projectsFromDb);
    }

    private async void LoadStatusOptions()
    {
        var statuses = await _statusService.GetAllStatusesAsync();
        if (statuses == null || !statuses.Any())
        {
            MessageBox.Show("Inga statusar hämtades från databasen!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        else
        {
            MessageBox.Show($"Antal statusar hämtade: {statuses.Count()}");
        }
        StatusOptions = new ObservableCollection<ProjectStatusEntity>(statuses);
    }

    public IRelayCommand AddProjectCommand => new RelayCommand(AddProject);

    private async void AddProject()
    {
        var addProjectWindow = new AddProjectWindow(this, _statusService); // Lägg till _statusService
        if (addProjectWindow.ShowDialog() == true)
        {
            var newProject = addProjectWindow.NewProject;

            try
            {
                var dto = ProjectFactory.Create(newProject);
                await _projectService.CreateProjectAsync(dto);

                Projects.Add(newProject);

                MessageBox.Show("Projekt sparat i databasen!", "Klart", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Ett fel uppstod", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
