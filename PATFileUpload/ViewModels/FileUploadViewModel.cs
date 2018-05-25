using Microsoft.Practices.Unity;
using PATCommon;
using System.Windows.Forms;
using System.Windows.Input;

namespace PATFileUpload
{
  public class FileUploadViewModel : ViewModelBase, IFileUploadViewModel
  {

    IUnityContainer container;
    private IPATRepository _repository;

    public FileUploadViewModel(IUnityContainer unityContainer)
    {
      container = unityContainer;
      _repository = container.Resolve<IPATRepository>();
    }

    public string FilePath
    {
      get { return _filePath; }
      set
      {
        _filePath = value;
        OnPropertyChanged("FilePath");
      }
    }
    private string _filePath = "";

    public ICommand UploadCommand
    {
      get
      {
        return new RelayCommand(param => BrowseDirectoryStructure(), param => true);
      }
    }

    private void BrowseDirectoryStructure()
    {
      var dialog = new OpenFileDialog();

      dialog.DefaultExt = ".csv";
      dialog.Filter = "CSV Files (*.csv)|*.csv";

      var result = dialog.ShowDialog();
      FilePath = result == DialogResult.OK ? dialog.FileName : string.Empty;

      if (result == DialogResult.OK)
      {
        _repository.DepthDataPoints = ReadFileService.Instance.ReadFile(FilePath);
      }
    }
  }
}
