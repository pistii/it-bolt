using ApiClient.Repositories;
using CommunityToolkit.Mvvm.Input;
using ItBolt.WPF.ViewModels;
using ItBolt.Model.Entities;
using ItBolt.WPF;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ItBolt.WPF.Commands;
using System.Windows.Documents;
using System;
using System.Globalization;
using System.Windows;

namespace ItBolt.WPF.ViewModels
{
    public class RaktarKimutatasViewModel : PagerViewModel, IEditCommands<Raktar>
    {
        private IPagerRepository<Raktar> _raktarRepo;

        private ObservableCollection<Raktar> _raktarak = new();
        public ObservableCollection<Raktar> Raktarak
        {
            get { return _raktarak; }
            set { SetProperty(ref _raktarak, value); }
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

        public IRelayCommand NewCmd { get; }
        public IAsyncRelayCommand<Raktar> SaveCmdAsync { get; }
        public IAsyncRelayCommand<Raktar> DeleteCmdAsync { get; }

        public RaktarKimutatasViewModel(IPagerRepository<Raktar> raktarRepo)
        {
            _raktarRepo = raktarRepo;
            NewCmd = new RelayCommand(New);
            SaveCmdAsync = new AsyncRelayCommand<Raktar>(raktar => SaveAsync(raktar));
            DeleteCmdAsync = new AsyncRelayCommand<Raktar>(raktar => DeleteAsync(raktar), CanDelete);

            Task.Run(LoadData);
        }

        protected override async Task LoadData()
        {
            var raktarak = await _raktarRepo.GetAllAsync(page, ItemsPerPage, SearchKey, SortBy, ascending);
            TotalItems = raktarak.TotalItems;
            Raktarak = new ObservableCollection<Raktar>(raktarak.Data);
            //var raktarak = await _raktarRepo.GetAllAsync();
            //Raktarak = new ObservableCollection<Raktar>(raktarak); //Raktarak volt

        }

        private void New()
        {
            SelectedRaktar = new Raktar();
        }

        private async Task SaveAsync(Raktar raktar)
        {
            if (raktar.raktarID > 0)
            {
                bool exists = await _raktarRepo.ExistsByIdAsync(raktar.raktarID);

                if (exists)
                {

                    await _raktarRepo.UpdateAsync(raktar.raktarID, raktar);
                }
            }
            else
            {
                await _raktarRepo.InsertAsync(raktar);
                Raktarak.Insert(0, raktar);
            }
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
            if (MessageBox.Show("Törlés", "Biztos benne?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                await _raktarRepo.DeleteAsync(raktar.raktarID);
                Raktarak.Remove(raktar);
            }
        }
    }
}