using ApiClient.Repositories;
using CommunityToolkit.Mvvm.Input;
using ItBolt.Model.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ItBolt.WPF.Commands;
using System;
using System.Windows;
using System.Linq;

namespace ItBolt.WPF.ViewModels
{
    public class EszkozKimutatasViewModel : PagerViewModel, IEditCommands<Eszkoz>
    {
        private IPagerRepository<Eszkoz> _eszkozRepo;

        private ObservableCollection<Eszkoz> _eszkozok = new();
        public ObservableCollection<Eszkoz> Eszkozok
        {
            get { return _eszkozok; }
            set {
                
                SetProperty(ref _eszkozok, value); }
        }


        private ObservableCollection<Eszkoz> SelectedEszkozok; //collects all the modified
        //private Eszkoz startEszkoz; //If the user clicks on the row, it will be the comparison to the modified one

        private Eszkoz _selectedEszkoz = new();
        public Eszkoz SelectedEszkoz
        {
            get { 
                
                return _selectedEszkoz; }
            set
            {
                SetProperty(ref _selectedEszkoz, value);
                //TODO: jobb megoldás?
                if (!SelectedEszkozok.Contains(_selectedEszkoz) && _selectedEszkoz != null)
                {
                    SelectedEszkozok.Add(_selectedEszkoz);
                }

                DeleteCmdAsync.NotifyCanExecuteChanged();
            }
        }


        public IRelayCommand NewCmd { get; }
        public IAsyncRelayCommand<Eszkoz> SaveCmdAsync { get; }
        public IAsyncRelayCommand<Eszkoz> DeleteCmdAsync { get; }

        public EszkozKimutatasViewModel(IPagerRepository<Eszkoz> eszkozRepo) //, IGenericRepository<Eszkoz> raktarRepo)
        {
            _eszkozRepo = eszkozRepo;
            NewCmd = new RelayCommand(New);
            SaveCmdAsync = new AsyncRelayCommand<Eszkoz>(eszkoz => SaveAsync(eszkoz));
            DeleteCmdAsync = new AsyncRelayCommand<Eszkoz>(eszkoz => DeleteAsync(eszkoz), CanDelete);
            SelectedEszkozok = new ObservableCollection<Eszkoz>();
            Task.Run(LoadData);
            
        }

        protected override async Task LoadData()
        {
            var eszkozok = await _eszkozRepo.GetAllAsync(page, ItemsPerPage, SearchKey, SortBy, ascending);
            TotalItems = eszkozok.TotalItems;
            Eszkozok = new ObservableCollection<Eszkoz>(eszkozok.Data);

            //var raktarak = await _raktarRepo.GetAllAsync();
            //Raktarak = new ObservableCollection<Raktar>(raktarak); //Raktarak volt

        }

        private void New()
        {
            SelectedEszkoz = new Eszkoz();
        }

        private async Task SaveAsync(Eszkoz eszkozok)
        {
            foreach (var eszkoz in SelectedEszkozok)
            {
                if (eszkoz.eszkozID > 0)
                {
                    bool exists = await _eszkozRepo.ExistsByIdAsync(eszkoz.eszkozID);

                    if (exists)
                    {
                        await _eszkozRepo.UpdateAsync(eszkoz.eszkozID, eszkoz);
                    }
                }

                //if (eszkoz.eszkozID > 0)
                //{
                //    bool exists = await _eszkozRepo.ExistsByIdAsync(eszkoz.eszkozID);

                //    if (exists)
                //    {
                //        await _eszkozRepo.UpdateAsync(eszkoz.eszkozID, eszkoz);
                //    }
                //}
                //else
                //{
                //    await _eszkozRepo.InsertAsync(eszkoz);
                //    Eszkozok.Insert(0, eszkoz);
                //}
            }
        }

        private bool CanDelete(Eszkoz eszkoz)
        {
            if (eszkoz != null)
            {
                return eszkoz.eszkozID > 0;
            }
            return false;
        }

        private async Task DeleteAsync(Eszkoz eszkoz)
        {
            if (MessageBox.Show("Törlés", "Biztos benne?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                await _eszkozRepo.DeleteAsync(eszkoz.eszkozID);
                Eszkozok.Remove(eszkoz);
            }
        }
    }
}