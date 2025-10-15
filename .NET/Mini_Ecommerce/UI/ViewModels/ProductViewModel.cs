using MiniEcommerce.Application.DTOs;
using MiniEcommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;

        // Collection bound to your view (e.g., DataGrid, ListView)
        private ObservableCollection<ProductDto> product = new ObservableCollection<ProductDto>();
        public ObservableCollection<ProductDto> Products
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
        }

        // Load all products from the service
        public async Task LoadProductAsync()
        {
            var productList = await _productService.GetAllAsync();
            Products = new ObservableCollection<ProductDto>(productList);
        }

        // PropertyChanged boilerplate
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
