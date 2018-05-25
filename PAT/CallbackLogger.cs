using Prism.Logging;
using System;
using System.IO;

namespace PAT
{
  class CallbackLogger : ILoggerFacade
  {
    private readonly StreamWriter _writer = File.AppendText(@"Logs\log.txt");

    public void Log(string pMessage, Category pCategory, Priority pPriority)
    {
      try
      {
        _writer.Write("\r\nLog Entry : ");
        _writer.Write(String.Format("The priority and category are {0}, {1}", pPriority, pCategory));
        _writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            DateTime.Now.ToLongDateString());
        _writer.WriteLine("  :");
        _writer.WriteLine("  :{0}", pMessage);
        _writer.WriteLine("-------------------------------");
      }
      catch (Exception ex)
      {
        throw ex;
      }




    }
  }
}
