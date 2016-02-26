using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.AppdomainSample
{
    /// This class as a POC providing to call a method with in a isolated appdomain.
    class AppDomainContext : IDisposable
    {
        private AppDomain domain = null;
        public AppDomainContext()
        {
            domain = AppDomain.CreateDomain("AppDomainContext_" + Guid.NewGuid());
        }

        public void Dispose()
        {
            AppDomain.Unload(domain);
        }

        public void Execute(Action action)
        {
            var proxy = (Inner)domain.CreateInstance(
                            typeof(Inner).Assembly.FullName,
                            typeof(Inner).FullName
                           )
                        .Unwrap();
           proxy.Run(action);
        }

        class Inner : MarshalByRefObject
        {
            public void Run(Action action)
            {
                action.Invoke();
            }
        }
    }


    [Serializable]
    class Program
    {
        public string value = "default";

        static void Main(string[] args)
        {
            var p = new Program();
            using (var context = new AppDomainContext())
            {
                // the `execute` parameter's object should be marked as serializable
                context.Execute(p.Dosomething);
            }

            Console.Read();
        }

        void Dosomething()
        {
            value = "ok";
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine(value);
            Action ac = () => { Console.WriteLine("sdfsdf"); };
            ac.Invoke();
        }
    }
}
