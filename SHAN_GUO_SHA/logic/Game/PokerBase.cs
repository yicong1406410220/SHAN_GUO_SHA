using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PokerBase
{
    ///// <summary>
    ///// 花色点数
    ///// </summary>
    //public Suit suit;
    //public enum Suit
    //{
    //    无色,
    //    黑桃,
    //    红杏,
    //    梅花,
    //    方片,
    //}

    //public string points;

    public int pokerValue = 0x00;
    public PokerColor Color
    {
        get
        {
            int num = (0x00 & 0xf0) >> 4;
            return (PokerColor)num;
        }
        set
        {
            pokerValue = (pokerValue & 0x0f) & ((int)value << 4);
        }
    }

    public PokerDetailType DetailType
    {
        get
        {
            int num = (0x00 & 0x0f);
            return (PokerDetailType)num;
        }
        set
        {
            pokerValue = (pokerValue & 0xf0) & ((int)value);
        }
    }

    public PokerType Type
    {
        get
        {
            int num = (0x00 & 0x0f);
            if (num > 12)
            {
                return PokerType.万能;
            }
            else if (num > 9)
            {
                return PokerType.功能;
            }
            else
            {
                return PokerType.数字;
            }                
        }
    }

    public enum PokerColor
    {
        红,
        黄,
        蓝,
        绿,
        万能
    }

    public enum PokerType
    {
        数字,
        功能,
        万能,
    }

    public enum PokerDetailType
    {
        数0,
        数1,
        数2,
        数3,
        数4,
        数5,
        数6,
        数7,
        数8,
        数9,
        禁止,
        反转,
        加2,
        变色,
        王牌加4
    }
}
