using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;


class NetManager
{
    public static WebSocketSessionManager sessionManager = null;
    public static void Close(string ID)
    {
        if (sessionManager.IDs.Contains(ID))
        {
            sessionManager[ID].Context.WebSocket.Close();
        }
    }

    public static void Send(string ID, ProtocolBase obj)
    {
        string msg = Utils.Js.Serialize(obj);
        if (sessionManager.IDs.Contains(ID))
        {
            Console.WriteLine("Send " + ID + ":" + msg);
            sessionManager[ID].Context.WebSocket.Send(msg);
        }
    }
}
