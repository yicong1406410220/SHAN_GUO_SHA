using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Room
{
    //房间id
    public int id = 0;
    //房间名
    public string name = "";
    //最大玩家数
    public int maxPlayer = 2;
    //旁观列表
    public List<string> OnLookPlayerIds = new List<string>();
    //玩家列表
    public string[] playerIds;
    //房主id
    public string ownerId = "";
    //密码
    public string pw = "";
    //房间创建时间
    public long creationTime = 0;
    //状态
    public enum Status
    {
        PREPARE = 0,
        FIGHT = 1,
    }
    public Status status = Status.PREPARE;

    public Room(int id, string name, int maxPlayer, string pw)
    {
        creationTime = Utils.GetTimeStamp();
        this.id = id;
        this.name = name;
        this.maxPlayer = maxPlayer;
        this.pw = pw;
        playerIds = new string[maxPlayer];
    }

    //添加玩家
    public bool AddPlayer(string id)
    {
        //获取玩家
        Player player = PlayerManager.GetPlayer(id);
        if (!IsCanAddPlayer(player))
        {
            return false;
        }
        player.roomId = this.id;
        for (int i = 0; i < playerIds.Length; i++)
        {
            if (playerIds[i] != null)
            {
                playerIds[i] = player.id;
            }
        }
        return true;
    }

    public bool IsCanAddPlayer(Player player)
    {
        
        if (player == null)
        {
            Console.WriteLine("room.AddPlayer fail, player is null");
            return false;
        }
        //房间人数
        if (GetPlayerNum() >= maxPlayer)
        {
            Console.WriteLine("room.AddPlayer fail, reach maxPlayer");
            return false;
        }
        //准备状态才能加人
        if (status != Status.PREPARE)
        {
            Console.WriteLine("room.AddPlayer fail, not PREPARE");
            return false;
        }
        //已经在房间里
        if (playerIds.Contains(player.id))
        {
            Console.WriteLine("room.AddPlayer fail, already in this room");
            return false;
        }
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
        //获取玩家
        Player player = PlayerManager.GetPlayer(id);
        if (player == null)
        {
            Console.WriteLine("room.RemovePlayer fail, player is null");
            return false;
        }
        //没有在房间里
        if (!playerIds.Contains(id))
        {
            Console.WriteLine("room.RemovePlayer fail, not in this room");
            return false;
        }
        //设置玩家数据
        player.roomId = -1;
        //删除玩家
        for (int i = 0; i < playerIds.Length; i++)
        {
            if (playerIds[i] != null && playerIds[i] == player.id)
            {
                playerIds[i] = null;
            }
        }
        //战斗状态退出
        if (status == Status.FIGHT)
        {
            player.data.lost++;
            player.data.flee++;
        }
        //设置房主
        if (ownerId == player.id)
        {
            ownerId = SwitchOwner();
        }
        //房间为空
        if (GetPlayerNum() == 0)
        {
            RoomManager.RemoveRoom(this.id);
        }
        return true;
    }

    //选择房主
    public string SwitchOwner()
    {
        for (int i = 0; i < playerIds.Length; i++)
        {
            if (playerIds[i] != null)
            {
                return playerIds[i];
            }
        }
        //房间没人
        return "";
    }

    //改变座位
    public bool SwitchSeat(string id, int Seat)
    {
        if (playerIds[Seat] != null || !playerIds[Seat].Contains(id))
        {
            return false;
        }
        for (int i = 0; i < playerIds.Length; i++)
        {
            if (playerIds[i] != null && playerIds[i] == id)
            {
                playerIds[i] = null;
            }
        }
        playerIds[Seat] = id;
        return true;
    }


    public int GetPlayerNum()
    {
        int num = 0;
        for (int i = 0; i < playerIds.Length; i++)
        {
            if(playerIds[i] != null)
            {
                num++;
            }
        }
        return num;
    }

    


    //广播消息
    public void Broadcast(ProtocolBase obj)
    {
        for (int i = 0; i < playerIds.Length; i++)
        {
            if (playerIds != null)
            {
                Player player = PlayerManager.GetPlayer(playerIds[i]);
                player.Send(obj);
            }
        }
    }


    //定时更新
    public void Update()
    {
        
    }
}