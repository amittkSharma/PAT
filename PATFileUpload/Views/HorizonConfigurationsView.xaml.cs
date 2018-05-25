using System.Windows.Controls;

namespace PATFileUpload.Views
{
  /// <summary>
  /// Interaction logic for HorizonConfigurationsView.xaml
  /// </summary>
  public partial class HorizonConfigurationsView : UserControl
  {
    public HorizonConfigurationsView(IHorizonConfigurationsViewModel viewModel)
    {
      InitializeComponent();

      this.DataContext = viewModel;
    }
  }
}
