using System.Collections.ObjectModel;
using System.Windows;
using Data.Entities;
using Business.Interfaces;
using Database_Frontend.ViewModels;

namespace Database_Frontend.Views
{
    public partial class AddProjectWindow : Window
    {
        private readonly IStatusService _statusService;

        public ProjectEntity NewProject { get; private set; }

        public ObservableCollection<ProjectStatusEntity> StatusOptions { get; private set; }

        public AddProjectWindow(ProjectViewModel viewModel, IStatusService statusService)
        {
            InitializeComponent();
            _statusService = statusService;

            NewProject = new ProjectEntity { StartDate = DateTime.Now };
            StatusOptions = new ObservableCollection<ProjectStatusEntity>();

            LoadStatusOptions();

            // Sätt rätt DataContext för att säkerställa att XAML kan binda till rätt objekt
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

            if (StatusOptions.Count > 0)
            {
                MessageBox.Show($"Dropdown innehåller: {string.Join(", ", StatusOptions.Select(s => s.StatusName))}");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
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

            DialogResult = true;
            Close();
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
