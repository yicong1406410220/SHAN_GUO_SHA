using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HeroBase
{
    /// <summary>
    /// 武将名
    /// </summary>
    public string name;
    /// <summary>
    /// 国家
    /// </summary>
    public Country country;
    public enum Country
    {
        魏,
        蜀,
        吴,
        群,
        神,
    }
    /// <summary>
    /// 技能描述
    /// </summary>
    public Dictionary<string, string> SkillsToDescribe = new Dictionary<string, string>();

    public enum SkillType
    {
        主动,
        被动,
        常规
    } 
}
