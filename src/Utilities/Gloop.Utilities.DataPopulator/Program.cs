using Gloop.Core;

namespace Gloop.Utilities.DataPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var populator = new ContentPopulator(new ApplicationContext());
            populator.Populate();
        }
    }
}
