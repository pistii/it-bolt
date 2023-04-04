using ApiClient.Repositories;
using CommunityToolkit.Mvvm.Input;
using ItBolt.Model.Entities;
using ItBolt.WPF.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace ItBolt.WPF.ViewModels
{
    public class AddEszkozViewModel : PagerViewModel, IEditCommands<Eszkoz>
    {
        private IPagerRepository<Eszkoz> _eszkozRepo;
        private IGenericRepository<Kategoria> _kategoriaRepo;
        private IGenericRepository<Gyarto> _gyartoRepo;

        public IAsyncRelayCommand<Eszkoz> SaveCmdAsync { get; }
        public IAsyncRelayCommand<Eszkoz> DeleteCmdAsync { get; }
        public IRelayCommand NewCmd { get; }

        public AddEszkozViewModel(IPagerRepository<Eszkoz> eszkozRepo, IGenericRepository<Gyarto> gyartoRepo, IGenericRepository<Kategoria> kategoriaRepo)
        {
            _eszkozRepo = eszkozRepo;
            _gyartoRepo = gyartoRepo;
            _kategoriaRepo = kategoriaRepo;
            
            NewCmd = new RelayCommand(New);
            SaveCmdAsync = new AsyncRelayCommand<Eszkoz>(eszkoz => SaveAsync(eszkoz));
            DeleteCmdAsync = new AsyncRelayCommand<Eszkoz>(eszkoz => DeleteAsync(eszkoz), CanDelete);
            ShowUploadResult = "Sikeres feltöltés";
            ShowUploadResultVis = "Hidden";
            Task.Run(LoadData);
        }

        protected override async Task LoadData()
        {
            var eszkozok = await _eszkozRepo.GetAllAsync(page, ItemsPerPage, SearchKey, SortBy, ascending);
            Eszkozok = new ObservableCollection<Eszkoz>(eszkozok.Data);

            var gyartok = await _gyartoRepo.GetAllAsync();
            Gyartok = new ObservableCollection<Gyarto>(gyartok);

            var kategoriak = await _kategoriaRepo.GetAllAsync();
            Kategoriak = new ObservableCollection<Kategoria>(kategoriak);
        }

        private ObservableCollection<Eszkoz> _eszkozok = new();
        public ObservableCollection<Eszkoz> Eszkozok
        {
            get { return _eszkozok; }
            set { SetProperty(ref _eszkozok, value); }
        }

        private Eszkoz _selectedEszkoz = new();
        public Eszkoz SelectedEszkoz
        {
            get { return _selectedEszkoz; }
            set
            {
                SetProperty(ref _selectedEszkoz, value);
                DeleteCmdAsync.NotifyCanExecuteChanged();
            }
        }

        private ObservableCollection<Kategoria> _kategoriak = new();
        public ObservableCollection<Kategoria> Kategoriak
        {
            get { return _kategoriak; }
            set { SetProperty(ref _kategoriak, value); }
        }


        private ObservableCollection<Gyarto> _gyartok = new();
        public ObservableCollection<Gyarto> Gyartok
        {
            get { return _gyartok; }
            set { SetProperty(ref _gyartok, value); }
        }


        private void New()
        {
            SelectedEszkoz = new Eszkoz();
        }

        private async Task SaveAsync(Eszkoz eszkoz)
        {
            var mezo = "";
            //Ha valamelyik mező nincs kitöltve
            if (eszkoz.eszkoz_neve == null ||
                eszkoz.eszkoz_tipus == null ||
                eszkoz.eszkoz_ara == null ||
                eszkoz.eszkoz_sorozatszama == null ||
                eszkoz.raktar_keszlet == 0)
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
                    bool exists = await _eszkozRepo.ExistsByIdAsync(eszkoz.eszkozID);

                    if (exists)
                    {
                        await _eszkozRepo.UpdateAsync(eszkoz.eszkozID, eszkoz);
                    }
                    else
                    {
                        await _eszkozRepo.InsertAsync(eszkoz);
                        Eszkozok.Insert(0, eszkoz);
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
            await _eszkozRepo.DeleteAsync(eszkoz.eszkozID);
            Eszkozok.Remove(eszkoz);
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
