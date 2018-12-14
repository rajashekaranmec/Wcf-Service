using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.HelloServiceClient client = new ServiceReference1.HelloServiceClient();
            client.Open();
            Console.WriteLine("Enter your Good Name");
            string name = Console.ReadLine().ToString();
            Console.WriteLine(client.TodayProgram(name));
            client.Close();
            Console.Read();

        }
    }
}
