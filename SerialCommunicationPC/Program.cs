using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunicationPC {
    class Program {
        private static bool answerReceived = false;

        static void Main(string[] args) {
            List<string> portNames = SerialPort.GetPortNames().ToList();

            Console.WriteLine("Available COM Ports:");
            string portsString = portNames.Aggregate((concat, port) => $"{concat}, {port}");
            Console.WriteLine(portsString);
            Console.WriteLine("Write name of the COM Port to use: ");
            string usedPort = Console.ReadLine();
            if(usedPort == "")
                usedPort = portNames[0];

            SerialPort serialPort = new SerialPort(usedPort, 9600);

            serialPort.DataReceived += SerialPort_DataReceived;

            try {
                serialPort.Open();
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }

            serialPort.WriteLine("Test string.");

            while (true) {
                if (!answerReceived)
                    continue;

                string readString = serialPort.ReadLine();
                Console.WriteLine(readString);
                break;
            }
        }

        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            answerReceived = true;
            //Console.WriteLine("Answered received");
        }
    }
}
