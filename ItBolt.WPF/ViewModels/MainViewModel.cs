using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ItBolt.WPF;
using ItBolt.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ItBolt.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ObservableObject _selectedViewModel;
        public ObservableObject SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }
        public IRelayCommand<object> UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new RelayCommand<object>(e => Execute(e));
            // Required = nem lehet null értékű

            SelectedViewModel = App.Current.Services.GetRequiredService<BelepesViewModel>();
            //SelectedViewModel = App.Current.Services.GetRequiredService<BoltKimutatasViewModel>();
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddBolt":
                    //SelectedViewModel = new AddBoltViewModel();
                    SelectedViewModel = App.Current.Services.
                    GetRequiredService<AddBoltViewModel>();
                    break;
                case "BoltKimutatas":
                    //SelectedViewModel = new AddBoltViewModel();
                    SelectedViewModel = App.Current.Services.
                    GetRequiredService<BoltKimutatasViewModel>();
                    break;
                default:
                    break;
            }
        }
    }
}
