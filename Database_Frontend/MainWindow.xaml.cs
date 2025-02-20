using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Services;
using Data.Entities;
using Database_Frontend.Views;

namespace Database_Frontend
{
    public partial class MainWindow : Window
    {
        private readonly IStatusService _statusService;
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public ObservableCollection<ProjectStatusEntity> StatusOptions { get; set; } = [];
        public ObservableCollection<ProjectStatusEntity> CustomerOptions { get; set; } = [];

        public ObservableCollection<ProjectStatusEntity> EmployeeOptions { get; set; } = [];

        public ObservableCollection<ProjectStatusEntity> ProductOptions { get; set; } = [];
        public ObservableCollection<ProjectsDto> Projects { get; set; } = [];
        public MainWindow(IStatusService statusService, IProjectService projectService, IEmployeeService employeeService, ICustomerService customerService, IProductService productService)
        {
            InitializeComponent();

            _statusService = statusService;
            _projectService = projectService;
            _employeeService = employeeService;
            _customerService = customerService;
            _productService = productService;

           
            DataContext = this;
            Loaded += MainWindow_Loaded;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadProjects();
        }

        private void ProjectDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }


        private async void OpenAddProjectWindow_Click(object sender, RoutedEventArgs e)
        {
            var newProject = new ProjectEntity
            {

            };

            var addProjectWindow = new AddProjectWindow(_statusService, _projectService, _employeeService, _customerService, _productService);
            if (addProjectWindow.ShowDialog() == true)
            {
              await LoadProjects(); // Uppdatera listan efter att ett projekt lagts till
            }
        }


        private async void OpenEditProjectWindow_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectDataGrid.SelectedItem is ProjectsDto selectedProject)
            {
                Debug.WriteLine($"Valt Projekt: {selectedProject.ProjectName}, Status: {selectedProject.StatusName}, " +
                          $"CustomerId: {selectedProject.CustomerId}, Email: {selectedProject.EmployeeEmail}");
                var updateProjectDto = ProjectFactory.CreateUpdateDto(selectedProject);

                var editWindow = new EditProjectWindow(_projectService, _statusService, _employeeService, _customerService, _productService, updateProjectDto);

                bool? result = editWindow.ShowDialog();

                if (result == true)
                {
                   await LoadProjects();
                }
            }
            else
            {
                MessageBox.Show("Välj ett projekt att redigera!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private async Task LoadProjects()
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

        private async void RefreshProjects_Click(object sender, RoutedEventArgs e)
        {
           await LoadProjects();
            MessageBox.Show("Sidan har uppdaterats!", "Uppdaterad", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private async void DeleteProjects_click(object sender, RoutedEventArgs e)
        {
            if (ProjectDataGrid.SelectedItem is ProjectsDto selectedProject)
            {
                Debug.WriteLine($"Valt projekt: {selectedProject.ProjectName}, ProjectId = {selectedProject.ProjectId}");

                var result = MessageBox.Show($"Är du säker på att du vill ta bort projektet '{selectedProject.ProjectName}'?",
                                             "Bekräfta borttagning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        bool success = await _projectService.DeleteAsync(selectedProject.ProjectId);

                        if (success)
                        {
                            MessageBox.Show("Projektet har tagits bort!", "Klart", MessageBoxButton.OK);
                            
                            await LoadProjects(); 
                        }
                        else
                        {
                            MessageBox.Show($"Projektet kunde inte tas bort. ProjectId: {selectedProject.ProjectId}",
                               "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Välj ett projekt att ta bort!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}