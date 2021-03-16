using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKB.DataHandle
{
    /// <summary>
    /// GrpConfig:
    ///     命令组 数据类型定义
    /// Function:
    ///     
    /// Variable:
    ///     
    /// Note:
    ///     None. 
    /// </summary>
    public class GrpConfig
    {
        public string m_name = string.Empty;
        public int m_times   = 1;

        public GrpConfig()
        {
        }

        public GrpConfig(string name)
        {
            m_name = name;
        }

        public GrpConfig(string name, int times)
        {
            m_name  = name;
            m_times = times;
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //



    }
}
