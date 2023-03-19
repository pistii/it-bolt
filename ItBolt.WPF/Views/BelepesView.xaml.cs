using ItBolt.WPF.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ItBolt.WPF.Views
{
    /// <summary>
    /// Interaction logic for BelepesView.xaml
    /// </summary>
    public partial class BelepesView : UserControl 
    {
        public BelepesView()
        {
            this.InitializeComponent();

            DataContext = App.Current.Services.GetRequiredService<BelepesViewModel>();



        }

        public object ImageAwesome { get; internal set; }
    }
}
