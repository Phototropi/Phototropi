using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

class COMport
{
    public static List<string> Log = new List<string>();
    public static SerialPort sport;
    public delegate void Received(string data);
    public static event Received DataReceived;

    private static double[] ServoAngle = new double[2];
    private static double[] ServoAngleTemp = new double[2];
    private static double[] Light = new double[5];
    private static string info = "";
    private static string ReceivedTemp = "";
    private static Int16 ServoCount = 0;
    private static bool Ask = true;

    public string[] getLog()
    {
        return Log.ToArray();
    }

    public static string getLastLog(int numberOfLogs)
    {
        string temp = "";
        if (Log.Count > 0)
            for (int i = 0; i < (int)((Log.Count() > numberOfLogs) ? (numberOfLogs) : (Log.Count())); i++)
            {
                temp += Log[Log.Count() - i - 1];
            }
        return temp;
    }

    private static void setLog(string info)
    {
        Log.Add(DateTime.Now.ToShortTimeString() + ": " + info + Environment.NewLine);
        if (Log.Count() > 10000)
        {
            Log.RemoveAt(0);
        }
    }

    public static string[] getPortNames()
    {
        setLog("getPorts:");
        List<string> ports = new List<string>();
        foreach (String portName in SerialPort.GetPortNames())
        {
            ports.Add(portName);
            setLog(portName);
        }
        return ports.ToArray();
    }

    public static void Connect(String port)
    {
        try
        {
            setLog("Connect to: " + port);
            serialport_connect(port, 9600, Parity.None, 8, StopBits.One);
        }
        catch (Exception ex)
        {
            setLog(ex.Message);
            throw;
        }
    }

    public static bool Disconnect()
    {
        setLog("Disconnect");
        if (sport.IsOpen)
        {
            sport.Close();
            setLog("Port is Closed");
            return true;
        }
        setLog("Port was Closed");
        return false;
    }


    public static bool isConnected()
    {
        if (sport != null)
            if (sport.IsOpen)
                return true;
        return false;
    }


    public static void ReceiveData()
    {

        try
        {
            if (sport != null)
            {
                if (sport.IsOpen)
                {
                    //Wait till block begins
                    char input = ' ';
                    do
                    {
                        try
                        {
                            input = (char)sport.ReadChar();
                        }

                        catch (Exception) { }
                    } while (input != '{');
                    input = (char)sport.ReadChar(); // new line

                    //read lines till block end and get information of Servo and lights
                    while (input != '}')
                    {
                        string ReceivedData = "";
                        do
                        {
                            input = (char)sport.ReadChar();
                            ReceivedData += input;
                        }
                        while (input != '\n');
                        sport_DataReceived(ReceivedData, null);
                    }
                    //Old receive function, works with Test Code, but it has problems with finished robot.
                    //{
                    ////if (Ask)
                    ////    Send("1");


                    ////int temp = sport.ReadByte();
                    ////var tes = Convert.ToChar(temp);
                    //if (tes == '\0')
                    //    Ask = false;

                    //if (tes != '\n')
                    //    ReceivedTemp += tes.ToString();
                    //else
                    //{
                    //    sport_DataReceived(ReceivedTemp, null);
                    //    while ()
                    //    { }
                    //    //Ask = true;
                    //    ReceivedTemp = "";
                    //}
                    //}
                }
            }
        }
        catch (TimeoutException)
        { }
        catch (Exception)
        {
            throw;
        }

    }

    public static void Send(string data)
    {
        setLog("Send: " + data);
        sport.Write(data);
    }

    private static void serialport_connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
    {
        sport = new SerialPort("\\\\.\\" + port, baudrate, parity, databits, stopbits);
        try
        {

            sport.ReadTimeout = 1000;
            sport.WriteTimeout = 1000;
            sport.Open();

        }
        catch (Exception ex)
        {
            setLog(ex.Message);
            throw;
        }
    }

    public static void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string input = (string)sender;
        setLog("Received: " + input);

        DataReceived(input);

        string[] data = input.Split(':');
        switch (data[0])
        {
            case "L1": Light[0] = double.Parse(data[1]); break;
            case "L2": Light[1] = double.Parse(data[1]); break;
            case "L3": Light[2] = double.Parse(data[1]); break;
            case "L4": Light[3] = double.Parse(data[1]); break;
            case "L5": Light[4] = double.Parse(data[1]); break;

            case "S1": ServoAngleTemp[0] = double.Parse(data[1]); ServoCount++; break;
            case "S0": ServoAngleTemp[1] = -double.Parse(data[1]); ServoCount++; break;
            default: info = input; break;
        }
    }

    public static double getServoAngle(int ID)
    {
        if (ServoCount > 1)
        {
            ServoAngleTemp.CopyTo(ServoAngle, 0);
            ServoCount = 0;
        }
        return ServoAngle[ID];
    }

    public static double getLight(int ID)
    {
        return Light[ID];
    }

    public static string getInfo()
    {
        return info;
    }

}

