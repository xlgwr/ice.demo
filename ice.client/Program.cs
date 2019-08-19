using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ice.client
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                using (Ice.Communicator communicator = Ice.Util.initialize(ref args))
                {
                    var obj = communicator.stringToProxy("SimplePrinter:default -h localhost -p 10000");
                    var printer = Demo.PrinterPrxHelper.checkedCast(obj);
                    if (printer == null)
                    {
                        throw new ApplicationException("Invalid proxy");
                    }
                    printer.printString("Hello World!" + DateTime.Now.ToString());

                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return 1;
            }
            return 0;
        }
    }
}
