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


        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }

        public object ImageAwesome { get; internal set; }
    }
}
