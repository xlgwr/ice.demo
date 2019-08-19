using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ice;

namespace ice.server
{
    public class PrinterI : Demo.PrinterDisp_
    {
        public override void printString(string s, Current current = null)
        {
            //throw new NotImplementedException();
            Console.WriteLine(s);
        }
    }
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                using (Ice.Communicator communicator = Ice.Util.initialize(ref args))
                {
                    var adapter =
                        communicator.createObjectAdapterWithEndpoints("SimplePrinterAdapter",
                        "default -h localhost -p 10000");
                    adapter.add(new PrinterI(), Ice.Util.stringToIdentity("SimplePrinter"));
                    adapter.activate();
                    communicator.waitForShutdown();

                }

            }
            catch (System.Exception ex)
            {
                Console.Error.WriteLine(ex);
                return 1;
            }
            return 0;
        }
    }
}
