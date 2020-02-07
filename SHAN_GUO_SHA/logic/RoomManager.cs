using System;
using System.Collections.Generic;

public class RoomManager
{
	//最大id
	private static int maxId = 1;
	//房间列表
	public static Dictionary<int, Room> rooms = new Dictionary<int, Room>();

	//创建房间
	public static Room AddRoom(){
		maxId++;
		Room room = new Room(maxId, 2, "");
		room.id = maxId;
		rooms.Add(room.id, room);
		return room;
	}

	//删除房间
	public static bool RemoveRoom(int id) {
		rooms.Remove(id);
		return true;
	}

	//获取房间
	public static Room GetRoom(int id) {
		if(rooms.ContainsKey(id)){
			return rooms[id];
		}
		return null;
	}

	//Update
	public static void Update(){
		foreach(Room room in rooms.Values){
			room.Update();
		}
	}
}


