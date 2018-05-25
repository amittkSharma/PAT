using System.Windows.Controls;

namespace PATFileUpload.Views
{
  /// <summary>
  /// Interaction logic for DisplayComputationsView.xaml
  /// </summary>
  public partial class DisplayComputationsView : UserControl
  {
    public DisplayComputationsView(IDisplayComputationalViewModel viewModel)
    {
      InitializeComponent();

      this.DataContext = viewModel;
    }
  }
}
