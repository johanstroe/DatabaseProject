using System.Collections.ObjectModel;
using System.Windows;
using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Database_Frontend.Views;

namespace Database_Frontend
{
    public partial class MainWindow : Window
    {
        private readonly IStatusService _statusService;
        private readonly IProjectService _projectService;

        public ObservableCollection<ProjectStatusEntity> StatusOptions { get; set; } = [];
        public ObservableCollection<ProjectsDto> Projects { get; set; } = [];
        public MainWindow(IStatusService statusService, IProjectService projectService)
        {
            InitializeComponent();
            
            _statusService = statusService;
            _projectService = projectService;

            LoadProjects();
            DataContext = this;
        }

        private void ProjectDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }


        private void OpenAddProjectWindow_Click(object sender, RoutedEventArgs e)
        {
            var newProject = new ProjectEntity
            {
                ProjectName = "Nytt Projekt", // Kan vara tomt om du vill att användaren ska fylla i det
                StatusId = 1, // Standardstatus, om du har en sådan
                StartDate = DateTime.Now
            };

            var addProjectWindow = new AddProjectWindow(_statusService, _projectService);
            if (addProjectWindow.ShowDialog() == true)
            {
                LoadProjects(); // Uppdatera listan efter att ett projekt lagts till
            }
        }


        private void OpenEditProjectWindow_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectDataGrid.SelectedItem is ProjectsDto selectedProject)
            {
                var projectEntity = new ProjectEntity
                {
                    ProjectId = selectedProject.ProjectId,
                    ProjectName = selectedProject.ProjectName,
                    StatusId = selectedProject.StatusId,
                    StartDate = selectedProject.StartDate
                };

                var editWindow = new EditProjectWindow(_projectService, projectEntity);
                editWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Välj ett projekt att redigera!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        

        private async void LoadProjects()
        {
            Projects.Clear();
            var projectsFromDb = await _projectService.GetAllAsync();
            foreach (var project in projectsFromDb)
            {
                Projects.Add(project);
            }


            //var projectsFromDb = await _projectService.GetAllAsync();
            //Projects = new ObservableCollection<ProjectsDto>(projectsFromDb);
        }
    }
}
