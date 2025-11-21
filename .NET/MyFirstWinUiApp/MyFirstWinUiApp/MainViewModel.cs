using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWinUiApp
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial int Count {  get; set; }

        [RelayCommand]
        public void InrementCount()
        {
            Count++;
        }
    }
}
