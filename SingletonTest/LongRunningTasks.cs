using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    internal sealed class LongRunningTasks
    {
        public async Task<string> FiveSecondsAsync()
        {
            await Task.Delay(5000);
            return "blah";
        }
    }
}
