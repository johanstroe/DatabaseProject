using System.Collections.ObjectModel;
using System.Windows;
using Business.Dtos;
using Business.Interfaces;
using Business.Services;
using Data.Entities;


namespace Database_Frontend.Views
{
    public partial class AddProjectWindow : Window
    {
        private readonly IStatusService _statusService;
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public CreateProjectDto NewProject { get; private set; }
        public ObservableCollection<ProjectStatusEntity> StatusOptions { get; private set; }
        public ObservableCollection<EmployeeEntity> EmployeeOptions { get; private set; } = [];
        public ObservableCollection<CustomerEntity> CustomerOptions { get; private set; } = [];
        public ObservableCollection<ProductEntity> ProductOptions { get; private set; } = [];

        public ObservableCollection<string> ProjectTypes { get; private set; }

        public AddProjectWindow(IStatusService statusService, IProjectService projectService, IEmployeeService employeeService, ICustomerService customerService, IProductService productService)
        {
            InitializeComponent();
            _statusService = statusService;
            _projectService = projectService;
            _employeeService = employeeService;
            _customerService = customerService;
            _productService = productService;
            NewProject = new CreateProjectDto();
            StatusOptions = [];
            ProjectTypes = new ObservableCollection<string>
            {
                "Employee",
                "Customer",
                "Product"
            };

            LoadStatusOptions();
            LoadEmployeeOptions();
            LoadProductsOptions();
            LoadCustomerOptions();

            DataContext = this;
            _customerService = customerService;
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


        private async void LoadEmployeeOptions()
        {
            var employees = await _employeeService.GetAllAsync();
            EmployeeOptions.Clear();

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    EmployeeOptions.Add(employee);
                }
            }
        }


        private async void LoadCustomerOptions()
        {
            var customers = await _customerService.GetAllAsync();
            CustomerOptions.Clear();

            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    CustomerOptions.Add(customer);
                }
            }
        }

        private async void LoadProductsOptions()
        {
            var products = await _productService.GetAllAsync();
            ProductOptions.Clear();

            if (products != null)
            {
                foreach (var product in products)
                {
                    ProductOptions.Add(product);
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

            MessageBox.Show($"Projekt: {NewProject.ProjectName}\n" +
                $"Startdatum: {NewProject.CreatedDate}\n" +
                $"Slutdatum: {NewProject.EndDate}\n" +
                $"StatusId: {NewProject.StatusId}\n" +
                $"EmployeeId: {NewProject.EmployeeId}\n" +
                $"CustomerId: {NewProject.CustomerId}\n" +
                $"ProductId: {NewProject.ProductId}",
                "Debug - Före Save", MessageBoxButton.OK, MessageBoxImage.Information);
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

                var errorMessage = $"Ett fel uppstod: {ex.Message}";

                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
