using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//注册
class Register_C_Protocol : ProtocolBase
{
    public Register_C_Protocol()
    {
        protocolName = "Register_C_Protocol";
    }
    public string id;
    public string pw;
}

class Register_S_Protocol : ProtocolBase
{
    public Register_S_Protocol()
    {
        protocolName = "Register_S_Protocol";
    }
    //（0-成功,1-失败）
    public int flag;
    public string msgtext;
}
//登录
class Login_C_Protocol : ProtocolBase
{
    public Login_C_Protocol()
    {
        protocolName = "Login_C_Protocol";
    }
    public string id;
    public string pw;
}

class Login_S_Protocol : ProtocolBase
{
    public Login_S_Protocol()
    {
        protocolName = "Login_S_Protocol";
    }
    //(0-成功,1-失败)
    public int flag;
    public string msgtext;
    public PlayerData playerData;
}