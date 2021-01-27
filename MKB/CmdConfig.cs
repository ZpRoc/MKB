using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKB
{
    /// <summary>
    /// CmdConfig:
    ///     命令配置 数据类型定义
    /// Function:
    ///     public string[] Decompose(): 将 CmdConfig 分解成 string[] 
    /// Variable:
    ///     m_type : 类型，鼠标 OR 键盘
    ///     m_posX : 鼠标位置 X
    ///     m_posY : 鼠标位置 Y
    ///     m_op   : 操作命令
    ///     m_text : 操作内容
    ///     m_time : 命令执行后延时时间
    ///     m_unit : 命令执行后延时时间单位
    ///     m_descr: 命令具体描述
    /// Note:
    ///     None. 
    /// </summary>
    public class CmdConfig
    {
        public string m_type  = string.Empty;
        public string m_posX  = string.Empty;
        public string m_posY  = string.Empty;
        public string m_op    = string.Empty;
        public string m_text  = string.Empty;
        public string m_time  = string.Empty;
        public string m_unit  = string.Empty;
        public string m_descr = string.Empty;

        public CmdConfig()
        {
        }

        public CmdConfig(string type, string posX, string posY, string op, string text, string time, string unit, string descr)
        {
            m_type  = type;
            m_posX  = posX;
            m_posY  = posY;
            m_op    = op;
            m_text  = text;
            m_time  = time;
            m_unit  = unit;
            m_descr = descr;
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 将 CmdConfig 分解成 string[] 
        /// </summary>
        /// <returns></returns>
        public string[] Decompose()
        {
            return new string[] {m_type, m_posX, m_posY, m_op, m_text, string.Concat(m_time, " ", m_unit), m_descr};
        }
    }
}
