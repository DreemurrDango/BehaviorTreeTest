using UnityEngine;

namespace Enums
{
    /// <summary>
    /// ö��ģ��
    /// </summary>
    public class Sample
    {
        //TODO:����ö��
        public enum Enum
        {
            [EnumName("ö��1")]
            enum1,
            [EnumName("ö��2")]
            enum2
        }
        //TODO:��дö�ٵ���ʾ��
        public readonly string[] enumNames = { };

        #region ͨ�÷����������
        public string EnumName(Enum e) => enumNames[(int)e];
        public int Count => enumNames.Length;
        #endregion
    }
}