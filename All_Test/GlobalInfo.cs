using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_Test.Serials;
using System.Windows;
using System.Timers;

namespace All_Test
{
    public class GlobalInfo
    {
        public static GlobalInfo Instance
        {
            get { return _instance; }
        }
        private static readonly GlobalInfo _instance = new GlobalInfo();

        ///<summary>
        ///通信接口
        ///</summary>
        public SamplerSerials Totalab_LSerials
        {
            get => _totalabSerials;
            set
            {
                this._totalabSerials = value;
            }
        }
        private SamplerSerials _totalabSerials = new SamplerSerials();



        #region 四个字节十六进制数和单精度浮点数之间的相互转化
        
        public static float ToFloat(byte[] data)
        {
            float a = 0;
            byte i;
            byte[] x = data;
            unsafe
            {
                void* pf;
                fixed (byte* px = x)
                {
                    pf = &a;
                    for (i = 0; i < data.Length; i++)
                    {
                        *((byte*)pf + i) = *(px + i);
                    }
                }
            }


            return a;
        }

        public static byte[] ToByte(float data)
        {
            unsafe
            {
                byte* pdata = (byte*)&data;
                byte[] byteArray = new byte[sizeof(float)];
                for (int i = 0; i < sizeof(float); ++i)
                    byteArray[i] = *pdata++;

                return byteArray;
            }
        }
        #endregion

        #region int to byte
        /// <summary>
        /// 低位在前高位在后
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }
        /// <summary>
        /// 高位在前低位在后
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] intToBytes2(int value)
        {
            byte[] src = new byte[4];
            src[0] = (byte)((value >> 24) & 0xFF);
            src[1] = (byte)((value >> 16) & 0xFF);
            src[2] = (byte)((value >> 8) & 0xFF);
            src[3] = (byte)(value & 0xFF);
            return src;
        }

        #endregion

        #region byte[] to int
        /// <summary>
        /// 低位在前高位在后
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int bytesToInt(byte[] src, int offset)
        {
            int value;
            value = (int)((src[offset] & 0xFF)
                    | ((src[offset + 1] & 0xFF) << 8)
                    | ((src[offset + 2] & 0xFF) << 16)
                    | ((src[offset + 3] & 0xFF) << 24));
            return value;
        }

        /// <summary>
        /// 高位在前低位在后
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int bytesToInt3(byte[] src, int offset)
        {
            int value;
            value = (int)(((src[offset] & 0xFF) << 24)
                    | ((src[offset + 1] & 0xFF) << 16)
                    | ((src[offset + 2] & 0xFF) << 8)
                    | (src[offset + 3] & 0xFF));
            return value;
        }

        #endregion
    }
}
