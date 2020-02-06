using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web.Script.Serialization;

class Utils
{
    public static JavaScriptSerializer Js = new JavaScriptSerializer();
    //获取时间戳
    public static long GetTimeStamp() {
		TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return Convert.ToInt64(ts.TotalSeconds);
	}
}