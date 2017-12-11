using Console.FilesOperators;

namespace Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FolderWatcher watcher = new FolderWatcher();
            watcher.Start();
            System.Console.ReadKey();
            watcher.Stop();
        }
    }
}
