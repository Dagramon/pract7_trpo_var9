using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pract7.Model
{
    public partial class Device : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string? name = null;
        private string? manufacturer = null;
        private decimal? price = null;
        private int? quantity = null;
        private bool? isActive = null;
        public string? Name 
        { 
            get
            {
                return name;
            } 
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            } 
        }

        public string? Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }

        public decimal? Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public int? Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public bool? IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
