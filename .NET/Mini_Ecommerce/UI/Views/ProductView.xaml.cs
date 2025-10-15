using MiniEcommerce.Application.Interfaces;
using MiniEcommerce.Application.Services;
using MiniEcommerce.Domain.Entities;
using MiniEcommerce.Domain.Repositories;
using MiniEcommerce.Infrastructure.Persistence;
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
using UI.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();

            // This is Manual Dependency Injection
            // 1. Build database layer
            var db = new FileDatabase<Product>("products.json");

            // 2. Create repository implementation
            IProductRepository repo = new ProductRepository(db);

            // 3. Inject repository implementation
            IProductService productService = new ProductService(repo);

            // 4. Pass service into ViewModel
            var viewModel = new ProductViewModel(productService);

            // 5. Load Data
            _ = viewModel.LoadProductAsync();

            // 6. Bind to UI
            DataContext = viewModel;
        }
    }
}
