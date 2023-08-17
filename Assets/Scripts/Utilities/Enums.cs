using UnityEngine;

namespace Enums
{
    /// <summary>
    /// 枚举模板
    /// </summary>
    public class Sample
    {
        //TODO:定义枚举
        public enum Enum
        {
            [EnumName("枚举1")]
            enum1,
            [EnumName("枚举2")]
            enum2
        }
        //TODO:填写枚举的显示名
        public readonly string[] enumNames = { };

        #region 通用方法无需更改
        public string EnumName(Enum e) => enumNames[(int)e];
        public int Count => enumNames.Length;
        #endregion
    }
}