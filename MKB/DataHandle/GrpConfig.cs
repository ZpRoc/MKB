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
    ///     m_indexD  : 循环索引间距
    ///     m_paramPos: 循环参数位置
    ///     m_descr   : 命令具体描述
    /// Note:
    ///     None. 
    /// </summary>
    public class GrpConfig
    {
        public readonly char m_SEG_CHAR = '|';

        public int m_times       = 1;
        public int m_indexS      = 0;
        public int m_indexE      = 0;
        public int m_indexD      = 0;
        public string m_paramPos = string.Empty;
        public string m_descr    = string.Empty;

        public GrpConfig()
        {
        }

        public GrpConfig(int times, int indexS, int indexE, int indexD, string paramPos, string descr)
        {
            m_times    = times;
            m_indexS   = indexS;
            m_indexE   = indexE;
            m_indexD   = indexD;
            m_paramPos = paramPos;
            m_descr    = descr;
        }

        public GrpConfig(GrpConfig grpConfig)
        {
            m_times    = grpConfig.m_times;
            m_indexS   = grpConfig.m_indexS;
            m_indexE   = grpConfig.m_indexE;
            m_indexD   = grpConfig.m_indexD;
            m_paramPos = grpConfig.m_paramPos;
            m_descr    = grpConfig.m_descr;
        }

        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// ListBox 的 Items 转成 string，用 (m_SEG_CHAR = '|') 分割
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string ItemToStr(ComboBox.ObjectCollection items)
        {
            // items 空处理
            if (items.Count == 0)       return string.Empty;

            // 转成 string，用 "|" 分割
            string paramPos = string.Empty;
            foreach (object item in items)
            {
                paramPos += item.ToString() + m_SEG_CHAR.ToString();
            }

            // 返回
            return paramPos.Substring(0, paramPos.Length - 1);
        }

        /// <summary>
        /// 将 GrpConfig 分解成 string[] 
        /// </summary>
        /// <returns></returns>
        public string[] Decompose()
        {
            return new string[] { m_times.ToString(), m_indexS.ToString(), m_indexE.ToString(), m_indexD.ToString(), m_paramPos, m_descr };
        }
    }
}
