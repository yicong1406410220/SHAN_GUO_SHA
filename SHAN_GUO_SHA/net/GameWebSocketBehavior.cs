using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WebSocketSharp;
using WebSocketSharp.Server;

class GameWebSocketBehavior : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        string msgBase = e.Data;
        Console.WriteLine("Receive " + ID + ":" + msgBase);
        //反序列化
        ProtocolBase protocolBase = Utils.Js.Deserialize<ProtocolBase>(msgBase);
        if (protocolBase.protocolName != "Ping_C_Protocol" && protocolBase.protocolName != "Pong_S_Protocol")
        {
            SGS.Log.File = "log_" + ID;
            SGS.Log.Info("Receive_" + ID + ":" + msgBase);
        }
        //分发消息
        MethodInfo mi = typeof(MsgHandler).GetMethod(protocolBase.protocolName);
        object[] o = { ID, msgBase };
        if (mi != null)
        {
            mi.Invoke(null, o);
        }
    }

    protected override void OnOpen()
    {
        Console.WriteLine("打开Socket");
        Log.Level = LogLevel.Info;
    }

    protected override void OnClose(CloseEventArgs e)
    {
        Console.WriteLine("关闭Socket:" + e.Code);
    }

    protected override void OnError(ErrorEventArgs e)
    {
        Console.WriteLine("强迫关闭Socket:" + e);
    }
}