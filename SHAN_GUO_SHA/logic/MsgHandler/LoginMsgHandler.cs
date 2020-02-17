using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

public partial class MsgHandler
{
    public static void Register_C_Protocol(string ID, string msg)
    {
        Register_C_Protocol register_C = Utils.Js.Deserialize<Register_C_Protocol>(msg);
        Register_S_Protocol register_S = new Register_S_Protocol();
        if (!DbManager.Register(register_C.id, register_C.pw))
        {
            register_S.flag = 1;
            register_S.msgtext = "ID已存在,或者ID中存在不安全字符串";
            NetManager.Send(ID, register_S);
        }
        else
        {
            DbManager.CreatePlayer(register_C.id);           
            register_S.flag = 0;
            register_S.msgtext = "成功";
            NetManager.Send(ID, register_S);
        }
    }

    public static void Login_C_Protocol(string ID, string msg)
    {
        Login_C_Protocol login_C = Utils.Js.Deserialize<Login_C_Protocol>(msg);
        Login_S_Protocol login_S = new Login_S_Protocol();
        if (!DbManager.CheckPassword(login_C.id, login_C.pw))
        {
            login_S.flag = 1;
            login_S.msgtext = "账户或密码错误";
            NetManager.Send(ID, login_S);
            return;
        }
        //如果已经登陆，踢下线
        if (PlayerManager.IsOnline(login_C.id))
        {
            //发送踢下线协议
            Player other = PlayerManager.GetPlayer(login_C.id);
            Kick_S_Protocol msgKick = new Kick_S_Protocol();
            msgKick.reason = 0;
            NetManager.Send(ID, msgKick);
            //断开连接
            NetManager.Close(ID);
            Player player = PlayerManager.GetPlayer(login_C.id);
            if (player == null)
            {
                login_S.flag = 1;
                login_S.msgtext = "登录失败没有玩家数据";
                NetManager.Send(ID, login_S);
                return;
            }
            player.ID = ID;
            //断线重连同步数据
        }
        else if (PlayerManager.IsOnlineData(login_C.id))
        {
            Player player = PlayerManager.GetPlayer(login_C.id);
            if (player == null)
            {
                login_S.flag = 1;
                login_S.msgtext = "登录失败没有玩家数据";
                NetManager.Send(ID, login_S);
                return;
            }
            player.ID = ID;
            player.IsOffLine = false;
            //断线重连同步数据
        }
        else
        {
            //获取玩家数据
            PlayerData playerData = DbManager.GetPlayerData(login_C.id);
            if (playerData == null)
            {
                login_S.flag = 1;
                login_S.msgtext = "登录失败没有玩家数据";
                NetManager.Send(ID, login_S);
                return;
            }
            //构建Player
            Player player = new Player(ID);
            player.id = login_C.id;
            player.data = playerData;
            PlayerManager.AddPlayer(login_C.id, player);
            //登录成功
            login_S.flag = 0;
            login_S.msgtext = "成功";
            login_S.playerData = playerData;
            NetManager.Send(ID, login_S);
        }
    }


}
