using System.Windows.Controls;
using FTree.Presenter;

namespace FTree.View.Win32
{
    public partial class VisualFamilyTreeView : UserControl
    {
        public VisualFamilyTreeView()
        {
            InitializeComponent();

            //Region[] regions = Database.GetRegions();
            //CountryViewModel viewModel = new CountryViewModel(regions);
            //base.DataContext = viewModel;
        }
    }
}