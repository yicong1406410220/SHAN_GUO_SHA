using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HeroBase
{
    /// <summary>
    /// 唯一key
    /// </summary>
    public int key;
    /// <summary>
    /// 武将名
    /// </summary>
    public string name;
    /// <summary>
    /// 血量
    /// </summary>
    public int Hp = 4;
    /// <summary>
    /// 国家
    /// </summary>
    public string country;
    /// <summary>
    /// 技能描述
    /// </summary>
    public Dictionary<string, string> SkillsToDescribe = new Dictionary<string, string>();


}
