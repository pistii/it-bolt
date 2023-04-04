using ItBolt.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItBolt.WPF.Views
{
    /// <summary>
    /// Interaction logic for EszkozKimutatasView.xaml
    /// </summary>
    public partial class EszkozKimutatasView : UserControl
    {
        public EszkozKimutatasView()
        {
            InitializeComponent();
        }
        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            DataGridColumn column = e.Column;
            BoltKimutatasViewModel? viewModel = DataContext as BoltKimutatasViewModel;
            if (viewModel is not null)
            {
                viewModel.SortBy = column.SortMemberPath;
                column.SortDirection = viewModel.ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
            }
        }
    }
}
