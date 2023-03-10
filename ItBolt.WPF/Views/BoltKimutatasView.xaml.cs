using ItBolt.WPF.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;


namespace ItBolt.WPF.Views
{
    /// <summary>
    /// Interaction logic for BoltKimutatasView.xaml
    /// </summary>
    public partial class BoltKimutatasView : UserControl
    {
        public BoltKimutatasView()
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
