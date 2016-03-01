using Bosphorus.Assemble.BootStrapper.Runner.Demo;
using Bosphorus.Common.Application;

namespace Bosphorus.Serialization.Default.Demo
{
    public class Program
    {

        static void Main(string[] args)
        {
            DemoRunner.Run(Environment.Local, Perspective.Debug, typeof(IDemoInstaller));
        }
    }
}
