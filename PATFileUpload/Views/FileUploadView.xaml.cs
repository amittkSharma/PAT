using System.Windows.Controls;

namespace PATFileUpload.Views
{
  /// <summary>
  /// Interaction logic for FileUploadView.xaml
  /// </summary>
  public partial class FileUploadView : UserControl
  {
    public FileUploadView(IFileUploadViewModel viewModel)
    {
      InitializeComponent();

      this.DataContext = viewModel;
    }
  }
}
