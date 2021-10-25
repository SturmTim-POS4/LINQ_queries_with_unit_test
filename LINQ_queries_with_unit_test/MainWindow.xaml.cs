using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PersonDBLing;

namespace LINQ_queries_with_unit_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        PersonContext db = new PersonContext();

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            cboCountries.ItemsSource =db.Addresses;
            
            panRadios.Children.OfType<RadioButton>()
                .ToList()
                .ForEach(x => x.Click += RadioButtonEnable);
            
            panCheckboxes.Items.OfType<CheckBox>()
                .ToList()
                .ForEach(x => x.Click += CheckboxButtonEnable);
            
            db.Persons.Select(x => x.Address.City)
                .Distinct()
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => panButtons.Children.Add(new Button
            {
                Content = x
            }));
            panButtons.Children.OfType<Button>().ToList().ForEach(x => x.Click += CityButtonClicked);
        }

        private void CityButtonClicked(object sender, RoutedEventArgs e)
        {
            panPersons.Children.Clear();
            Button button = sender as Button;
            db.Persons.Where(x => x.Address.City.Equals(button.Content.ToString()))
                .Select(x => $"{x.Lastname} {x.Firstname}")
                .ToList()
                .ForEach(x => panPersons.Children.Add(new Label
                {
                    Content = x
                }));
        }

        private void RadioButtonEnable(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton checkedButton) lblCheckedRadio.Content = checkedButton.Content;
        }
        
        private void CheckboxButtonEnable(object sender, RoutedEventArgs e)
        {
            lblCheckedCheckboxes.Content = string.Join(", ", panCheckboxes.Items.OfType<CheckBox>()
                .Where(x => x.IsChecked is true)
                .Select(x => x.Content.ToString())
                .ToList());
        }

        private void CboCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (db.Addresses.Contains(cboCountries.SelectedItem as Address))
            {
                Address selectedAddress = db.Addresses[db.Addresses.IndexOf(cboCountries.SelectedValue as Address)];
                lstPersonsInCountry.ItemsSource = db.Persons.Where(x => x.AddressId == selectedAddress.Id)
                    .OrderBy(x => x.Lastname)
                    .Select(x => $"{x.Lastname} {x.Firstname}: {x.Address.Country}/{x.Address.City}")
                    .ToList();
            }
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            lstPersonsFound.ItemsSource = db.Persons.Where(x => x.Firstname.Contains(txtSearch.Text) || x.Lastname.Contains(txtSearch.Text))
                .OrderBy(x => x.Lastname)
                .ThenBy(x => x.Firstname)
                .Select(x => $"{x.Lastname} {x.Firstname} [{x.Birthday}]")
                .ToList();
        }

        private void SldMinLength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            panTextboxes.Children.OfType<TextBox>().Where(x => x.Text.Length < sldMinLength.Value)
                .ToList()
                .ForEach(x => x.Background = Brushes.Red);
            
            panTextboxes.Children.OfType<TextBox>().Where(x => x.Text.Length > sldMinLength.Value)
                .ToList()
                .ForEach(x => x.Background = Brushes.White);
        }
        
        
    }
}