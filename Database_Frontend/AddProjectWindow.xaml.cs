using System.Collections.ObjectModel;
using System.Windows;
using Business.Dtos;
using Business.Interfaces;
using Data.Entities;


namespace Database_Frontend.Views
{
    public partial class AddProjectWindow : Window
    {
        private readonly IStatusService _statusService;
        private readonly IProjectService _projectService;

        public CreateProjectDto NewProject { get; private set; }
        public ObservableCollection<ProjectStatusEntity> StatusOptions { get; private set; }
        public ObservableCollection<string> ProjectTypes { get; private set; }

        public AddProjectWindow(IStatusService statusService, IProjectService projectService)
        {
            InitializeComponent();
            _statusService = statusService;
            _projectService = projectService;
 
            NewProject = new CreateProjectDto();
            StatusOptions = [];
            ProjectTypes = new ObservableCollection<string>
            {
                "Customer",
                "Employee",
                "Product"
            };

            LoadStatusOptions();

            DataContext = this;
        }

        private async void LoadStatusOptions()
        {
            var statuses = await _statusService.GetAllStatusesAsync();
            StatusOptions.Clear();

            if (statuses != null)
            {
                foreach (var status in statuses)
                {
                    StatusOptions.Add(status);
                }
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewProject.ProjectName))
            {
                MessageBox.Show("Projektnamn får inte vara tomt!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (NewProject.StatusId == 0)
            {
                MessageBox.Show("Du måste välja en status!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                var projectDto = new CreateProjectDto
                {
                    ProjectName = NewProject.ProjectName,
                    CreatedDate = NewProject.CreatedDate,
                    EndDate = NewProject.EndDate,
                    ProductId = NewProject.ProductId,
                    StatusId = NewProject.StatusId,
                    EmployeeId = NewProject.EmployeeId,
                    CustomerId = NewProject.CustomerId
                };

                await _projectService.CreateProjectAsync(NewProject);
                MessageBox.Show("Projekt sparat i databasen!", "Klart", MessageBoxButton.OK, MessageBoxImage.Information);

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
