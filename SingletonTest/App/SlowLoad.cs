using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonTest.App
{
    internal sealed class SlowLoad : ISlowLoad
    {

        public SlowLoad()
        {
            Thread.Sleep(5000);
        }

        public string Test()
        {
            return "Slow Load!";
        }


    }
}
