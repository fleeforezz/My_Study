using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Views;

namespace UI.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowProductCommand { get; }
        public ICommand ShowCustomerCommand { get; }
        public ICommand ShowOrderCommand { get; }
        public ICommand ShowReportCommand { get; }

        public MainViewModel()
        {
            // Init default view
            CurrentView = new DashboardView();

            // Create commands
            ShowDashboardCommand = new RelayCommand(_ => CurrentView = new DashboardView());
            ShowProductCommand = new RelayCommand(_ => CurrentView = new ProductView());
            ShowCustomerCommand = new RelayCommand(_ => CurrentView = new CustomerView());
            ShowOrderCommand = new RelayCommand(_ => CurrentView = new OrderView());
            ShowReportCommand = new RelayCommand(_ => CurrentView = new ReportView());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
