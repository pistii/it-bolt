using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        public AddRaktarViewModel(IPagerRepository<Raktar> raktarRepo)
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
        }
    }
}
