using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Game
{
    public int roomID;

    public int playNum;

    public GamePlayer gamePlayer;

    public Game(int roomID)
    {
        this.roomID = roomID;
        Room room = RoomManager.GetRoom(roomID);
        playNum = room.maxPlayer;
    }


}
