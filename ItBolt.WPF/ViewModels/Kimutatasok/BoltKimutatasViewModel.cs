﻿using ApiClient.Repositories;
using CommunityToolkit.Mvvm.Input;
using ItBolt.WPF.ViewModels;
using ItBolt.Model.Entities;
using ItBolt.WPF;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ItBolt.WPF.Commands;
using System.Windows.Documents;
using System.Windows;

namespace ItBolt.WPF.ViewModels
{
    public class BoltKimutatasViewModel : PagerViewModel, IEditCommands<Bolt>
    {
        private IPagerRepository<Bolt> _boltRepo;
        private IGenericRepository<Raktar> _raktarRepo;

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

        private ObservableCollection<Bolt> SelectedBoltok = new();

        private Bolt _selectedBolt = new();
        public Bolt SelectedBolt
        {
            get { return _selectedBolt; }
            set
            {
                SetProperty(ref _selectedBolt, value);
                if (!SelectedBoltok.Contains(_selectedBolt) && _selectedBolt != null)
                {
                    SelectedBoltok.Add(_selectedBolt);
                }
                DeleteCmdAsync.NotifyCanExecuteChanged();
            }
        }

        public IRelayCommand NewCmd { get; }
        public IAsyncRelayCommand<Bolt> SaveCmdAsync { get; }
        public IAsyncRelayCommand<Bolt> DeleteCmdAsync { get; }

        public BoltKimutatasViewModel(IPagerRepository<Bolt> boltRepo, IGenericRepository<Raktar> raktarRepo)
        {
            _boltRepo = boltRepo;
            _raktarRepo = raktarRepo;
            NewCmd = new RelayCommand(New);
            SaveCmdAsync = new AsyncRelayCommand<Bolt>(bolt => SaveAsync(bolt));
            DeleteCmdAsync = new AsyncRelayCommand<Bolt>(bolt => DeleteAsync(bolt), CanDelete);

            Task.Run(LoadData);
        }

        public BoltKimutatasViewModel()
        {
        }

        protected override async Task LoadData()
        {
            var boltok = await _boltRepo.GetAllAsync(page, ItemsPerPage, SearchKey, SortBy, ascending);
            TotalItems = boltok.TotalItems;
            Boltok = new ObservableCollection<Bolt>(boltok.Data);
            //var raktarak = await _raktarRepo.GetAllAsync();
            //Raktarak = new ObservableCollection<Raktar>(raktarak); //Raktarak volt

        }

        private void New()
        {
            SelectedBolt = new Bolt();
        }

        public async Task SaveAsync(Bolt boltok)
        {
            foreach (var bolt in SelectedBoltok)
            {
                if (bolt.boltID > 0)
                {
                    bool exists = await _boltRepo.ExistsByIdAsync(bolt.boltID);

                    if (exists)
                    {
                        await _boltRepo.UpdateAsync(bolt.boltID, bolt);
                    }
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
                return bolt.boltID > 0;
            }
            return false;
        }

        private async Task DeleteAsync(Bolt bolt)
        {
            if (MessageBox.Show("Törlés", "Biztos benne?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                await _boltRepo.DeleteAsync(bolt.boltID);
                Boltok.Remove(bolt);
            }
        }
    }
}