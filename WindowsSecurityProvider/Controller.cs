using NotifierModule;
using SecurityProcessorModule;

namespace Processing
{
    public class Controller : INotifier
    {
        public List<ISecurityProvider> _securityProviders = new();
        public Controller()
        {
            //string? selectedEnvironment = Console.ReadLine();
            string selectedEnvironment = "org";

            if(selectedEnvironment == "home")
            {
                // do something

            }
            else if (selectedEnvironment == "org")
            {
                _securityProviders.Add(new AntiVirusProtection(this));
            }
            else
            {
                Console.WriteLine("Unknown Environment");
            }


            foreach (ISecurityProvider provider in _securityProviders)
            {
                provider.Scan();
            }

            while (true)
            {

            }

        }
        public void Notify(string e) {
            Console.WriteLine("Some Event Happend");
            Console.WriteLine(e);
        }
    }
}
