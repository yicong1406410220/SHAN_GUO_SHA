using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Player
{
    //玩家socket的id
    public string ID = "";
    //玩家用来登录的id
    public string id = "";
    public int roomId = -1;
    public Player(string ID)
    {
        this.ID = ID; 
    }

    public void Send(ProtocolBase obj)
    {
        NetManager.Send(ID, obj);
    }

    //数据库数据
    public PlayerData data;
}