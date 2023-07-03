using Depark.ViewModels;
using System.Windows.Controls;

namespace Depark.Views
{
    /// <summary>
    /// Interaction logic for AddCompanyView.xaml
    /// </summary>
    public partial class AddCompanyView : UserControl
    {
        public AddCompanyView(MainViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}