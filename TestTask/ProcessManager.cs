using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.ServiceModel;

namespace TestTask
{
    public class ProcessManager : IProcessManager
    {
        public List<string> GetProcess(string Login, string Password)
        {
            List<string> listProcessName = new List<string>();

            if (IsValidUser(Login, Password))
            //or
            //if(ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated)
            {
                try
                {
                    Process[] arrProcess = Process.GetProcesses();
                    foreach (var p in arrProcess)
                        listProcessName.Add(p.ProcessName);
                }
                catch (System.Exception ex)
                {
                    listProcessName.Add(ex.Message);
                }
            }
            else
            {
                listProcessName.Add("Wrong UserName or Password");
            }

            return listProcessName;
        }

        private bool IsValidUser(string Login, string Password)
        {
            PrincipalContext context = new PrincipalContext(ContextType.Machine);
            return context.ValidateCredentials(Login, Password);
        }
    }
}
