using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

public partial class MsgHandler
{
    public static void SendPopupMsg(string ID, string msg)
    {
        Popup_S_Protocol popup = new Popup_S_Protocol();
        popup.msgtext = msg;
        NetManager.Send(ID, popup);
    }
}
