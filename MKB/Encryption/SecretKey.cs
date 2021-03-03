using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKB.Encryption
{
    public class SecretKey
    {
        // 需要保证 0 < (V + A1) * M + A2 < 100
        private readonly int[] m_ADD1 = new int[4]{1, 3, 1, 5};
        private readonly int[] m_MULT = new int[4]{5, 6, 1, 5};
        private readonly int[] m_ADD2 = new int[4]{1, 2, 1, 8};

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="m"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string Encrypt(string m, string t)
        {
            // 判断输入是否正确
            string str_m = FormatCodeM(m);
            string str_t = FormatCodeT(t);
            if (string.IsNullOrWhiteSpace(str_m) || string.IsNullOrWhiteSpace(str_t))
            {
                return null;
            }

            // 四组日期做不同操作
            string str_t_en = "";
            for (int i = 0; i < str_t.Length; i++)
            {
                int g = Convert.ToInt32(i/8);
                int v = ((Convert.ToInt32(str_t[i].ToString()) + m_ADD1[g]) * m_MULT[g] + m_ADD2[g]);
                if (v > 0 && v < 100)
                {
                    str_t_en += v.ToString("#00");
                }
                else
                {

                }
            }

            // 以 t 移位 m
            string str_r = "";
            for (int i = 0; i < str_m.Length; i++)
            {
                if (str_m[i] >= 'A' && str_m[i] <= 'Z')
                {
                    str_r += AlphfShift(str_m[i], Convert.ToInt32(str_t_en[i].ToString()), 'A', 'Z').ToString();
                }
                else if (str_m[i] >= 'a' && str_m[i] <= 'z')
                {
                    str_r += AlphfShift(str_m[i], Convert.ToInt32(str_t_en[i].ToString()), 'z', 'z').ToString();
                }
                else if (str_m[i] >= '0' && str_m[i] <= '9')
                {
                    str_r += AlphfShift(str_m[i], Convert.ToInt32(str_t_en[i].ToString()), '0', '9').ToString();
                }
                else
                {
                    str_r += str_m[i];
                }
            }

            return str_r;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <returns></returns>
        public string Decrypt(string m, string r)
        {
            // 判断输入是否正确
            string str_m = FormatCodeM(m);
            string str_r = FormatCodeR(r);
            if (string.IsNullOrWhiteSpace(str_m) || string.IsNullOrWhiteSpace(str_r))
            {
                return null;
            }

            // 获取移位 offset
            string str_r_de = "";
            for (int i = 0; i < str_r.Length; i++)
            {
                if (str_m[i] >= 'A' && str_m[i] <= 'Z')
                {
                    str_r_de += ((str_r[i] - str_m[i] + 26) % 26 % 10).ToString();
                }
                else if (str_m[i] >= 'a' && str_m[i] <= 'z')
                {
                    str_r_de += ((str_r[i] - str_m[i] + 26) % 26 % 10).ToString();
                }
                else if (str_m[i] >= '0' && str_m[i] <= '9')
                {
                    str_r_de += ((str_r[i] - str_m[i] + 10) % 10).ToString();
                }
                else
                {
                    str_r_de += 0;
                }
            }

            // 解码
            string str_t = "";
            for (int i = 0; i < 8 * 2; i+=2)
            {
                str_t += (Convert.ToInt32(str_r_de.Substring(i, 2)) - m_ADD2[0]) / m_MULT[0] - m_ADD1[0];
            }

            return str_t;
        }

        /// <summary>
        /// 判断机器码是否输入正确
        /// </summary>
        /// <param name="m"></param>
        /// <returns>机器码，format to ZPBFEBFBFF000906EA9CB6D0FF03A3ZP (2+28+2=32位)</returns>
        private string FormatCodeM(string m)
        {
            string[] ms = m.Split('.');

            string m1 = ms[1];
            string m2 = ms[ms.Length - 1].Replace(":", "");

            if (m1.Length != 16 || m2.Length != 12)
            {
                return null;
            }
            else
            {
                return ("ZP" + m1 + m2 + "ZP") + ("ZP" + m1 + m2 + "ZP");
            }
        }

        /// <summary>
        /// 判断时间码是否输入正确
        /// </summary>
        /// <param name="t"></param>
        /// <returns>时间码，format to 20210330202103302021033020210330 (4*8=32位)</returns>
        private string FormatCodeT(string t)
        {
            // 长度为 8 位
            if (t.Length != 8)
            {
                return null;
            }

            // 均为数字
            foreach (char ch in t)
            {
                if (ch > '9' || ch < '0')
                {
                    return null;
                }
            }

            return (t + t + t + t);
        }

        /// <summary>
        /// 判断注册码是否输入正确
        /// </summary>
        /// <param name="r"></param>
        /// <returns>注册码，format to AVBLFHGCFL210527HC1CE8F6HF31C3CXZTBHEFFEFH050101ID2FF9G8II41D6DX (64位)</returns>
        private string FormatCodeR(string r)
        {
            // 长度为 64 位
            if (r.Length != 64)
            {
                return null;
            }

            // 均为数字
            foreach (char ch in r)
            {
                if (!((ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')))
                {
                    return null;
                }
            }

            return r;
        }

        /// <summary>
        /// 凯撒密码
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="offset"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        private char AlphfShift(char ch, int offset, char start, char stop)
        {
            int delta = stop - start + 1;
            return (char)((Convert.ToInt32(ch) + offset - start + delta) % delta + start);
        }

    }
}
