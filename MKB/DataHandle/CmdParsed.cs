using System;


namespace MKB.DataHandle
{
    /// <summary>
    /// CmdParsed:
    ///     命令解析 数据类型定义
    /// Function:
    ///     
    /// Variable:
    ///     
    /// Note:
    ///     None. 
    /// </summary>
    public class CmdParsed
    {
        public string m_grp          = string.Empty;
        public string m_cmd          = string.Empty;
        public int m_time            = 0;
        public CmdConfig m_cmdConfig = new CmdConfig();

        public CmdParsed()
        {

        }

        public CmdParsed(string grp, string cmd, int time, CmdConfig cmdConfig)
        {
            m_grp       = grp;
            m_cmd       = cmd;
            m_time      = time;
            m_cmdConfig = cmdConfig;
        }

        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        
    }
}
