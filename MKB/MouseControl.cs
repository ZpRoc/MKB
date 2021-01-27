using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKB
{
    /// <summary>
    /// MouseControl:
    ///     鼠标控制操作类
    /// Function:
    ///     public Point GetMousePos()                    : 获取鼠标位置
    ///     public void MouseMove(int x, int y)           : 鼠标移动
    ///     public void MouseLeftClick(int x, int y)      : 鼠标左键单击
    ///     public void MouseLeftDoubleClick(int x, int y): 鼠标左键双击
    ///     public void MouseRightClick(int x, int y)     : 鼠标右键单击
    /// DllImport:
    ///     user32.dll 动态链接库
    ///         private static extern int SetCursorPos(int X, int Y)
    ///         private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo)
    /// Variable: 
    ///     MouseEventFlags: 鼠标事件枚举
    ///     m_SLEEP_TIME   : 按键间隔休眠时间
    /// Note:
    ///     None. 
    /// </summary>
    public class MouseControl
    {
        private const int m_SLEEP_TIME = 10;    // 点击间隔休眠时间

        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 引用 user32.dll 动态链接库 (windows api)
        /// </summary>
      
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        private enum MouseEventFlags
        {
            Move       = 0x0001,
            LeftDown   = 0x0002,
            LeftUp     = 0x0004,
            RightDown  = 0x0008,
            RightUp    = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp   = 0x0040,
            Wheel      = 0x0800,
            Absolute   = 0x8000,
        }

        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 获取鼠标位置
        /// </summary>
        /// <returns></returns>
        public Point GetMousePos()
        {
            return(Control.MousePosition);
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseMove(int x, int y)
        {
            SetCursorPos(x, y);
            Thread.Sleep(m_SLEEP_TIME);
        }

        /// <summary>
        /// 鼠标左键单击
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseLeftClick(int x, int y)
        {
            MouseMove(x, y);

            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Absolute), x, y, 0, IntPtr.Zero);
            Thread.Sleep(m_SLEEP_TIME);
        }

        /// <summary>
        /// 鼠标左键双击
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseLeftDoubleClick(int x, int y)
        {
            MouseMove(x, y);

            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Absolute), x, y, 0, IntPtr.Zero);
            Thread.Sleep(m_SLEEP_TIME);

            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Absolute), x, y, 0, IntPtr.Zero);
            Thread.Sleep(m_SLEEP_TIME);
        }

        /// <summary>
        /// 鼠标右键单击
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseRightClick(int x, int y)
        {
            MouseMove(x, y);

            mouse_event((int)(MouseEventFlags.RightDown | MouseEventFlags.RightUp | MouseEventFlags.Absolute), x, y, 0, IntPtr.Zero);
            Thread.Sleep(m_SLEEP_TIME);
        }
    }
}
