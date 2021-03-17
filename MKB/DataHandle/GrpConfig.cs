using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace MKB.DataHandle
{
    /// <summary>
    /// GrpConfig:
    ///     命令组 数据类型定义
    /// Function:
    ///     private string ItemToStr(ComboBox.ObjectCollection items)
    ///     public string[] Decompose(): 将 GrpConfig 分解成 string[] 
    /// Variable:
    ///     m_times   : 循环次数
    ///     m_indexS  : 循环起始索引
    ///     m_indexE  : 循环终止索引
    ///     m_paramPos: 循环参数位置
    ///     m_descr   : 命令具体描述
    /// Note:
    ///     None. 
    /// </summary>
    public class GrpConfig
    {
        public int m_times       = 1;
        public string m_indexS   = string.Empty;
        public string m_indexE   = string.Empty;
        public ComboBox.ObjectCollection m_paramPos;
        public string m_descr    = string.Empty;

        public GrpConfig()
        {
        }

        public GrpConfig(int times, string indexS, string indexE, ComboBox.ObjectCollection paramPos, string descr)
        {
            m_times    = times;
            m_indexS   = indexS;
            m_indexE   = indexE;
            m_paramPos = paramPos;
            m_descr    = descr;
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// ListBox 的 Items 转成 string，用 "|" 分割
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private string ItemToStr(ComboBox.ObjectCollection items)
        {
            // items 空处理
            if (items.Count == 0)       return string.Empty;

            // 转成 string，用 "|" 分割
            string paramPos = string.Empty;
            foreach (object item in items)
            {
                paramPos += item.ToString() + "|";
            }

            // 返回
            return paramPos.Substring(0, paramPos.Length - 3);
        }

        /// <summary>
        /// 将 GrpConfig 分解成 string[] 
        /// </summary>
        /// <returns></returns>
        public string[] Decompose()
        {
            return new string[] { m_times.ToString(), m_indexS, m_indexE, ItemToStr(m_paramPos), m_descr };
        }
    }
}
