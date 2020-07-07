
using System;

namespace Ip_parser
{
    class ConsoleStyle
    {
        public void StyleChanger(string type)
        {
            if(type == "creator")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

    }
}
