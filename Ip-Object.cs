using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Ip_parser
{
    class Ip_Object
    {
        private byte[] startIP { get; set; }
        private byte[] endIP { get; set; }
        private int port { get; set; }
        static private int threadsIsUsed { get; set; } = 0;
        
        internal static int trheadsCount;

        static List<string> Good = new List<string>();
        ConsoleStyle cs = new ConsoleStyle();
        public Ip_Object(string start, string end, int port)
        {
            startIP = stringToIp(start);
            endIP = stringToIp(end);
            this.port = port;

            rangeChecker(startIP, endIP);
            
        }
        static byte[] stringToIp(string temp)
        {
            byte[] answer = new byte[4];
            string[] ipSpliter = temp.Split('.').ToArray();
            for(int i = 0; i < 4; i++)
            {
                answer[i] = Convert.ToByte(ipSpliter[i]);
            }
            return answer;
        }

        async void rangeChecker(byte[] startIP, byte[] endIP)
        {

            await (Task.Run(() =>
            {
                int count = 0;
                while (startIP[0] != endIP[0] || startIP[1] != endIP[1] || startIP[2] != endIP[2] || startIP[3] != endIP[3])
                {
                    if (startIP[3] != 255) startIP[3]++;
                    else
                    {
                        if (startIP[2] != 255) startIP[2]++;
                        else
                        {
                            if (startIP[1] != 255) startIP[1]++;
                            else
                            {
                                if (startIP[0] != 255) startIP[2]++; else break;
                                startIP[1] = 0;
                            }
                            startIP[2] = 0;
                        }
                        startIP[3] = 0;
                    }
                    string current = (startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + startIP[3]);
                    Console.WriteLine(startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + startIP[3]);
                    while (threadsIsUsed == trheadsCount) { };
                    threadsIsUsed++;
                    Thread myThread = new Thread(
                        ()=>
                        {
                            CheckPortConection(current, this.port);
                        }
                        );
                   
                    myThread.Start();
                    count++;
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(" /n         Creating txt file ...      /n    ");
                File.WriteAllLines("good.txt", Good);
                cs.StyleChanger("creator");
                Console.WriteLine("Checked IPs : " + count);
                //Создадим текстовый документ
                

            }));

        }
        public static void CheckPortConection(string currentIP, int port)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(currentIP, port);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(currentIP+":"+port + " Port open");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Good.Add(currentIP);

                }
                catch (Exception)
                {
                    Console.WriteLine(currentIP + ":" + port + " Port closed");
                }
                
            }
            threadsIsUsed--;
        }

    }

}
