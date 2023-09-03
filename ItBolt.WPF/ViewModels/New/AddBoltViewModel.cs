using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ApiClient.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ItBolt.Model.Entities;
using ItBolt.WPF.Commands;

namespace ItBolt.WPF.ViewModels
{
    public class AddBoltViewModel : PagerViewModel, IEditCommands<Bolt>
    {
        private IPagerRepository<Bolt> _boltRepo;
        private IGenericRepository<Raktar> _raktarRepo;

        public IAsyncRelayCommand<Bolt> SaveCmdAsync { get; }

        public IAsyncRelayCommand<Bolt> DeleteCmdAsync { get; }

        public IRelayCommand NewCmd { get; }

        public AddBoltViewModel(IPagerRepository<Bolt> boltRepo, IGenericRepository<Raktar> raktarRepo)
        {
            _boltRepo = boltRepo;
            _raktarRepo = raktarRepo;

            NewCmd = new RelayCommand(New);
            SaveCmdAsync = new AsyncRelayCommand<Bolt>(bolt => SaveAsync(bolt));
            DeleteCmdAsync = new AsyncRelayCommand<Bolt>(bolt => DeleteAsync(bolt), CanDelete);
            ShowUploadResult = "Sikeres feltöltés";
            ShowUploadResultVis = "Hidden";

            Task.Run(LoadData);
        }

        protected override async Task LoadData()
        {
            var boltok = await _boltRepo.GetAllAsync(page, ItemsPerPage, SearchKey, SortBy, ascending);

            var raktarak = await _raktarRepo.GetAllAsync();
            Raktarak = new ObservableCollection<Raktar>(raktarak);

            Boltok = new ObservableCollection<Bolt>(boltok.Data);


        }

        private ObservableCollection<Bolt> _boltok = new();
        public ObservableCollection<Bolt> Boltok
        {
            get { return _boltok; }
            set { SetProperty(ref _boltok, value); }
        }

        private ObservableCollection<Raktar> _raktarak = new();
        public ObservableCollection<Raktar> Raktarak
        {
            get { return _raktarak; }
            set { SetProperty(ref _raktarak, value); }
        }


        private Bolt _selectedBolt = new();
        public Bolt SelectedBolt
        {
            get { return _selectedBolt; }
            set
            {
                SetProperty(ref _selectedBolt, value);
                DeleteCmdAsync.NotifyCanExecuteChanged();
            }
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
            SelectedBolt = new Bolt();
        }

        private async Task SaveAsync(Bolt bolt)
        {
            var mezo = "";
            

            //Ha valamelyik mező nincs kitöltve
            if (bolt.bolt_neve == null ||
                bolt.bolt_cime == null)
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
                    bool exists = await _boltRepo.ExistsByIdAsync(bolt.boltID);

                    if (exists)
                    {
                        await _boltRepo.UpdateAsync(bolt.boltID, bolt);
                    }
                    else
                    {
                        await _boltRepo.InsertAsync(bolt);
                        Boltok.Insert(0, bolt);
                    }

                    ShowUploadResult = "Sikeres feltöltés";
                    ShowUploadResultVis = "Visible";
                } 
                catch (Exception e)
                {
                    ShowUploadResult = "Valami hiba történt...";
                    ShowUploadResultVis = "Visible";
                } 
            }
        }

        private bool CanDelete(Bolt bolt)
        {
            if (bolt != null)
            {
                return bolt.boltID != null;
            }
            return false;
        }

        private async Task DeleteAsync(Bolt bolt)
        {
            await _boltRepo.DeleteAsync(bolt.boltID);
            Boltok.Remove(bolt);
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
