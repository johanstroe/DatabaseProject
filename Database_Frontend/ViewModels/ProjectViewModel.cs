using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace Database_Frontend.ViewModels;

public partial class ProjectViewModel : ObservableObject
{
    private readonly IProjectService _projectService;
    

    [ObservableProperty]
    private ObservableCollection<ProjectsDto> _projects;

    [ObservableProperty]
    private ObservableCollection<string> _projectTypes;

    public ProjectViewModel(IProjectService projectService)
    {
        _projectService = projectService;
        
        _projects = new ObservableCollection<ProjectsDto>();
    
        _projectTypes = new ObservableCollection<string>
        {
            "Customer",
            "Employee",
            "Product"
        };

        //LoadProjects();
        LoadStatusOptions();
    }

    //private async void LoadProjects()
    //{
    //    var projectsFromDb = await _projectService.GetAllAsync();
    //    Projects = new ObservableCollection<ProjectsDto>(projectsFromDb);
    //}

    private void LoadStatusOptions()
    {
        
      
    }

    public IRelayCommand AddProjectCommand => new RelayCommand(AddProject);

    private void AddProject()
    {

        //await _projectService.CreateProjectAsync(CreateProjectDto);


        //var addProjectWindow = new AddProjectWindow(this, _statusService);
        //if (addProjectWindow.ShowDialog() == true)
        //{
        //    var newProject = addProjectWindow.NewProject;

        //    try
        //    {
                
        //        var projectEntity = ProjectFactory.Create(newProject);
        //        await _projectService.CreateProjectAsync(projectEntity);

        //        Projects.Add(ProjectFactory.Read(projectEntity));

        //        MessageBox.Show("Projekt sparat i databasen!", "Klart", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}
