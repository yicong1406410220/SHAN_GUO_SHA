using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RoomData
{
    //房间id
    public int id = 0;
    //房间名
    public string name = "";
    //最大玩家数
    public int maxPlayer = 2;
    //玩家列表
    public Dictionary<string, bool> playerIds = new Dictionary<string, bool>();
    //房主id
    public string ownerId = "";
    //密码
    public string pw = "";
    //房间创建时间
    public long creationTime = 0;
}
