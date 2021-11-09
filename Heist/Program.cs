using System;
using System.Threading;
using System.Threading.Tasks;

namespace Heist
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Heist heist1 = new Heist();
            await heist1.EvaluateHeist("Verkehrsministerium");
        }
    }
}