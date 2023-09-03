using ApiClient.Entities;
using CommunityToolkit.Mvvm.Input;
using ItBolt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ItBolt.WPF.Commands
{
    public interface ILoginCommands<T>
    {

        IAsyncRelayCommand<Felhasznalo> BelepesCmd { get; }

    }
}
