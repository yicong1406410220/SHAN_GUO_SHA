#define Local
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

class SGS
{

    static public Logger Log;

    static void Main(string[] args)
    {
#if Local
        string sqlIp = "49.233.16.171";
        string severUrl = "127.0.0.1";
#else
        string sqlIp = "127.0.0.1";
        string severUrl = "172.21.0.7";
#endif
        //连接数据库
        if (!DbManager.Connect("shan_guo_sha", sqlIp, 3306, "root", ""))
        {
            return;
        }
        //启动服务器
        WebSocketServer wssv = new WebSocketServer("ws://" + severUrl);
        wssv.AddWebSocketService<GameWebSocketBehavior>("/Login");
        wssv.Start();
        wssv.Log.Level = LogLevel.Info;
        Log = wssv.Log;
        WebSocketServiceHost webSocketServiceHost = wssv.WebSocketServices["/Login"];
        NetManager.sessionManager = webSocketServiceHost.Sessions;
        Console.WriteLine("服务器启动");
        while (true)
        {
            OnUpdate();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }
        wssv.Stop();
    }

    static void OnUpdate()
    {

    }
}
