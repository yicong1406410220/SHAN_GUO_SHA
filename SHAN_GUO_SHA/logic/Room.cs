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
    public List<string> playerIds = new List<string>();
    //房主id
    public string ownerId = "";
    //密码
    public string pw = "";
    //房间创建时间
    public long creationTime = 0;
    //状态
    public enum Status
    {
        PREPARE = 0, //等待
        FIGHT = 1,//战斗
    }
    public Status status = Status.PREPARE;

    public Room(int id, string name, int maxPlayer, string pw)
    {
        creationTime = Utils.GetTimeStamp();
        this.id = id;
        this.name = name;
        this.maxPlayer = maxPlayer;
        this.pw = pw;
        for (int i = 0; i < maxPlayer; i++)
        {
            playerIds.Add(null);
        }
    }


    //添加旁观玩家
    public bool AddOnLookPlayer(string id, int seat)
    {
        //获取玩家
        Player player = PlayerManager.GetPlayer(id);
        if (player == null)
        {
            Console.WriteLine("room.AddPlayer fail, player is null");
            return false;
        }
        //已经在房间里
        if (playerIds.Contains(player.id))
        {
            Console.WriteLine("room.AddPlayer fail, 已经在房间里");
            return false;
        }
        player.roomId = this.id;
        player.userStatus = Player.UserStatus.LookOn;
        player.seat = seat;
        OnLookPlayerIds.Add(player.id);
        return true;
    }

    //删除玩家
    public bool RemoveOnLookPlayer(string id)
    {
        //获取玩家
        Player player = PlayerManager.GetPlayer(id);
        if (player == null)
        {
            Console.WriteLine("room.RemovePlayer fail, player is null");
            return false;
        }
        //没有在房间旁观列表里
        if (!OnLookPlayerIds.Contains(id))
        {
            return false;
        }
        //设置玩家数据
        player.roomId = -1;
        player.userStatus = Player.UserStatus.InHall;
        player.seat = -1;
        //删除玩家
        OnLookPlayerIds.Remove(id);
        return true;
    }

    

    //添加玩家
    public bool AddPlayer(string id, int seat = -1)
    {
        //获取玩家
        Player player = PlayerManager.GetPlayer(id);
        if (!IsCanAddPlayer(player, seat))
        {
            return false;
        }
        if (seat == -1)
        {
            player.roomId = this.id;
            player.userStatus = Player.UserStatus.Sit;
            for (int i = 0; i < playerIds.Count; i++)
            {
                if (playerIds[i] != null)
                {
                    player.seat = i;
                    playerIds[i] = player.id;
                }
            }
            return true;
        }
        else
        {   
            player.roomId = this.id;
            player.userStatus = Player.UserStatus.Sit;
            player.seat = seat;
            playerIds[seat] = player.id;
            return true;
        }
    }

    public bool IsCanAddPlayer(Player player, int seat)
    {    
        if (seat < -1 || seat >= maxPlayer)
        {
            return false;
        }
        if (player == null)
        {
            Console.WriteLine("room.AddPlayer fail, player is null");
            return false;
        }
        //房间人数
        if (GetPlayerNum() >= maxPlayer)
        {
            Console.WriteLine("room.AddPlayer fail, 房间已满");
            return false;
        }
        //准备状态才能加人
        if (status != Status.PREPARE)
        {
            Console.WriteLine("room.AddPlayer fail, 准备状态才能加人");
            return false;
        }
        //已经在房间里
        if (playerIds.Contains(player.id))
        {
            Console.WriteLine("room.AddPlayer fail, 已经在房间里");
            return false;
        }
        //这个位置已经有人了
        if (playerIds[seat] != null)
        {
            Console.WriteLine("room.AddPlayer fail, 这个座位已经有人了");
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
        player.userStatus = Player.UserStatus.InHall;
        player.seat = -1;
        //删除玩家
        for (int i = 0; i < playerIds.Count; i++)
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
            for (int i = 0; i < OnLookPlayerIds.Count; i++)
            {
                //获取玩家
                Player OnLookPlayer = PlayerManager.GetPlayer(OnLookPlayerIds[i]);
                OnLookPlayer.roomId = -1;
                OnLookPlayer.seat = -1;
            }
            RoomManager.RemoveRoom(this.id);
        }
        return true;
    }

    //选择房主
    public string SwitchOwner()
    {
        for (int i = 0; i < playerIds.Count; i++)
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
        for (int i = 0; i < playerIds.Count; i++)
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
        for (int i = 0; i < playerIds.Count; i++)
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
        for (int i = 0; i < playerIds.Count; i++)
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