using System.ServiceProcess;
using System.Threading;
using Service.FileOperatorsSrv;

namespace Service
{
    public partial class Service1 : ServiceBase
    {
        private FolderWatcher watcher;

        public Service1()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
        }

        protected override void OnStart(string[] args)
        {
            watcher = new FolderWatcher();
            Thread watcherTread = new Thread(new ThreadStart(watcher.Start));
            watcherTread.Start();
        }

        protected override void OnStop()
        {
            watcher.Stop();
        }
    }
}
