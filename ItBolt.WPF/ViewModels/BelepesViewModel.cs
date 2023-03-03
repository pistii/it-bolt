using ApiClient.Repositories;
using CommunityToolkit.Mvvm.Input;
using ItBolt.Model.Entities;
using ItBolt.WPF;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ItBolt.WPF.ViewModels
{
    public class BelepesViewModel
    {
        public BelepesViewModel()
        { }

        private ObservableCollection<Belepes> _belepes = new();

        public ObservableCollection<Belepes> Belepes
        {
            get { return _belepes; }
            set
            { //SetProperty(ref _belepes, value); }
            }
        }

    }
}
