using System.Collections.ObjectModel;
using System.Windows;
using Business.Dtos;
using Business.Interfaces;
using Database_Frontend.Views;

namespace Database_Frontend
{
    public partial class MainWindow : Window
    {
        private readonly IStatusService _statusService;
        private readonly IProjectService _projectService;

        private ObservableCollection<ProjectsDto> Projects { get; set; } = new();
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
            var addProjectWindow = new AddProjectWindow(_statusService, _projectService);
            addProjectWindow.ShowDialog();
        }

        private async void LoadProjects()
        {
            var projectsFromDb = await _projectService.GetAllAsync();
            Projects = new ObservableCollection<ProjectsDto>(projectsFromDb);
        }
    }
}
