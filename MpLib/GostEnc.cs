using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpLib
{
    class GostEnc
    {
       private int [,] wz_sp;
        

        private int [] wz_spkey;

        public GostEnc()
        {
            wz_sp = new int[8,16];
            wz_spkey = new int[32];

            /*加密密钥使用顺序表*/
            for (int i = 0; i < 32; i++)
            {
                wz_spkey[i] = i;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    wz_sp[i,j] = i + j;
                }
            }
        }


        /*s-盒替换、循环左移11位操作*/
        private long func(long x)
        {
            x = wz_sp[7,(x >> 28) & 0xf] << 28 | wz_sp[6,(x >> 24) & 0xf] << 24
                | wz_sp[5,(x >> 20) & 0xf] << 20 | wz_sp[4,(x >> 16) & 0xf] << 16
                | wz_sp[3,(x >> 12) & 0xf] << 12 | wz_sp[2,(x >> 8) & 0xf] << 8
                | wz_sp[1,(x >> 4) & 0xf] << 4 | wz_sp[0,x & 0xf];

            return (x << 11) | (x >> 21);
        }
        /*左右值交换*/
       private  long  gost_swap(ref long Ldata, ref long Rdata)
        {
            long  tempbuf;
            tempbuf = Rdata;
            Rdata = Ldata;
            Ldata = tempbuf;
            return 0;

        }

        /*32轮解密操作*/
       public  long dencry_data(ref long Ldata, ref long Rdata, ref long[] key)
        {
            long i = 0;
            long tempbuf = 0;
            for (i = 0; i < 32; i++)
            {
                Rdata ^= func(Ldata + key[wz_spkey[31 - i]]);
                gost_swap(ref Ldata, ref Rdata); /*左右值交换*/
            }
            gost_swap(ref Ldata, ref Rdata);    /*左右值交换*/
            return 0;
        }

        /*解密接口函数*/
       public  int gost_dec(ref long[] data,/*待解密数据首地址,内容需保证是64位长*/
                       long[] key/*用户输入密钥首地址,内容需保证是256位长*/
                       )
        {
            long Ldata;
            long Rdata;
            Ldata = data[0];
            Rdata = data[1];/*分成左右两个部分,每部分32字节*/
            dencry_data(ref Ldata, ref Rdata, ref key);
            /*明文可用data读出*/
            return 0;
        }

       public int gost_enc(ref long []data, /*待加密数据首地址,内容需保证是64位长*/
                       ref long [] key/*用户输入密钥首地址,内容需保证是256位长*/
                       )
        {
            long Ldata;
            long Rdata;
            Ldata = data[0];
            Rdata = data[1];/*分成左右两个部分,每部分32字节*/
            encry_data(ref Ldata, ref Rdata, ref key);
            /*密文可用data读出*/
            return 0;
        }
        /*32轮加密操作*/
        public long encry_data(ref long Ldata, ref long Rdata, ref long [] key)
        {
            long i = 0;
            long tempbuf = 0;
            for (i = 0; i < 32; i++)
            {
                Rdata ^= func(Ldata + key[wz_spkey[i]]);
                gost_swap(ref Ldata, ref Rdata); /*左右值交换*/
            }
            gost_swap(ref Ldata, ref Rdata);    /*左右值交换*/
            return 0;
        }


    }
}
