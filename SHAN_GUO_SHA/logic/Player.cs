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
    //房间ID
    public int roomId = -1;

    //是否断线
    public bool IsOffLine = false;
    //在哪个场景
    public SceneStatus sceneStatus = SceneStatus.Hall;
    //用户状态
    public UserStatus userStatus = UserStatus.Stand;
    public enum UserStatus
    {
        Stand,   //站立
        Sit,     //坐下
        Ready,   //准备
        Battle,   //战斗
        RePlay,   //回放
        LookOn    //旁观
    }

    public enum SceneStatus
    {
        Hall,
        Room,
        Game
    }

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