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
        public string m_descr = string.Empty;
        public int m_times   = 1;

        public GrpConfig()
        {
        }

        public GrpConfig(int times, string descr)
        {
            m_times = times;
            m_descr = descr;
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //



    }
}
