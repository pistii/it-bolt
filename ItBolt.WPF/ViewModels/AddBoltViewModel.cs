using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        public IAsyncRelayCommand<Bolt> SaveCmdAsync { get; }

        public IAsyncRelayCommand<Bolt> DeleteCmdAsync { get; }

        public IRelayCommand NewCmd { get; }




        public AddBoltViewModel(IPagerRepository<Bolt> boltRepo)
        {
            _boltRepo = boltRepo;

            NewCmd = new RelayCommand(New);
            SaveCmdAsync = new AsyncRelayCommand<Bolt>(bolt => SaveAsync(bolt));
            DeleteCmdAsync = new AsyncRelayCommand<Bolt>(bolt => DeleteAsync(bolt), CanDelete);
            Task.Run(LoadData);
        }

        protected override async Task LoadData()
        {
            var boltok = await _boltRepo.GetAllAsync(page, ItemsPerPage, SearchKey, SortBy, ascending);
            Boltok = new ObservableCollection<Bolt>(boltok.Data);



        }

        private ObservableCollection<Bolt> _boltok = new();
        public ObservableCollection<Bolt> Boltok
        {
            get { return _boltok; }
            set { SetProperty(ref _boltok, value); }
        }

        private ObservableCollection<Bolt> _raktarak = new();
        public ObservableCollection<Bolt> Raktarak
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
            if (bolt.boltID > 0)
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
    }
}
