using System.Collections.Generic;
using System.ServiceModel;

namespace TestTask
{
    [ServiceContract]
    public interface IProcessManager
    {
        [OperationContract]
        List<string> GetProcess(string Login, string Password);
    }
}
