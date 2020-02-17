using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 摸牌堆
/// </summary>
public class TouchPile
{
    public List<Poker> pokers = new List<Poker>();

    public TouchPile()
    {
        AddADeckOfCARDS();
        Shuffle();
    }

    /// <summary>
    /// 添加一副牌
    /// </summary>
    public void AddADeckOfCARDS()
    {
        pokers.Add(new Poker(0x00));
        pokers.Add(new Poker(0x10));
        pokers.Add(new Poker(0x20));
        pokers.Add(new Poker(0x30));
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < 13; j++)
            {
                pokers.Add(new Poker((Poker.PokerColor)i, (Poker.PokerDetailType)j));
            }
        }
        pokers.Add(new Poker(Poker.PokerColor.万能, Poker.PokerDetailType.变色));
        pokers.Add(new Poker(Poker.PokerColor.万能, Poker.PokerDetailType.变色));
        pokers.Add(new Poker(Poker.PokerColor.万能, Poker.PokerDetailType.王牌加4));
        pokers.Add(new Poker(Poker.PokerColor.万能, Poker.PokerDetailType.王牌加4));
    }

    /// <summary>
    /// 洗牌
    /// </summary>
    public void Shuffle()
    {
        List<Poker> ShufflePokers = new List<Poker>();
        Random random = new Random();
        while (pokers.Count > 0)
        {
            int index = random.Next(0, pokers.Count);
            ShufflePokers.Add(pokers[index]);
            pokers.RemoveAt(index);
        }
        pokers = ShufflePokers;
    }

}

