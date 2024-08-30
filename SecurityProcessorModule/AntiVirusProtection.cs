using NotifierModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProcessorModule
{    public class AntiVirusProtection : ISecurityProvider
    {
        private static string currentEvent = "AntiVirus";
        public INotifier notifier;
        FileSystemWatcher? watcher;
        public AntiVirusProtection(INotifier notifier)
        {
            this.notifier = notifier;
            

        }
        public void Scan() {
            watcher = new FileSystemWatcher();
            watcher.Path = @"C:\watchFilesProject";
            watcher.Filter = "*.txt";
            watcher.NotifyFilter = NotifyFilters.LastWrite;

            watcher.Changed += OnChanged;
            // Start monitoring
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("File is watched");

        }

        private void OnChanged(object sender, FileSystemEventArgs e) {
            OnSecurityEvent();
        }
        public void OnSecurityEvent() 
        { 
            notifier.Notify(currentEvent);
        }
    }
}
