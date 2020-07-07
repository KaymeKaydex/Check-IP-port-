using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ip_parser
{
    class Program
    {
        static void Main(string[] args)
        {
           

            ConsoleStyle style = new ConsoleStyle();

            style.StyleChanger("creator");
            Console.WriteLine("Hello, this is my IP range checker \n Please, write your ip-range :");
            style.StyleChanger("");
            string ip_range = Console.ReadLine();


            style.StyleChanger("creator");
            Console.WriteLine("Write your your treads: ");
            style.StyleChanger("");
            Ip_Object.trheadsCount = Convert.ToInt32(Console.ReadLine());



            style.StyleChanger("creator");
            Console.WriteLine("Write your port and we'll start : ");
            style.StyleChanger("");
            int port = Convert.ToInt32(Console.ReadLine());
            style.StyleChanger("creator");

            Console.WriteLine("Put key S to stop or ESC to exit");
            style.StyleChanger("");
            Console.WriteLine("We started!");
            style.StyleChanger("creator");
            string[] ind = ip_range.Split('-').ToArray();
            Ip_Object ip = new Ip_Object(ind[0], ind[1], port);



            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                key = Console.ReadKey();
                Console.WriteLine("- is not Comand Key \n Put key ESC to exit");
                
            }
            while (key.Key != ConsoleKey.Escape);
        }
    }
}
