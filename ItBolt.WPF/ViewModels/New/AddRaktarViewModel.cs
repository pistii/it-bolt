using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ApiClient.Repositories;
using CommunityToolkit.Mvvm.Input;
using ItBolt.Model.Entities;
using ItBolt.WPF.Commands;

namespace ItBolt.WPF.ViewModels
{
    public class AddRaktarViewModel : PagerViewModel, IEditCommands<Raktar>
    {
        private IPagerRepository<Raktar> _raktarRepo;
        public IAsyncRelayCommand<Raktar> SaveCmdAsync { get; }
        public IAsyncRelayCommand<Raktar> DeleteCmdAsync { get; }
        public IRelayCommand NewCmd { get; }

        //Regex r;
        public AddRaktarViewModel(IPagerRepository<Raktar> raktarRepo)
        {
            _raktarRepo = raktarRepo;

            NewCmd = new RelayCommand(New);
            SaveCmdAsync = new AsyncRelayCommand<Raktar>(raktar => SaveAsync(raktar));
            DeleteCmdAsync = new AsyncRelayCommand<Raktar>(raktar => DeleteAsync(raktar), CanDelete);
            //r = new Regex("^\\d{4}\\-(0?[1-9]|1[012])\\-([12][0-9]|3[01]|0?[1-9])|^\\d{4}\\.(0?[1-9]|1[012])\\.([12][0-9]|3[01]|0?[1-9])");
            ShowUploadResult = "Sikeres feltöltés";
            ShowUploadResultVis = "Hidden";
            Task.Run(LoadData);
        }

        protected override async Task LoadData()
        {
            var raktarak = await _raktarRepo.GetAllAsync();
            Raktarak = new ObservableCollection<Raktar>(raktarak.Data);
        }

        private ObservableCollection<Raktar> _raktar = new();
        public ObservableCollection<Raktar> Raktarak
        {
            get { return _raktar; }
            set { SetProperty(ref _raktar, value); }
        }

        private Raktar _selectedRaktar = new();
        public Raktar SelectedRaktar
        {
            get { return _selectedRaktar; }
            set
            {
                SetProperty(ref _selectedRaktar, value);
                DeleteCmdAsync.NotifyCanExecuteChanged();
            }
        }

        private void New()
        {
            SelectedRaktar = new Raktar();
        }

        private async Task SaveAsync(Raktar raktar)
        {
            var mezo = "";
            //Ha valamelyik mező nincs kitöltve
            if (raktar.raktar_neve == null ||
                raktar.raktar_helye == null)
            {
                mezo += "Hibás mező formátum";

            }

            //Hibaüzenet
            if (!string.IsNullOrEmpty(mezo))
            {
                MessageBox.Show("Kitöltése kötelező", mezo);
                mezo = ""; //Visszaáll üresre a következő ellenőrzés miatt
            }
            else // Az eredménynek a validálásnak megfelelnek, mehet a feltöltés
            {
                try
                {
                    bool exists = await _raktarRepo.ExistsByIdAsync(raktar.raktarID);

                    if (exists)
                    {
                        await _raktarRepo.UpdateAsync(raktar.raktarID, raktar);
                    }
                    else
                    {
                        await _raktarRepo.InsertAsync(raktar);
                        Raktarak.Insert(0, raktar);
                    }

                    ShowUploadResult = "Sikeres feltöltés";
                    ShowUploadResultVis = "Visible";
                } catch (Exception e)
                {
                    ShowUploadResult = "Valami hiba történt...";
                    ShowUploadResultVis = "Visible";
                }
            }
            
            // Bérlési időhöz regex DateOnly tipushoz
            //^\d{ 4}\-(0?[1 - 9] | 1[012])\-([12][0 - 9] | 3[01] | 0?[1 - 9]) | ^\d{ 4}\.(0?[1 - 9] | 1[012])\.([12][0 - 9] | 3[01] | 0?[1 - 9])
        }

        private bool CanDelete(Raktar raktar)
        {
            if (raktar != null)
            {
                return raktar.raktarID > 0;
            }
            return false;
        }

        private async Task DeleteAsync(Raktar raktar)
        {
            await _raktarRepo.DeleteAsync(raktar.raktarID);
            Raktarak.Remove(raktar);
            ShowUploadResultVis = "Hidden";
        }

        private string showUploadResult;
        public string ShowUploadResult
        {
            get { return showUploadResult; }
            set
            {
                SetProperty(ref showUploadResult, value);
            }
        }

        private string showUploadResultVis;
        public string ShowUploadResultVis
        {
            get { return showUploadResultVis; }
            set
            {
                SetProperty(ref showUploadResultVis, value);
            }
        }

    }
}
