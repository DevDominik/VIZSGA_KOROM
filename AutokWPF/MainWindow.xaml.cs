using AutokConsole.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutokWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LoadCSVFromDialogButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        openFileDialog.Title = "Select a CSV file";
        if (openFileDialog.ShowDialog() == true)
        {
            string filePath = openFileDialog.FileName;
            Auto.LoadFromCSV(filePath);
        }
        CarsDataGrid.ItemsSource = new ObservableCollection<Auto>(Auto.GetCars());
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        if (MessageBox.Show("Biztos ki akar lépni?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }
    }

    private void CarsFromYearTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(CarsFromYearTextBox.Text, out int year))
        {
            CarsFromYearListBox.ItemsSource = Auto.GetCars().Where(car => car.Year == year).ToList();
        }
    }
}