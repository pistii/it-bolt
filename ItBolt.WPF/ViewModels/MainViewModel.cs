using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ItBolt.WPF;
using ItBolt.WPF.Commands;
using ItBolt.WPF.ViewModels;
using ItBolt.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ItBolt.WPF.ViewModels
{
    public class MainViewModel : ObservableObject, IUpdateViewCommand
    {

        private ObservableObject _selectedViewModel;
        public IRelayCommand<object> UpdateViewCommand { get; set; }

        public ObservableObject SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            { if (SelectedViewModel != value)
                {
                    SetProperty(ref _selectedViewModel, value);
                    OnPropertyChanged("SelectedViewModel");
                }
            }
        }

        public MainViewModel()
        {
            //SelectedViewModel = App.Current.Services.GetRequiredService<BelepesViewModel>();
            SelectedViewModel = App.Current.Services.GetRequiredService<UdvozloViewModel>();
            UpdateViewCommand = new RelayCommand<object>(e => Execute(e));
            enabledButton = true;
            //enabledButton = false;
            Log = "Belépés";
        }


        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddBolt":
                    SelectedViewModel = App.Current.Services.
                    GetRequiredService<AddBoltViewModel>();
                    break;
                case "AddRaktar":
                    SelectedViewModel = App.Current.Services.
                    GetRequiredService<AddRaktarViewModel>();
                    break;
                case "BoltKimutatas":
                    SelectedViewModel = App.Current.Services.
                    GetRequiredService<BoltKimutatasViewModel>();
                    break;
                case "RaktarKimutatas":
                    SelectedViewModel = App.Current.Services.
                    GetRequiredService<RaktarKimutatasViewModel>();
                    break;
                case "LogIn":
                   SelectedViewModel = App.Current.Services.
                   GetRequiredService<UdvozloViewModel>();
                    break;
                case "LogOut":
                    //reload the view
                    
                    //Task.Factory.StartNew(() => SelectedViewModel = App.Current.Services.
                    //GetRequiredService<BelepesViewModel>());
                    //SelectedViewModel = App.Current.Services.
                    //GetRequiredService<BelepesViewModel>();

                    break;
                default:
                    break;
            }
        }

        private string log;
        public string Log
        {
            get { return log; }
            set {
                SetProperty(ref log, value);
            }
        }

        private bool enabledButton;
        public bool EnabledButton
        {
            get { return enabledButton; }
            set
            { 
                SetProperty(ref enabledButton, value);
            }
        }
}
}
