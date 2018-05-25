using System;
using System.IO;

namespace PATFileUpload
{
  class ReadFileService
  {
    private static ReadFileService _instance = null;

    public static ReadFileService Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ReadFileService();
        }
        return _instance;
       }
    }

    private ReadFileService()
    {
    }

    public string[] ReadFile(string fileName)
    {
      var fileContent = File.ReadAllText(fileName);
      var readData = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
      return readData;
    }
  }
}
