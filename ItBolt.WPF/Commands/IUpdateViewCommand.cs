using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItBolt.WPF.Commands
{
    public interface IUpdateViewCommand
    {
        public IRelayCommand<object> UpdateViewCommand { get; set; }
    }
}
