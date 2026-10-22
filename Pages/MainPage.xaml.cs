using pract7.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pract7.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        API api = new API();
        public ObservableCollection<Device> devices { get; set; } = new();
        public Device selectedDevice { get; set; } = new();
        public string filterManufacture { get; set; } = string.Empty;
        public decimal filterMinPrice { get; set; } = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void DeviceList_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await api.Get();
            devices.Clear();
            foreach (var item in result)
            {
                devices.Add(item);
            }
        }

        private void GoForm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeviceForm());
        }
        private void GoEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeviceForm(selectedDevice));
        }
        private void GoPatch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeviceForm(selectedDevice.Id));
        }
        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDevice != null)
            {
                MessageBoxResult msgResult = MessageBox.Show("Удалить выбранный объект?", "Удалить?", MessageBoxButton.YesNo);

                if (msgResult == MessageBoxResult.Yes)
                {
                    var result = await api.Remove(selectedDevice.Id);
                    if (result.IsSuccessStatusCode)
                    {
                        devices.Remove(selectedDevice);
                        MessageBox.Show("Удалено");
                    }
                    else
                    {
                        MessageBox.Show(result.Content.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбран элемент");
            }
        }

        private async void Filter_Changed(object sender, RoutedEventArgs e)
        {
            var result = await api.GetFiltered(filterManufacture, filterMinPrice);
            if (result != null)
            {
                devices.Clear();
                foreach (var item in result)
                {
                    devices.Add(item);
                }
            }
            else
            {
                devices.Clear();
            }
        }
    }
}
