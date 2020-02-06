using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 弹窗消息
/// </summary>
class Popup_S_Protocol : ProtocolBase
{
    public Popup_S_Protocol()
    {
        protocolName = "Popup_S_Protocol";
    }
    //信息
    public string msgtext; 
}

//踢下线（服务端推送）
public class Kick_S_Protocol : ProtocolBase
{
    public Kick_S_Protocol()
    {
        protocolName = "Kick_S_Protocol";
    }   
    
    //原因（0-其他人登陆同一账号）
    public int reason = 0;
    public string msgtext = "";
}

//ping协议
public class Ping_C_Protocol : ProtocolBase
{
    public Ping_C_Protocol()
    {
        protocolName = "Ping_C_Protocol";
    }
}

//Pong协议
public class Pong_S_Protocol : ProtocolBase
{
    public Pong_S_Protocol()
    {
        protocolName = "Pong_S_Protocol";
    }
}