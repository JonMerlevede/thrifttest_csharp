using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var socket = new TSocket("localhost", 7911);
                var transport = new TFramedTransport(socket);
                var protocol = new TBinaryProtocol(transport);
                var client = new Tester.Client(protocol);
                transport.Open();
                var test = new TTest {Mekker = "dit is een test\n", NumberOfTimes = 10};
                Console.WriteLine(client.makeString(test));
                transport.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Pres key to exit.");
            Console.ReadKey();
        }
    }
}
