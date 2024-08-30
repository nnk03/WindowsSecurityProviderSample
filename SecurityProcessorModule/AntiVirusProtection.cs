using NotifierModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProcessorModule
{    public class AntiVirusProtection : ISecurityProvider
    {
        private readonly string _currentEvent = "AntiVirus";
        public INotifier notifier;
        FileSystemWatcher? _watcher;
        public AntiVirusProtection(INotifier notifier)
        {
            this.notifier = notifier;
            

        }
        public void Scan() {
            _watcher = new()
            {
                Path = @"C:\watchFilesProject" ,
                Filter = "*.txt" ,
                NotifyFilter = NotifyFilters.LastWrite
            };

            _watcher.Changed += OnChanged;
            // Start monitoring
            _watcher.EnableRaisingEvents = true;
            Console.WriteLine("File is watched");

        }

        private void OnChanged(object sender, FileSystemEventArgs e) {
            OnSecurityEvent();
        }
        public void OnSecurityEvent() 
        { 
            notifier.Notify(_currentEvent);
        }
    }
}
