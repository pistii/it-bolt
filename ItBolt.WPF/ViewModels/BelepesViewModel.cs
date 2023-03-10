using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ItBolt.Model.Entities;
using ItBolt.WPF.Commands;

namespace ItBolt.WPF.ViewModels
{
    public class BelepesViewModel : ObservableObject
    {

        private ObservableCollection<Felhasznalo> _belepes = new();
        public ObservableCollection<Felhasznalo> Belepes
        {
            get { return _belepes; }
            set { SetProperty(ref _belepes, value); }
        }


    }
}
