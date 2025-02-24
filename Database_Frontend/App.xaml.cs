﻿using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Data.Entities;
using Business.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Database_Frontend;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {

        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Johaa\\OneDrive\\Skrivbord\\local_db_v2.mdf;Integrated Security=True;Connect Timeout=30"));

        //BaseRepository
        services.AddScoped<IBaseRepository<ProjectEntity>, BaseRepository<ProjectEntity>>();
        services.AddScoped<IBaseRepository<CustomerEntity>, BaseRepository<CustomerEntity>>();
        services.AddScoped<IBaseRepository<EmployeeEntity>, BaseRepository<EmployeeEntity>>();
        services.AddScoped<IBaseRepository<ProductEntity>, BaseRepository<ProductEntity>>();
        services.AddScoped<IBaseRepository<ProjectStatusEntity>, BaseRepository<ProjectStatusEntity>>();
        
        //Repositories
        services.AddScoped<ProjectRepository>();
        services.AddScoped<EmployeeRepository>();
        services.AddScoped<ProductRepository>();
        services.AddScoped<CustomerRepository>();
        services.AddScoped<ProjectStatusRepository>();

        //Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<IProjectService, ProjectService>();
        
        //MainWindow
        services.AddSingleton<MainWindow>();
    }
}
