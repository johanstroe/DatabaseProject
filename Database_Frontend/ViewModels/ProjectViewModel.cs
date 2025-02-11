using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Services;
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

    [ObservableProperty]
    private ObservableCollection<ProjectEntity> _projects;

    // 🛠️ Lägg till egenskap för valt projekt
    [ObservableProperty]
    private CreateProjectDto? _selectedProject;

    public ProjectViewModel(IProjectService projectService)
    {
        _projectService = projectService;
        _projects = new ObservableCollection<ProjectEntity>();

        
        LoadProjects();
    }

    public async void LoadProjects()
    {
        var projectsFromDb = await _projectService.GetAllAsync();
        Projects = new ObservableCollection<ProjectEntity>(projectsFromDb);
    }

    public IRelayCommand AddProjectCommand => new RelayCommand(AddProject);

    public IRelayCommand DeleteProjectCommand => new RelayCommand<ProjectEntity>(async project => await DeleteProject(project!));

    private async void AddProject()
    {
        var addProjectWindow = new AddProjectWindow();
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

          

            Projects.Add(newProject);
            MessageBox.Show("Projekt tillagt!", "Klart", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }


    public IRelayCommand EditProjectCommand => new RelayCommand(OpenEditProjectWindow);

    private void OpenEditProjectWindow()
         
    {
        MessageBox.Show($"Valt projekt: {(SelectedProject != null ? SelectedProject.ProjectName : "Inget projekt valt")}", "Debugging", MessageBoxButton.OK, MessageBoxImage.Information);
       
        if (SelectedProject == null)
        {
            MessageBox.Show("Välj ett projekt att redigera!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var editWindow = new EditProjectWindow(this);
        editWindow.ShowDialog();
    }

    public IRelayCommand UpdateProjectCommand => new RelayCommand<object>(async parameter =>
    {
        if (parameter is ProjectEntity project)
        {
            await UpdateProject(project);
        }
        else
        {
            MessageBox.Show("Inget projekt valt för uppdatering!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    });

    private async Task UpdateProject(ProjectEntity project)
    {
        if (project == null) return;

        var result = MessageBox.Show($"Vill du spara ändringar i '{project.ProjectName}'?",
                                     "Bekräfta uppdatering",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question);

        if (result == MessageBoxResult.No) return;

        try
        {
            await _projectService.UpdateAsync(project);

            var index = Projects.IndexOf(Projects.First(p => p.ProjectId == project.ProjectId));
            if (index >= 0)
            {
                Projects[index] = project;
            }

            MessageBox.Show("Projektet har uppdaterats!", "Uppdatering klar", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ett fel uppstod vid uppdatering: {ex.Message}", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    //public IRelayCommand SaveProjectCommand => new RelayCommand(async () => await SaveProject());

    //private async Task SaveProject()
    //{
    //    if (SelectedProject == null) return;

    //    try
    //    {
    //        await _projectService.UpdateAsync(SelectedProject);

    //        var index = Projects.IndexOf(Projects.FirstOrDefault(p => p.ProjectId == SelectedProject.ProjectId));
    //        if (index >= 0)
    //        {
    //            Projects[index] = SelectedProject; // Uppdatera UI
    //        }

    //        MessageBox.Show("Projektet har uppdaterats!", "Uppdatering klar", MessageBoxButton.OK, MessageBoxImage.Information);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Ett fel uppstod vid uppdatering: {ex.Message}", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
    //    }
    //}

    private async Task DeleteProject(ProjectEntity project)
    {
        if (project == null) return;

        var result = MessageBox.Show($"Vill du verkligen ta bort projektet '{project.ProjectName}'?",
                                 "Bekräfta borttagning",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Warning);
        if (result == MessageBoxResult.No) return;

        try
        {
            await _projectService.DeleteAsync(project.ProjectId);
            Projects.Remove(project);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ett fel uppstod vid borttagning: {ex.Message}", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
