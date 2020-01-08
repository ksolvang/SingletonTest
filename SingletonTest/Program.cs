using Autofac;
using SingletonTest.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    class Program
    {


        static void Main(string[] args)
        {
            var p = new Program();

            //Sync Singleton:
            //Console.WriteLine(Singleton.Instance.Test());

            //Async singleton:
            //p.AsyncMethod().Wait(); //running async method from a sync method

            //Singleton with Autofac:
            //p.AutofacTest();

        }

        /// <summary>
        /// 
        /// </summary>
        public void AutofacTest()
        {
            var container = CompositionRoot();
            var root = container.Resolve<Application>();
            //root.Run();

            using (var scope1 = container.BeginLifetimeScope())
            {
                for (var i = 0; i < 5; i++)
                {
                    var w1 = scope1.Resolve<ISlowLoad>();
                    using (var scope2 = scope1.BeginLifetimeScope())
                    {
                        var w2 = scope2.Resolve<ISlowLoad>();

                        Console.WriteLine(w1.Test());
                    }
                }
            }

            Console.ReadLine();

        }

        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<SlowLoad>().As<ISlowLoad>(); // singleton: .SingleInstance();
            return builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task AsyncMethod()
        {
            //async singleton
            var singleton = await SingletonAsync.Instance();
            for (var i = 0; i < 10; i++)
            {
                var t = singleton.Test;

                Console.WriteLine(t);
            }
            Console.ReadLine();
        }
    }
}
