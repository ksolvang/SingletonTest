using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    internal sealed class SingletonAsync
    {
        private static string _test;
        private SingletonAsync()
        {
        }

        private static readonly Lazy<SingletonAsync>
        lazy = new Lazy<SingletonAsync>(() => new SingletonAsync());

        public static async Task<SingletonAsync> Instance()
        {
            var lrt = new LongRunningTasks();
            _test = await lrt.FiveSecondsAsync();
            return lazy.Value;
        }

        public string Test => _test;
    }
}
