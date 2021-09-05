using System.ServiceModel;
using System.ServiceProcess;

namespace ProcessManagerHost
{
    public partial class ProcessManagerService : ServiceBase
    {
        private ServiceHost _host;

        public ProcessManagerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _host = new ServiceHost(typeof(TestTask.ProcessManager));
            _host.Open();
        }

        protected override void OnStop()
        {
            if (_host != null) _host.Close();
        }
    }
}
