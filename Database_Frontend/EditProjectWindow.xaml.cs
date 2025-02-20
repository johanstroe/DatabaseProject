using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Services;
using Data.Entities;


namespace Database_Frontend;

public partial class EditProjectWindow : Window
{

    private readonly IProjectService _projectService;
    private readonly IStatusService _statusService;
    private readonly IEmployeeService _employeeService;
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;


    public UpdateProjectDto Project { get; set; }
    public ObservableCollection<ProjectStatusEntity> StatusOptions { get; private set; } = [];
    public ObservableCollection<EmployeeEntity> EmployeeOptions { get; private set; } = [];
    public ObservableCollection<ProductEntity> ProductOptions { get; private set; } = [];

    public ObservableCollection<CustomerEntity> CustomerOptions { get; private set; } = [];

    public EditProjectWindow(IProjectService projectService,IStatusService statusService, IEmployeeService employeeService, ICustomerService customerService, IProductService productService, UpdateProjectDto project)
    {
        InitializeComponent();
        _projectService = projectService;
        _statusService = statusService;
        _employeeService = employeeService;
        _customerService = customerService;
        _productService = productService;

        Project = project;

        Loaded += async (s, e) => await LoadDataAsync();

        
        DataContext = this;
    }

    private async Task LoadDataAsync()
    {
        await LoadStatusOptions();
        await LoadEmployeesOptions();
        await LoadProductOptions();
        await LoadCustomersOptions();
    }


    private async Task LoadStatusOptions()
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

    private async Task LoadEmployeesOptions()
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

    private async Task LoadCustomersOptions()
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

    private async Task LoadProductOptions()
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

    public async void Save_Click(object sender, RoutedEventArgs e)
    {
        

        if (string.IsNullOrWhiteSpace(Project.ProjectName))
        {
            MessageBox.Show("Projektnamn får inte vara tomt!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (Project.StatusId == 0)
        {
            MessageBox.Show("Du måste välja en status!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
           
            var projectEntity = ProjectFactory.Create(Project);
           
            Console.WriteLine($"Uppdaterar projekt: {projectEntity.ProjectId} - {projectEntity.ProjectName}");

            MessageBox.Show
                ($"Projekt: {Project.ProjectName}\n" +
                $"Startdatum: {Project.CreatedDate}\n" +
                $"Slutdatum: {Project.EndDate}\n" +
                $"StatusId: {Project.StatusId}\n" +
                $"EmployeeId: {Project.EmployeeId}\n" +
                $"CustomerId: {Project.CustomerId}",
                "Debug - Före Save", MessageBoxButton.OK, MessageBoxImage.Information);
           
            await _projectService.UpdateAsync(projectEntity);

            MessageBox.Show("Projekt uppdaterat i databasen!", "Klart", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }



    public void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}



