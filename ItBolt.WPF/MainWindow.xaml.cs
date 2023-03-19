
using ItBolt.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace ItBolt.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
           
            this.InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<MainViewModel>();

        }


    }
}
