using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ApiClient.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ItBolt.Model.Entities;
using ItBolt.WPF.Commands;
using ItBolt.WPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ItBolt.WPF.ViewModels
{
    public class BelepesViewModel : ObservableObject, IUpdateViewCommand
    {

        private ILoginRepository<Felhasznalo> _felhasznaloRepo;

        public IRelayCommand<object> UpdateViewCommand { get; set; }
        public bool loggedIn;

        // https://blog.magnusmontin.net/2022/01/20/bind-to-a-parent-element-in-winui-3/
        //https://www.petrzavodny.com/blog/AsyncFeedWithSpinnerWPFMVVM.html
        //Passwordbox https://stackoverflow.com/questions/1483892/how-to-bind-to-a-passwordbox-in-mvvm

        public BelepesViewModel(ILoginRepository<Felhasznalo> felhasznaloRepo)
        {
            SpinSpinner(false, "Hidden");
            ShowResult = "Hidden"; 
            _felhasznaloRepo = felhasznaloRepo;
            UpdateViewCommand = new RelayCommand<object>(e => LogIn(e));
            loggedIn = false;
        }

        public async Task LogIn(object dc)
        {
            SpinSpinner(true, "Visible");
            var letezik = await _felhasznaloRepo.ExistsByNameAndPw(Nev!, Password);
            if (letezik)
            {
                LoggedIn();
            }
            else
            {
                await Task.Delay(600);
                ShowError("Visible");
                SpinSpinner(false, "Hidden");
            }
        }

        private static void LoggedIn()
        {
            App.Current.Services.GetRequiredService<MainViewModel>().EnabledButton = true;
            App.Current.Services.GetRequiredService<MainViewModel>().Log = "Kilépés";
            App.Current.Services.GetRequiredService<MainViewModel>().UpdateViewCommand.Execute("LogIn");
        }


        private void SpinSpinner(bool shouldSpin, string showSpinner)
        {
            SpinnerShouldSpin = shouldSpin;
            ShowSpinner = showSpinner;
        }
        private void ShowError(string result)
        {
            ShowResult = result;
        }

        private bool spinnerShouldSpin;
        public bool SpinnerShouldSpin
        {
            get { return spinnerShouldSpin; }
            set
            {
                spinnerShouldSpin = value; OnPropertyChanged(nameof(SpinnerShouldSpin));
            }
        }

        private string showSpinner;
        public string ShowSpinner
        {
            get { return showSpinner; }
            set
            {
                showSpinner = value; OnPropertyChanged(nameof(ShowSpinner));
            }
        }

        private string showResult;
        public string ShowResult
        {
            get { return showResult; }
            set { showResult = value; OnPropertyChanged(nameof(ShowResult));
            }
        }

        public SecureString SecurePassword { private get; set; }
        public string Password { private get; set; }

        private string? _nev;
        public string? Nev
        {
            get { return _nev; }
            set { SetProperty(ref _nev, value);
            }
        }
    }


}

