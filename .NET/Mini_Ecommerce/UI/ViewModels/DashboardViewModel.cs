using MiniEcommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;

        public int _productCount;

        public int ProductCount
        {
            get { return _productCount; } 
            set 
            { 
                _productCount = value; 
                OnPropertyChanged();
            }
        }

        public DashboardViewModel(IProductService productService)
        {
            _productService = productService;
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var products = await _productService.GetAllAsync();
            ProductCount = products.Count();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
