using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Data.Entities;
using Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Database_Frontend.ViewModels;


namespace Database_Frontend
{
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

            services.AddScoped<IBaseRepository<ProjectEntity>, BaseRepository<ProjectEntity>>();
            services.AddScoped<IBaseRepository<CustomerEntity>, BaseRepository<CustomerEntity>>();
            services.AddScoped<IBaseRepository<EmployeeEntity>, BaseRepository<EmployeeEntity>>();
            services.AddScoped<IBaseRepository<ProductEntity>, BaseRepository<ProductEntity>>();
            services.AddScoped<IBaseRepository<ProjectStatusEntity>, BaseRepository<ProjectStatusEntity>>();
            services.AddScoped<ProjectRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<ProjectStatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<EmployeeService, EmployeeService>();
            services.AddScoped<ProjectViewModel>();
            services.AddSingleton<MainWindow>();
        }
    }
}
