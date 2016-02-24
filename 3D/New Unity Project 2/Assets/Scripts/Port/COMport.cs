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
                    Send("1");
                    var tes = (char)sport.ReadChar();

                    if (tes != '\n')
                        ReceivedTemp += tes.ToString();
                    else
                    {
                        sport_DataReceived(ReceivedTemp, null);
                        ReceivedTemp = "";
                        sport.DiscardInBuffer();
                        sport.DiscardOutBuffer();
                    }
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
        sport = new SerialPort(port, baudrate, parity, databits, stopbits);
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
        string input = (string)sender;//sport.ReadExisting();
        setLog("Received: " + input);

        DataReceived(input);

        string[] data = input.Split(':');
        switch (data[0])
        {
            case "L0": Light[0] = double.Parse(data[1]); break;
            case "L1": Light[1] = double.Parse(data[1]); break;
            case "L2": Light[2] = double.Parse(data[1]); break;
            case "L3": Light[3] = double.Parse(data[1]); break;
            case "L4": Light[4] = double.Parse(data[1]); break;

            case "S0": ServoAngleTemp[0] = double.Parse(data[1]); ServoCount++; break;
            case "S1": ServoAngleTemp[1] = double.Parse(data[1]); ServoCount++; break;
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

