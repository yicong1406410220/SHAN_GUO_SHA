using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Room
{
    //id
    public int id = 0;
    //最大玩家数
    public int maxPlayer = 2;
    //玩家列表
    public Dictionary<string, bool> playerIds = new Dictionary<string, bool>();
    //房主id
    public string ownerId = "";
    //状态
    public enum Status
    {
        PREPARE = 0,
        FIGHT = 1,
    }
    public Status status = Status.PREPARE;
    //上一次判断结果的时间
    private long lastjudgeTime = 0;

    //添加玩家
    public bool AddPlayer(string id)
    {
        return true;
    }

    //是不是房主
    public bool isOwner(Player player)
    {
        return player.id == ownerId;
    }

    //删除玩家
    public bool RemovePlayer(string id)
    {
        return true;
    }

    //选择房主
    public string SwitchOwner()
    {
        //选择第一个玩家
        foreach (string id in playerIds.Keys)
        {
            return id;
        }
        //房间没人
        return "";
    }


    //广播消息
    public void Broadcast(ProtocolBase obj)
    {
        foreach (string id in playerIds.Keys)
        {
            Player player = PlayerManager.GetPlayer(id);
            player.Send(obj);
        }
    }


    //定时更新
    public void Update()
    {
        
    }
}