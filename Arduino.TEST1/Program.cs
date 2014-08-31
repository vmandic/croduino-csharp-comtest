using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino.TEST1
{
    class Program
    {
        private static bool _runProgram = true;
        private static string _portName;
        private static SerialPort _port;

        static void Main(string[] args)
        {
            while (_runProgram)
            {
                int portNum = -1;
                Console.Write("Enter a port number (1,2,3,4) or 0 to exit: ");

                if (Int32.TryParse(Console.ReadLine(), out portNum) && (portNum == 1 || portNum == 2 || portNum == 3 || portNum == 4 || portNum == 0))
                {
                    if (portNum == 0)
                    {
                        Console.WriteLine("\n----------------------------------------\n");
                        Console.WriteLine("Exiting app...");
                        _runProgram = false;
                        continue;
                    }
                    else
                    {
                        _portName = "COM" + portNum;
                        Console.WriteLine("\n----------------------------------------\n");

                        Console.WriteLine("Port selected: " + _portName);
                        _port = new SerialPort(_portName);
                        Console.WriteLine("Port created: " + _portName);

                        Console.WriteLine("\n----------------------------------------\n");

                        Console.WriteLine("To turn LED on press 1, to turn off press 2 and 0 to cancel: ");

                        int ledNum = 0;

                        if (Int32.TryParse(Console.ReadLine(), out ledNum) && (ledNum == 1 || ledNum == 2 || ledNum == 0))
                        {
                            if (ledNum == 0)
                            {
                                Console.WriteLine("\nCanceling...\n");
                            }
                            else
                            {
                                Console.WriteLine("\n----------------------------------------\n");

                                if (ledNum == 1)
                                    Console.WriteLine("Sending order to turn on LED...");
                                else
                                    Console.WriteLine("Sending order to turn off LED...");

                                try
                                {
                                    if (!_port.IsOpen)
                                    {
                                        Console.WriteLine("Port opened successfully, sending order...");
                                        _port.Open();
                                        _port.Write(ledNum.ToString());
                                        _port.Close();
                                        Console.WriteLine("Port closed, order sent...");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("\n----------------------------------------\n");
                                    Console.WriteLine("!! AN ERROR OCCURED !!\nERROR DETAILS: " + ex.Message + "\n");
                                }
                            }
                        }

                    }
                }
                else
                    Console.WriteLine("Invalid port number!\n");
            }
        }
    }
}
