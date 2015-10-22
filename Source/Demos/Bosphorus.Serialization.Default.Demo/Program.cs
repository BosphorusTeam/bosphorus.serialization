using Bosphorus.BootStapper.Runner.Console;
using Bosphorus.Common.Core.Application;
using Bosphorus.Demo.Runner;

namespace Bosphorus.Serialization.Default.Demo
{
    public class Program
    {

        static void Main(string[] args)
        {
            DemoRunner.Run(Environment.Local, Perspective.Debug, args);
        }
    }
}
