// using UnityEngine;
// using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json;

public class ChatData
{
    public string id;
    public string msg;
};

public class SocketIOScript : MonoBehaviour
{
    public string serverURL = "http://13.125.163.183:3000";

    protected Socket socket = null;
    protected string soundmeter = "";

    void Destroy()
    {
        DoClose();
    }

    // Use this for initialization
    void Start()
    {
        DoOpen();
    }

    void DoOpen()
    {
        if (socket == null)
        {
            socket = IO.Socket(serverURL);
            socket.On(Socket.EVENT_CONNECT, () => {
                lock (soundmeter)
                {
                    Console.WriteLine("Socket.IO connected.");
                }
            });
            socket.On("soundmeter", (data) => {
                string str = data.ToString();

                lock (soundmeter)
                {
                    Console.WriteLine(soundmeter); // !!!!!!!!1sound print!!!!!!!!!!!!1
                }
            });
        }
    }

    void DoClose()
    {
        if (socket != null)
        {
            socket.Disconnect();
            socket = null;
        }
    }
}
