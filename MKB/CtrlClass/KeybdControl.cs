using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace MKB.CtrlClass
{
    /// <summary>
    /// KeybdControl:
    ///     键盘控制操作类
    /// Function:
    ///     public void KeybdText(string str)            : 输入文本
    ///     public void KeybdComb(params Keys[] keys)    : 组合键操作，解析 Keys[]
    ///     public void KeybdComb(string keyStrs)        : 组合键操作，解析 string
    /// DllImport: 
    ///     user32.dll 动态链接库
    ///         private static extern Keys VkKeyScan(char ch)
    ///         private static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo)
    /// Variable: 
    ///     KeybdEventFlags: 键盘事件枚举
    ///     m_SLEEP_TIME   : 按键间隔休眠时间
    /// Note:
    ///     None. 
    /// </summary>
    public class KeybdControl
    {
        private const int m_SLEEP_TIME = 10;    // 按键间隔休眠时间

        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 引用 user32.dll 动态链接库 (windows api)
        /// </summary>

        [DllImport("user32.dll")]
        private static extern Keys VkKeyScan(char ch);

        [DllImport("user32.dll")]
        private static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        // 键盘事件枚举
        private enum KeybdEventFlags
        {
            Down     = 0x00,
            Extended = 0x01, 
            Up       = 0x02,
        }

        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 输入文本
        /// </summary>
        /// <param name="str"></param>
        public void KeybdText(string str)
        {
            foreach (char ch in str)
            {
                // char 转 Keys
                Keys key = VkKeyScan(ch);

                // 键值 > 256，需要结合 Shift 键
                if (Convert.ToInt32(key) < 256)
                {
                    keybd_event(key, 0, (uint)(KeybdEventFlags.Down), 0);
                }
                else
                {
                    keybd_event(Keys.ShiftKey, 0, (uint)(KeybdEventFlags.Down), 0);
                    keybd_event((Keys)(Convert.ToInt32(key)-256), 0, (uint)(KeybdEventFlags.Down), 0);
                    keybd_event((Keys)(Convert.ToInt32(key)-256), 0, (uint)(KeybdEventFlags.Up), 0);
                    keybd_event(Keys.ShiftKey, 0, (uint)(KeybdEventFlags.Up), 0);
                }

                // 休眠一段时间
                Thread.Sleep(m_SLEEP_TIME);
            }
        }

        /// <summary>
        /// 组合键操作，解析 Keys[]
        /// </summary>
        /// <param name="keys"></param>
        public void KeybdComb(params Keys[] keys)
        {
            // Down
            for (int i = 0; i < keys.Length; i++)
            {
                keybd_event(keys[i], 0, (uint)(KeybdEventFlags.Down), 0);
                Thread.Sleep(m_SLEEP_TIME);
            }

            // Up
            for (int i = keys.Length - 1; i >= 0; i--)
            {
                keybd_event(keys[i], 0, (uint)(KeybdEventFlags.Up), 0);
                Thread.Sleep(m_SLEEP_TIME);
            }
        }

        /// <summary>
        /// 组合键操作，解析 string
        /// </summary>
        /// <param name="keyStrs">用 + 分割开的字符串，例如 Ctrl+C</param>
        public void KeybdComb(string keyStrs)
        {
            List<Keys> keys = new List<Keys>();

            // 依次解析键值
            foreach (string keyStr in keyStrs.Split('+'))
            {
                // 防止键值为空
                if (string.IsNullOrEmpty(keyStr))
                {
                    continue;
                }

                // 特殊键值控制
                if (keyStr == "Ctrl")
                {
                    keys.Add(Keys.ControlKey);
                }
                else if (keyStr == "Shift")
                {
                    keys.Add(Keys.ShiftKey);
                }
                else if (keyStr == "Alt")
                {
                    keys.Add(Keys.Menu);
                }
                else if(keyStr == "Win")
                {
                    keys.Add(Keys.LWin);
                }
                else
                {
                    keys.Add((Keys)Enum.Parse(typeof(Keys), keyStr));
                }
            }

            // 调用 keybd_event
            KeybdComb(keys.ToArray());
        }
    }
}
