using pract7.Model;

using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для DeviceForm.xaml
    /// </summary>
    public partial class DeviceForm : Page
    {
        API api = new();
        public Device currentDevice { get; set; } = new();
        bool isEdit = false;
        bool isPatch = false;
        public DeviceForm(Device? _editableDevice = null)
        {
            InitializeComponent();
            if (_editableDevice != null)
            {
                currentDevice = _editableDevice;
                isEdit = true;
            }
            DataContext = currentDevice;
        }
        public DeviceForm(int index)
        {
            InitializeComponent();
            isPatch = true;
            DataContext = currentDevice;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPatch)
            {
                var result = await api.Patch(currentDevice, currentDevice.Id);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Девайс сохранён");
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show(result.Content.ToString(), "Ошибка сохранения");
                }
                return;
            }
            if (isEdit)
            {
                var result = await api.Put(currentDevice, currentDevice.Id);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Девайс сохранён");
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show(result.Content.ToString(), "Ошибка сохранения");
                }
                return;
            }
            var response = await api.Post(currentDevice);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Девайс сохранён");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show(response.Content.ToString(), "Ошибка сохранения");
            }
        }
    }
}
