using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Databaseproject2025\DatabaseProject\Data\Databases\local_database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

var serviceProvider = serviceCollection.BuildServiceProvider();