using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//获得房间数据
class GetRoomList_C_Protocol : ProtocolBase
{
    public GetRoomList_C_Protocol()
    {
        protocolName = "GetRoomList_C_Protocol";
    }
}

//回应房间数据
class GetRoomListACK_S_Protocol : ProtocolBase
{
    public GetRoomListACK_S_Protocol()
    {
        protocolName = "GetRoomListACK_S_Protocol";
    }
}
