using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Game
{
    public int roomID;

    /// <summary>
    /// 玩家数量
    /// </summary>
    public int playNum;

    public GamePlayer[] gamePlayer;

    /// <summary>
    /// 谁的回合
    /// </summary>
    public int WhoTurn = -1;


    /// <summary>
    /// 阶段数
    /// </summary>
    public enum Phase
    {
        黑棋的回合,
        白棋的回合,
    }


    public Game(int roomID)
    {
        this.roomID = roomID;
        Room room = RoomManager.GetRoom(roomID);
        playNum = room.maxPlayer;
    }


}
