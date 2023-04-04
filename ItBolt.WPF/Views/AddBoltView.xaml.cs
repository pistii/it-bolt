using ItBolt.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace ItBolt.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddBoltView.xaml
    /// </summary>
    public partial class AddBoltView : UserControl
    {
        public AddBoltView()
        {

            InitializeComponent();
            //DataContext = App.Current.Services.GetRequiredService<MainViewModel>();
        }

        private void cbRaktarKereses_Load(object sender, SelectionChangedEventArgs e)
        {

            cbRaktarKereses.SelectedItem = null;
            cbRaktarKereses.Text = "--select--";
            
        }
    }
}
