using System.IO;
using System.Threading.Tasks;
using PL.Interfaces;
using PL.Models;
using PL.ServicesPL;

namespace Service.FileOperatorsSrv
{
    public class FolderWatcher
    {
        readonly FileSystemWatcher watcher;
        readonly TaskFactory taskFactory;

        public FolderWatcher()
        {
            watcher = new FileSystemWatcher("D:\\temp", "*csv");
            watcher.Created += OnCreated;
            taskFactory = new TaskFactory();
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            taskFactory.StartNew(() => ReadFile(e));
        }

        private static void SendSale(FileSystemEventArgs e, IManagerServicePL bridge)
        {
            string filePath = e.FullPath;
            FileParser parser = new FileParser();
            foreach (var item in parser.ParseCsv(filePath))
            {
                bridge.SendSaleInfo(item);
            }
            System.Console.WriteLine("Success");
            bridge.Dispose();
        }

        private static void ReadFile(FileSystemEventArgs e)
        {
            ManagerServicePL servicePl = new ManagerServicePL();
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(e.FullPath);
            if (fileNameWithoutExtension == null) return;
            string[] tmp = fileNameWithoutExtension.Split('_');

            if (servicePl.CheckManager(tmp[0]))
            {
                SendSale(e, servicePl);
            }
            else
            {
                servicePl.SendManagerInfo(new ManagerModel(tmp[0]));
                SendSale(e, servicePl);
            }
        }
    }
}