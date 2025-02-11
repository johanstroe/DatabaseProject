
using System.Windows;
using Data.Entities;

namespace Database_Frontend.Views;

public partial class AddProjectWindow : Window
{
    public ProjectEntity NewProject { get; private set; }

    public List<string> StatusOptions { get; } = ["Ej påbörjat", "Pågående", "Avslutat"];

    public AddProjectWindow()
    {
        InitializeComponent();
        NewProject = new ProjectEntity { StartDate = DateTime.Now }; // Förifyll startdatum till idag
        DataContext = this;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewProject.ProjectName))
        {
            MessageBox.Show("Projektnamn får inte vara tomt!", "Fel", MessageBoxButton.OK, MessageBoxImage.Warning);
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
