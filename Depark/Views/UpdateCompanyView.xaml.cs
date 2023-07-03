using Depark.ViewModels;
using System.Windows.Controls;

namespace Depark.Views
{
    /// <summary>
    /// Interaction logic for UpdateCompanyView.xaml
    /// </summary>
    public partial class UpdateCompanyView : UserControl
    {
        public UpdateCompanyView(MainViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}