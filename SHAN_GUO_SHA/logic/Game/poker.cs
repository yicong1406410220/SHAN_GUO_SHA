using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PokerBase
{
    /// <summary>
    /// 花色点数
    /// </summary>
    public Suit suit;
    public enum Suit
    {
        无色,
        黑桃,
        红杏,
        梅花,
        方片,
    }

    public string points;

    public DetailsType detailsType;

    public ViceType viceType
    {
        get
        {
            if ((int)detailsType < 3)
            {
                return ViceType.杀;
            }
            else if ((int)detailsType < 4)
            {
                return ViceType.闪;
            }
            else if ((int)detailsType < 5)
            {
                return ViceType.桃;
            }
            else if ((int)detailsType < 6)
            {
                return ViceType.酒;
            }
            else if ((int)detailsType < 17)
            {
                return ViceType.非延时锦囊;
            }
            else if ((int)detailsType < 20)
            {
                return ViceType.延时锦囊;
            }
            else if ((int)detailsType < 30)
            {
                return ViceType.武器;
            }
            else if ((int)detailsType < 34)
            {
                return ViceType.防具;
            }
            else if ((int)detailsType < 37)
            {
                return ViceType.进攻马;
            }
            else
            {
                return ViceType.防御马;
            }       
        }
    }

    public MainType mainType
    {
        get
        {
            if ((int)viceType < 5)
            {
                return MainType.基本牌;
            }
            else if ((int)viceType < 7)
            {
                return MainType.锦囊牌;
            }
            else
            {
                return MainType.装备牌;
            }
        }
    }

    public enum DetailsType
    {
        杀,
        火杀,
        雷杀,
        闪,
        桃,
        酒,
        //非延时锦囊
        南蛮入侵,
        万箭齐发,
        桃园结义,
        五谷丰登,
        无懈可击,
        顺手牵羊,
        过河拆桥,
        决斗,
        无中生有,
        火攻,
        铁索连环,
        //延时锦囊
        闪电,
        乐不思蜀,
        兵粮寸断,
        //武器
        麒麟弓,
        诸葛连弩,
        贯石斧,
        方天画戟,
        雌雄双股剑,
        青釭剑,
        丈八蛇矛,
        青龙偃月刀,
        古锭刀,
        朱雀羽扇,
        //防具
        仁王盾,
        八卦阵,
        藤甲,
        白银狮子,
        //-1马
        紫骍,
        大宛,
        赤兔,
        //-1马
        绝影,
        爪黄飞电,
        的卢,
    }

    public enum ViceType
    {
        杀,
        闪,
        桃,
        酒,
        非延时锦囊,
        延时锦囊,
        武器,
        防具,
        进攻马,
        防御马,
    }

    public enum MainType
    {
        基本牌,
        锦囊牌,
        装备牌,
    }

}
