using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResDecoder
{
    public class DecodeParam
    {
        public static int NumberOfCharacter = 0;
        public static string SelectedRegion = "";
    }

    public interface IResReader
    {
        void Read(FileStream fs);

        void Write(StringBuilder sb);
    }

    public abstract class ResReader : IResReader
    {
        public abstract void Read(FileStream fs);
        public abstract void Write(StringBuilder sb);

        private byte[] GetNumberOfBytes(FileStream fs, int count)
        {
            byte[] buff = new byte[count];
            fs.Read(buff, 0, count);
            return buff;
        }

        public byte GetByte(FileStream fs)
        {
            return GetNumberOfBytes(fs, 1)[0];
        }

        public sbyte GetSByte(FileStream fs)
        {
            return Convert.ToSByte(GetNumberOfBytes(fs, 1)[0]);
        }

        public Int16 GetShort(FileStream fs)
        {
            // short
            var buff = GetNumberOfBytes(fs, 2);
            return BitConverter.ToInt16(buff, 0);
        }

        public ushort GetUshort(FileStream fs)
        {
            var buff = GetNumberOfBytes(fs, 2);
            return BitConverter.ToUInt16(buff, 0);
        }

        public int GetInt(FileStream fs)
        {
            // ulong
            var buff = GetNumberOfBytes(fs, 4);
            return BitConverter.ToInt32(buff, 0);
        }

        public UInt32 GetUint(FileStream fs)
        {
            // ulong
            var buff = GetNumberOfBytes(fs, 4);
            return BitConverter.ToUInt32(buff, 0);
        }

        public float GetFloat(FileStream fs)
        {
            var buff = GetNumberOfBytes(fs, 4);
            return BitConverter.ToSingle(buff, 0);
        }

        public string GetStringByLength(FileStream fs, int length)
        {
            var buff = GetNumberOfBytes(fs, length * 2);
            var ret = Encoding.Unicode.GetString(buff);
            ret = ret.Replace("\n", "\\n");
            return ret;
        }

        public string GetString(FileStream fs)
        {
            var length = GetUshort(fs);
            return GetStringByLength(fs, length);
        }

        public object GetBytes<T>(FileStream fs, T t)
        {
            Type type = typeof(T);
            if (type == typeof(uint))
            {
                var buff = GetNumberOfBytes(fs, 4);
                return BitConverter.ToUInt32(buff, 0);
            }

            { // else if type is ushort
                var buff = GetNumberOfBytes(fs, 2);
                return BitConverter.ToUInt16(buff, 0);
            }
        }
    }

    public class EntryCount : ResReader
    {
        public uint count = 0;

        override public void Read(FileStream fs)
        {
            count = GetUint(fs);
        }

        override public void Write(StringBuilder sb)
        { }
    }

    public class SimpleMulitString<T> : ResReader
    {
        T index;

        int arrayLength;
        string[] str;

        public SimpleMulitString(int length)
        {
            arrayLength = length;
            str = new string[arrayLength];
        }

        override public void Read(FileStream fs)
        {
            T type = default(T);
            index = (T)GetBytes(fs, type);
            for (int i = 0; i < arrayLength; i++)
            {
                str[i] = GetString(fs);
            }
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={index}");
            for (int i = 0; i < arrayLength; i++)
                sb.AppendLine(str[i]);

            // 換行
            sb.AppendLine("");
        }
    }

    public class SimpleSingleString<T> : SimpleMulitString<T>
    {
        public SimpleSingleString()
            :base(1)
        { }
    }

    // =========== TB structures below ========== //

    public class TbAchievementScript : SimpleMulitString<uint>
    {
        /*
        "tb_Achievement_Script": [
            "UInt32",
            "String",
            "String"
        ]
        */


        public TbAchievementScript()
            : base(2)
        { }
    }

    public class TbAkashicParts : SimpleMulitString<ushort>
    {
        /*
         "tb_Akashic_Parts": [
            "UInt16",
            "String",
            "String"
        ]
        */
        public TbAkashicParts()
            : base(2)
        { }
    }

    public class TbAppearance : ResReader
    {
        /*
        "tb_Appearance": [
            "UInt32",
            "Byte",
            "Byte",
            "UInt16",
            "UInt16",
            "String",
            "Byte"
        ]
        */
        uint i1;
        byte b1;
        byte b2;
        ushort s1;
        ushort s2;
        string str1;
        byte b3;

        override public void Read(FileStream fs)
        {
            i1 = GetUint(fs);
            b1 = GetByte(fs);
            b2 = GetByte(fs);
            s1 = GetUshort(fs);
            s2 = GetUshort(fs);
            str1 = GetString(fs);
            b3 = GetByte(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={i1}");
            sb.AppendLine($"NUM1={b1}");
            sb.AppendLine($"NUM2={b2}");
            sb.AppendLine($"NUM3={s1}");
            sb.AppendLine($"NUM4={s2}");
            sb.AppendLine($"NUM5={i1}");
            sb.AppendLine(str1);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbBooster : ResReader
    {
        /*
        "tb_Booster": [
            "UInt16",
            "UInt16",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Byte",
            "Single",
            "Single",
            "Single",
            "Single",
            "Single",
            "Single",
            "Single",
            "Single",
            "Single",
            "Single",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "UInt16",
            "Byte",
            "UInt32"
        ]
        */
        ushort[] s = new ushort[14];    // 1, 2, 33 - 43 (11)
        byte[] b = new byte[22];        // 3 - 22 (20), 44
        float[] f = new float[11];      // 23 - 32 (10)
        uint i1;                        // 45

        override public void Read(FileStream fs)
        {
            s[1] = GetUshort(fs);
            s[2] = GetUshort(fs);
            for(int j = 1; j <= 20; j++)
                b[j] = GetByte(fs);
            for (int j = 1; j <= 10; j++)
                f[j] = GetFloat(fs);
            for (int j = 3; j <= 13; j++)
                s[j] = GetUshort(fs);
            b[21] = GetByte(fs);
            i1 = GetUint(fs);
        }

        override public void Write(StringBuilder sb)
        {
            int k = 1;
            sb.AppendLine($"ID={s[1]}");
            sb.AppendLine($"NUM{k++}={s[2]}");
            for (int j = 1; j <= 20; j++)
                sb.AppendLine($"NUM{k++}={b[j]}");
            for (int j = 1; j <= 10; j++)
                sb.AppendLine($"NUM{k++}={f[j]}");
            for (int j = 3; j <= 13; j++)
                sb.AppendLine($"NUM{k++}={s[j]}");
            sb.AppendLine($"NUM{k++}={b[21]}");
            sb.AppendLine($"NUM{k++}={i1}");

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbBoosterScript : SimpleMulitString<ushort>
    {
        /*
        "tb_Booster_Script": [
            "UInt16",
            "String",
            "String",
            "String"
        ]
        */
        public TbBoosterScript()
            : base(3)
        { }
    }

    public class TbBuffScript : SimpleMulitString<ushort>
    {
        /*
        "tb_Buff_Script": [
		    "UInt16",
		    "String",
		    "String",
		    "String",
		    "String"
	    ]
        */
        // KR 的 TbBuffScript 有問題
        public TbBuffScript()
            : base(4)
        { }
    }

    public class TbCharacterInfo : ResReader
    {
        /*
        "tb_Character_Info": [
		    "UInt16",
		    "UInt16",
		    "Byte",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt16",
		    "UInt16",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "Int16",
		    "Int16",
		    "Int16",
		    "Int16",
		    "Int16",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt16",
		    "Single",
		    "Int16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "Single",
		    "Byte",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "Int16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt16",
		    "Single",
		    "UInt32",
		    "UInt32",
		    "UInt16",
		    "Byte"
	    ]
        */
        // KR 的 TbCharacterInfo 有問題
        ushort[] us = new ushort[27];    // 1, 2, 20, 21, 37, 40 - 45, 48 - 56, 58 - 60, 81, 85
        byte[] b = new byte[6];         // 3, 33, 47, 86
        string[] str = new string[9];   // 4 - 10
        uint[] ui = new uint[42];       // 11 - 19, 22 - 27, 34 - 36, 61 - 80, 83, 84
        short[] s = new short[9];       // 28 - 32, 39, 57
        float[] f = new float[5];       // 38, 46, 82

        override public void Read(FileStream fs)
        {
            us[1] = GetUshort(fs);
            us[2] = GetUshort(fs);
            b[1] = GetByte(fs);
            for (int j = 1; j <= 7; j++)    // 4 -10
                str[j] = GetString(fs);
            for (int j = 1; j <= 9; j++)    // 11 - 19
                ui[j] = GetUint(fs);
            us[3] = GetUshort(fs);
            us[4] = GetUshort(fs);
            for (int j = 10; j <= 15; j++)  // 22 - 27
                ui[j] = GetUint(fs);
            for (int j = 1; j <= 5; j++)    // 28 - 32
                s[j] = GetShort(fs);
            b[2] = GetByte(fs);
            for (int j = 16; j <= 18; j++)  // 34 - 36
                ui[j] = GetUint(fs);
            us[5] = GetUshort(fs);
            f[1] = GetFloat(fs);
            s[6] = GetShort(fs);
            for (int j = 6; j <= 11; j++)   // 40 - 45
                us[j] = GetUshort(fs);
            f[2] = GetFloat(fs);
            b[3] = GetByte(fs);
            for (int j = 12; j <= 20; j++)  // 48 - 56
                us[j] = GetUshort(fs);
            s[7] = GetShort(fs);
            for (int j = 21; j <= 23; j++)  // 58 - 60
                us[j] = GetUshort(fs);
            for (int j = 19; j <= 38; j++)  // 61 - 80
                ui[j] = GetUint(fs);
            us[24] = GetUshort(fs);
            f[3] = GetFloat(fs);
            ui[39] = GetUint(fs);
            ui[40] = GetUint(fs);
            us[25] = GetUshort(fs);
            b[4] = GetByte(fs);
        }

        override public void Write(StringBuilder sb)
        {

            sb.AppendLine($"ID={us[1]}");
            sb.AppendLine($"{us[2]}");
            sb.AppendLine($"{b[1]}");
            for (int j = 1; j <= 7; j++)    // 4 -10
                sb.AppendLine($"{str[j]}");
            for (int j = 1; j <= 9; j++)    // 11 - 19
                sb.AppendLine($"{ui[j]}");
            sb.AppendLine($"{us[3]}");
            sb.AppendLine($"{us[4]}");
            for (int j = 10; j <= 15; j++)  // 22 - 27
                sb.AppendLine($"{ui[j]}");
            for (int j = 1; j <= 5; j++)    // 28 - 32
                sb.AppendLine($"{s[j]}");
            sb.AppendLine($"{b[2]}");
            for (int j = 16; j <= 18; j++)  // 34 - 36
                sb.AppendLine($"{ui[j]}");
            sb.AppendLine($"{us[5]}");
            sb.AppendLine($"{f[1]}");
            sb.AppendLine($"{s[6]}");
            for (int j = 6; j <= 11; j++)   // 40 - 45
                sb.AppendLine($"{us[j]}");
            sb.AppendLine($"{f[2]}");
            sb.AppendLine($"{b[3]}");

            for (int j = 12; j <= 20; j++)  // 48 - 56
                sb.AppendLine($"{us[j]}");
            sb.AppendLine($"{s[7]}");
            for (int j = 21; j <= 23; j++)  // 58 - 60
                sb.AppendLine($"{us[j]}");
            for (int j = 19; j <= 38; j++)  // 61 - 80
                sb.AppendLine($"{ui[j]}");

            sb.AppendLine($"{us[24]}");
            sb.AppendLine($"{f[3]}");
            sb.AppendLine($"{ui[39]}");
            sb.AppendLine($"{ui[40]}");
            sb.AppendLine($"{us[25]}");
            sb.AppendLine($"{b[4]}");



            /*
            int k = 1;
            sb.AppendLine($"ID={us[1]}");
            sb.AppendLine($"NUM{k++}={us[2]}");
            sb.AppendLine($"NUM{k++}={b[1]}");
            for (int j = 1; j <= 7; j++)    // 4 -10
                sb.AppendLine($"{str[j]}");
            for (int j = 1; j <= 9; j++)    // 11 - 19
                sb.AppendLine($"NUM{k++}={ui[j]}");
            sb.AppendLine($"NUM{k++}={us[3]}");
            sb.AppendLine($"NUM{k++}={us[4]}");
            for (int j = 10; j <= 15; j++)  // 22 - 27
                sb.AppendLine($"NUM{k++}={ui[j]}");
            for (int j = 1; j <= 5; j++)    // 28 - 32
                sb.AppendLine($"NUM{k++}={s[j]}");
            sb.AppendLine($"NUM{k++}={b[2]}");
            for (int j = 16; j <= 18; j++)  // 34 - 36
                sb.AppendLine($"NUM{k++}={ui[j]}");
            sb.AppendLine($"NUM{k++}={us[5]}");
            sb.AppendLine($"NUM{k++}={f[1]}");
            sb.AppendLine($"NUM{k++}={s[6]}");
            for (int j = 6; j <= 11; j++)   // 40 - 45
                sb.AppendLine($"NUM{k++}={us[j]}");
            sb.AppendLine($"NUM{k++}={f[2]}");
            sb.AppendLine($"NUM{k++}={b[3]}");

            for (int j = 12; j <= 20; j++)  // 48 - 56
                sb.AppendLine($"NUM{k++}={us[j]}");
            sb.AppendLine($"NUM{k++}={s[7]}");
            for (int j = 21; j <= 23; j++)  // 58 - 60
                sb.AppendLine($"NUM{k++}={us[j]}");
            for (int j = 19; j <= 38; j++)  // 61 - 80
                sb.AppendLine($"NUM{k++}={ui[j]}");

            sb.AppendLine($"NUM{k++}={us[24]}");
            sb.AppendLine($"NUM{k++}={f[3]}");
            sb.AppendLine($"NUM{k++}={ui[39]}");
            sb.AppendLine($"NUM{k++}={ui[40]}");
            sb.AppendLine($"NUM{k++}={us[25]}");
            sb.AppendLine($"NUM{k++}={b[4]}");
            */
            // 換行
            sb.AppendLine("");
        }
    }

    public class TbCharacterParts : ResReader
    {
        /*
        "tb_Character_Parts": [
		    "UInt16",
		    "UInt16",
		    "Byte",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String"
	    ]
        */

        ushort s1;
        ushort s2;
        byte b1;
        string str1;
        string str2;
        string str3;
        string str4;
        string str5;

        override public void Read(FileStream fs)
        {
            s1 = GetUshort(fs);
            s2 = GetUshort(fs);
            b1 = GetByte(fs);
            str1 = GetString(fs);
            str2 = GetString(fs);
            str3 = GetString(fs);
            str4 = GetString(fs);
            str5 = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={s1}");
            sb.AppendLine($"NUM1={s2}");
            sb.AppendLine($"NUM2={b1}");
            sb.AppendLine(str1);
            sb.AppendLine(str2);
            sb.AppendLine(str3);
            sb.AppendLine(str4);
            sb.AppendLine(str5);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbChattingCommand : ResReader
    {
        /*
        "tb_ChattingCommand": [
		    "UInt32",
		    "SByte",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "UInt32"
	    ]
        */

        uint i1;
        sbyte sb1;    // old was byte
        string[] str = new string[5];
        uint i2;

        override public void Read(FileStream fs)
        {
            i1 = GetUint(fs);
            sb1 = GetSByte(fs);
            str[0] = GetString(fs);
            str[1] = GetString(fs);
            str[2] = GetString(fs);
            str[3] = GetString(fs);
            str[4] = GetString(fs);
            i2 = GetUint(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={i1}");
            sb.AppendLine($"NUM1={sb1}");
            sb.AppendLine(str[0]);
            sb.AppendLine(str[1]);
            sb.AppendLine(str[2]);
            sb.AppendLine(str[3]);
            sb.AppendLine(str[4]);
            sb.AppendLine($"NUM2={i2}");

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbChattingFilter : SimpleSingleString<uint>
    {
        /*
        "tb_ChattingFilter": [
		    "UInt32",
		    "String"
	    ]
        */
    }

    public class TbCinemaString : SimpleMulitString<ushort>
    {
        /*
	    "tb_Cinema_String": [
		    "UInt16",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String"
	    ]
        */
        // 這個陣列長度是 角色總人數 + Mob(1個) + NPC(1個) 的長度
        // 台日沒有朵娜   所以長度是 9 + 2 = 11
        // 韓有朵娜       所以長度是 10 + 2 = 13
        public TbCinemaString()
            : base(DecodeParam.NumberOfCharacter + 2)
        {

        }
    }

    public class TbClassForm : SimpleSingleString<uint>
    {
        /*
        "tb_Class_form": [
		    "UInt32",
		    "String"
	    ]
        */
    }

    public class TbClassSpeech : ResReader
    {
        // 消失，暫時不處理
        int arrayLength;
        uint[] i;

        public TbClassSpeech()
        {
            arrayLength = DecodeParam.NumberOfCharacter;
            i = new uint[2 + 6 * arrayLength];
            // i = new uint[56];
        }
        
        override public void Read(FileStream fs)
        {
            int k = 1;
            for (int j = 1; j <= 1 + arrayLength; j++)
                i[k++] = GetUint(fs);
            for (int j = 1; j <= 2 * arrayLength; j++)
                i[k++] = GetByte(fs);
            for (int j = 1; j <= arrayLength; j++)
                i[k++] = GetUint(fs);
            for (int j = 1; j <= arrayLength; j++)
                i[k++] = GetByte(fs);
            for (int j = 1; j <= arrayLength; j++)
                i[k++] = GetUint(fs);
        }

        override public void Write(StringBuilder sb)
        {
            // int k = 1;
            sb.AppendLine($"ID={i[1]}");
            //for (int j = 2; j <= 43; j++)
            //    sb.AppendLine($"NUM {k++}={i[j]}");
            // for (int j = 2; j <= 55; j++)
            for (int j = 2; j <= 1 + 6 * arrayLength; j++)
                sb.AppendLine($"{i[j]}");

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbCutsceneString : SimpleSingleString<uint>
    {
        /*
        "tb_Cutscene_String": [
		    "UInt32",
		    "String"
	    ]
        */
    }

    public class TbItemScript : ResReader
    {
        /*
        "tb_item_script": [
		    "UInt32",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "String",
		    "String"
	    ]
        */
        uint i1;
        string[] str = new string[10];
        byte[] b = new byte[7];

        override public void Read(FileStream fs)
        {
            i1 = GetUint(fs);
            for (int j = 1; j <= 6; j++)
                str[j] = GetString(fs);
            for (int j = 1; j <= 5; j++)
                b[j] = GetByte(fs);
            for (int j = 7; j <= 8; j++)
                str[j] = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={i1}");
            for (int j = 1; j <= 6; j++)
                sb.AppendLine(str[j]);
            // for (int j = 1; j <= 5; j++)
                // sb.AppendLine($"NUM{k++}={b[j]}");
            for (int j = 7; j <= 8; j++)
                sb.AppendLine(str[j]);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbLeagueSkillScript : SimpleMulitString<ushort>
    {
        /*
        "tb_LeagueSkill_Script": [
		    "UInt16",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String"
	    ]
        */
        public TbLeagueSkillScript()
            : base(5)
        { }
    }

    public class TbLoadingImg : ResReader
    {
        /*
        "tb_Loading_Img": [
		    "UInt16",
		    "UInt16",
		    "String",
		    "String"
	    ]
        */
        ushort s1;
        ushort s2;
        string str1;
        string str2;

        override public void Read(FileStream fs)
        {
            s1 = GetUshort(fs);
            s2 = GetUshort(fs);
            str1 = GetString(fs);
            str2 = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={s1}");
            sb.AppendLine($"NUM1={s2}");
            sb.AppendLine(str1);
            sb.AppendLine(str2);

            // 換行
            sb.AppendLine("");
        }
    }
    public class TbLoadingString : ResReader
    {
        /*
        "tb_Loading_String": [
		    "UInt16",
		    "UInt16",
		    "UInt16"
	    ]
        */
        ushort s1;
        ushort s2;
        ushort s3;

        override public void Read(FileStream fs)
        {
            s1 = GetUshort(fs);
            s2 = GetUshort(fs);
            s3 = GetUshort(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={s1}");
            sb.AppendLine($"NUM1={s2}");
            sb.AppendLine($"NUM1={s3}");

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbMazeRewardGoldDirect : ResReader
    {
        /*
        "tb_MazeReward_GoldDirect": [
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "String",
		    "String",
		    "String",
		    "String"
	    ]
        */
        uint i1;
        uint i2;
        uint i3;
        uint i4;
        string str1;
        string str2;
        string str3;
        string str4;

        override public void Read(FileStream fs)
        {
            i1 = GetUint(fs);
            i2 = GetUint(fs);
            i3 = GetUint(fs);
            i4 = GetUint(fs);
            str1 = GetString(fs);
            str2 = GetString(fs);
            str3 = GetString(fs);
            str4 = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={i1}");
            sb.AppendLine($"NUM1={i2}");
            sb.AppendLine($"NUM2={i3}");
            sb.AppendLine($"NUM3={i4}");
            sb.AppendLine(str1);
            sb.AppendLine(str2);
            sb.AppendLine(str3);
            sb.AppendLine(str4);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbMonsterScript : SimpleSingleString<uint>
    {
        /*
        "tb_Monster_script": [
		    "UInt32",
		    "String"
	    ] 
        */
    }

    public class TbNameFilter : ResReader
    {
        /*
        "tb_NameFilter": [
		    "UInt32",
		    "Byte",
		    "String"
	    ]
        */
        uint i1;
        byte b1;
        string str1;

        override public void Read(FileStream fs)
        {
            i1 = GetUint(fs);
            b1 = GetByte(fs);
            str1 = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={i1}");
            sb.AppendLine($"NUM1={b1}");
            sb.AppendLine(str1);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbNPCScript : SimpleSingleString<uint>
    {
        /*
        "tb_NPC_Script": [
		    "UInt32",
		    "String"
	    ]
        */
    }

    public class TbQuestScript : SimpleMulitString<uint>
    {
        /*
        "tb_Quest_Script": [
		    "UInt32",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String"
	    ]
        */
        public TbQuestScript()
            : base(5)
        { }
    }
    
    public class TbSpeech : ResReader
    {
        /*
        "tb_Speech": [
		    "UInt32",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "String",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "String",
		    "String"
	    ]
        */
        uint[] ui = new uint[9];        // 1, 5 - 7, 12 - 14
        byte[] b = new byte[8];         // 2 - 4, 9 - 11
        string[] str = new string[5];   // 8, 15, 16

        override public void Read(FileStream fs)
        {
            ui[1] = GetUint(fs);
            b[1] = GetByte(fs);
            b[2] = GetByte(fs);
            b[3] = GetByte(fs);
            ui[2] = GetUint(fs);
            ui[3] = GetUint(fs);
            ui[4] = GetUint(fs);
            str[1] = GetString(fs);
            b[4] = GetByte(fs);
            b[5] = GetByte(fs);
            b[6] = GetByte(fs);
            ui[5] = GetUint(fs);
            ui[6] = GetUint(fs);
            ui[7] = GetUint(fs);
            str[2] = GetString(fs);
            str[3] = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={ui[1]}");
            sb.AppendLine($"{b[1]}");
            sb.AppendLine($"{b[2]}");
            sb.AppendLine($"{b[3]}");
            sb.AppendLine($"{ui[2]}");
            sb.AppendLine($"{ui[3]}");
            sb.AppendLine($"{ui[4]}");
            sb.AppendLine(str[1]);
            sb.AppendLine($"{b[4]}");
            sb.AppendLine($"{b[5]}");
            sb.AppendLine($"{b[6]}");
            sb.AppendLine($"{ui[5]}");
            sb.AppendLine($"{ui[6]}");
            sb.AppendLine($"{ui[7]}");
            sb.AppendLine(str[2]);
            sb.AppendLine(str[3]);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbSpeechTag : ResReader
    {
        /*
        "tb_Speech_tag": [
		    "Byte",
		    "String",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32"
	    ]
        */

        // 會隨角色數量變動而異
        byte b1;
        string str1;
        byte b2;
        uint[] i;

        int arrayLength;

        public TbSpeechTag()
        {
            arrayLength = DecodeParam.NumberOfCharacter;
            i = new uint[arrayLength];
        }

        override public void Read(FileStream fs)
        {
            b1 = GetByte(fs);
            str1 = GetString(fs);
            b2 = GetByte(fs);
            for (int j = 0; j < arrayLength; j++)
                i[j] = GetUint(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={b1}");
            sb.AppendLine(str1);
            sb.AppendLine($"NUM1={b2}");
            
            for (int j = 0; j < arrayLength; j++)
                if (j == 0)
                    sb.AppendLine($"NUM{j+2}={i[j]}");
                else
                    sb.AppendLine($"NUM{j+3}={i[j]}");
            /*
            for (int j = 1; j <= arrayLength; j++)
                if (j - 1 == 0)
                    sb.AppendLine($"NUM{j+1}={i[j-1]}");
                else
                    sb.AppendLine($"NUM{j+2}={i[j-1]}");
            */

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbSpeechString : SimpleSingleString<uint>
    {
        /*
        "tb_Speech_String": [
		    "UInt32",
		    "String"
	    ]
        */
    }

    public class TbShopString : SimpleSingleString<uint>
    {
        /*
        "tb_Shop_String": [
		    "UInt32",
		    "String"
	    ]
        */
    }

    public class TbSoulMetry : ResReader
    {
        // Not check yet!!!
        /*
        "tb_soul_metry": [
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "String",
		    "String",
		    "String",
		    "String",
		    "String",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt16"
	    ]
        */
        ushort[] s = new ushort[19];
        uint[] i = new uint[7];
        byte[] b = new byte[4];
        string[] str = new string[5];

        override public void Read(FileStream fs)
        {
            for(int j = 0; j < 9; j++)
                s[j] = GetUshort(fs);
            for (int j = 0; j < 5; j++)
                i[j] = GetUint(fs);
            for (int j = 9; j < 14; j++)
                s[j] = GetUshort(fs);
            for (int j = 0; j < 5; j++)
                str[j] = GetString(fs);
            for (int j = 14; j < 19; j++)
                s[j] = GetUshort(fs);

            b[0] = GetByte(fs);
            b[1] = GetByte(fs);
            i[5] = GetUint(fs);
            i[6] = GetUint(fs);
            b[2] = GetByte(fs);
            b[3] = GetByte(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={s[0]}");
            for(int j = 0; j < 5; j++)
                sb.AppendLine(str[j]);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbSkill : ResReader
    {
        // Not fix yet!!!
        /*
        "tb_Skill": [
		    "UInt32",
		    "UInt16",
		    "UInt32",
		    "UInt32",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt16",
		    "Single",
		    "Single",
		    "Single",
		    "Single",
		    "Single",
		    "Byte",
		    "UInt16",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "Byte",
		    "UInt16",
		    "UInt16",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "Byte",
		    "UInt16",
		    "String",
		    "UInt16",
		    "UInt32",
		    "Byte",
		    "String",
		    "String",
		    "String",
		    "String",
		    "Byte",
		    "UInt32",
		    "UInt16",
		    "Byte",
		    "Byte",
		    "UInt16",
		    "String",
		    "String",
		    "String",
		    "Byte",
		    "String",
		    "String",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt32",
		    "UInt32"
	    ]
        */
        uint[] i = new uint[101];
        float[] f = new float[6];
        string[] str = new string[11];

        override public void Read(FileStream fs)
        {
            int k = 0, l = 0, m = 0;
            i[k++] = GetUint(fs);
            i[k++] = GetUshort(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUshort(fs);
            f[l++] = GetFloat(fs);
            f[l++] = GetFloat(fs);
            f[l++] = GetFloat(fs);
            f[l++] = GetFloat(fs);
            f[l++] = GetFloat(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUshort(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUshort(fs);
            i[k++] = GetUshort(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUshort(fs);
            i[k++] = GetByte(fs);
            str[m++] = GetString(fs);
            i[k++] = GetUshort(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetByte(fs);
            str[m++] = GetString(fs);
            str[m++] = GetString(fs);
            str[m++] = GetString(fs);
            str[m++] = GetString(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUint(fs);
            i[k++] = GetUshort(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetUshort(fs);
            str[m++] = GetString(fs);
            str[m++] = GetString(fs);
            str[m++] = GetString(fs);
            i[k++] = GetByte(fs);
            str[m++] = GetString(fs);
            str[m++] = GetString(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);

            // for new KR use, should be commented when in other versions
            // need to investigated about structures
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
            i[k++] = GetByte(fs);
        }

        override public void Write(StringBuilder sb)
        {
            int k = 0, l, m = 0;
            sb.AppendLine($"ID={i[k++]}");
            for (; k < 20; k++)
                sb.AppendLine($"{i[k]}");
            for (l = 0; l < 5; l++)
                sb.AppendLine($"{f[l]}");
            for (; k < 50; k++)
                sb.AppendLine($"{i[k]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{i[k]}");
            sb.AppendLine($"{i[k]}");
            sb.AppendLine($"{i[k]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{str[m++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");

            // for KR use
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");
            sb.AppendLine($"{i[k++]}");


            //for (; k<20;k++)
            //    sb.AppendLine($"NUM{n++}={i[k]}");
            //for (l = 0; l < 5; l++)
            //    sb.AppendLine($"NUM{n++}={f[l]}");
            //for (; k < 50; k++)
            //    sb.AppendLine($"NUM{n++}={i[k]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"NUM{n++}={i[k]}");
            //sb.AppendLine($"NUM{n++}={i[k]}");
            //sb.AppendLine($"NUM{n++}={i[k]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"{str[m++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");
            //sb.AppendLine($"NUM{n++}={i[k++]}");

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbSkillScript : ResReader
    {
        /*
        "tb_Skill_Script": [
		    "UInt16",
		    "String",
		    "String",
		    "String",
		    "String",
		    "UInt32",
		    "UInt32",
		    "String",
		    "String"
	    ]
        */
        ushort s1;
        uint i1;
        string str1;
        string str2;
        string str3;
        string str4;
        uint i2;
        uint i3;
        string str5;
        string str6;

        override public void Read(FileStream fs)
        {
            if (DecodeParam.SelectedRegion == "_KOR")
                i1 = GetUint(fs);
            else
                s1 = GetUshort(fs);
            str1 = GetString(fs);
            str2 = GetString(fs);
            str3 = GetString(fs);
            str4 = GetString(fs);
            i2 = GetUint(fs);
            i3 = GetUint(fs);
            str5 = GetString(fs);
            str6 = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            if (DecodeParam.SelectedRegion == "_KOR")
                sb.AppendLine($"ID={i1}");
            else
                sb.AppendLine($"ID={s1}");
            sb.AppendLine(str1);
            sb.AppendLine(str2);
            sb.AppendLine(str3);
            sb.AppendLine(str4);
            // sb.AppendLine($"{i2}");
            // sb.AppendLine($"{i3}");
            sb.AppendLine(str5);
            sb.AppendLine(str6);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbSoulMetryString : SimpleSingleString<ushort>
    {
        /*
        "tb_soul_metry_string": [
		    "UInt16",
		    "String"
	    ]
        */
    }

    public class TbSystemMail : ResReader
    {
        /*
        "tb_SystemMail": [
		    "Byte",
		    "UInt16",
		    "UInt16",
		    "String",
		    "String",
		    "String",
		    "String"
	    ]
        */
        byte b1;
        ushort s1;
        ushort s2;
        string str1;
        string str2;
        string str3;
        string str4;

        override public void Read(FileStream fs)
        {
            b1 = GetByte(fs);
            s1 = GetUshort(fs);
            s2 = GetUshort(fs);
            str1 = GetString(fs);
            str2 = GetString(fs);
            str3 = GetString(fs);
            str4 = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={b1}");
            sb.AppendLine(str1);
            sb.AppendLine(str2);
            sb.AppendLine(str3);
            sb.AppendLine(str4);

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbTalk : ResReader
    {
        /*
        "tb_Talk": [
		    "UInt32",
		    "Byte",
		    "UInt16",
		    "UInt32",
		    "Byte",
		    "UInt32",
		    "Byte",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32",
		    "UInt32"
	    ]
        */
        uint[] i = new uint[37];    //1, 4, 6, 8 - 39
        byte[] b = new byte[5];     //2, 5, 7
        ushort s1;

        override public void Read(FileStream fs)
        {
            i[1] = GetUint(fs);
            b[1] = GetByte(fs);
            s1 = GetUshort(fs);
            i[2] = GetUint(fs);
            b[2] = GetByte(fs);
            i[3] = GetUint(fs);
            b[3] = GetByte(fs);
            for(int j = 4; j <= 35; j++)
                i[j] = GetUint(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={i[1]}");
            sb.AppendLine($"{b[1]}");
            sb.AppendLine($"{s1}");
            sb.AppendLine($"{i[2]}");
            sb.AppendLine($"{b[2]}");
            sb.AppendLine($"{i[3]}");
            sb.AppendLine($"{b[3]}");
            for (int j = 4; j <= 35; j++)
                sb.AppendLine($"{i[j]}");

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbTalkList : ResReader
    {
        /*
        "tb_Talk_List": [
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16"
	    ]
        */
        ushort[] s = new ushort[26];

        override public void Read(FileStream fs)
        {
            for(int j = 0; j < 26; j++)
                s[j] = GetUshort(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={s[0]}");
            for (int j = 1; j < 26; j++)
                sb.AppendLine($"NUM{j}={s[j]}");

            // 換行
            sb.AppendLine("");
        }
    }

    public class TbTalkString : SimpleSingleString<ushort>
    {
        /*
        "tb_Talk_String": [
		    "UInt16",
		    "String"
	    ]
        */
    }

    public class TbTitleInfo : ResReader
    {
        /*
        "tb_Title_Info": [
		    "UInt32",
		    "UInt32",
		    "Byte",
		    "Byte",
		    "UInt16",
		    "Byte",
		    "UInt32",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "Byte",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "UInt16",
		    "Single",
		    "Single",
		    "Single",
		    "Single",
		    "Single"
	    ]
        */
        uint[] ui = new uint[5];        // 1, 2, 7
        byte[] b = new byte[11];          // 3, 4, 6, 8 - 13
        ushort[] us = new ushort[8];    // 5, 14 - 18
        float[] f = new float[7];       // 19 - 23

        // uint[] i = new uint[18];
        // float[] f = new float[5];

        override public void Read(FileStream fs)
        {
            ui[1] = GetUint(fs);
            ui[2] = GetUint(fs);
            b[1] = GetByte(fs);
            b[2] = GetByte(fs);
            us[1] = GetUshort(fs);
            b[3] = GetByte(fs);
            ui[3] = GetUint(fs);
            for (int j = 4; j <= 9; j++)
                b[j] = GetByte(fs);
            for (int j = 2; j <= 6; j++)
                us[j] = GetUshort(fs);
            for (int j = 1; j <= 5; j++)
                f[j] = GetFloat(fs);
            /*
            int j = 0, k = 0;
            ui[j++] = GetUint(fs);
            ui[j++] = GetUint(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetUshort(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetUint(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetByte(fs);
            ui[j++] = GetUshort(fs);
            ui[j++] = GetUshort(fs);
            ui[j++] = GetUshort(fs);
            ui[j++] = GetUshort(fs);
            ui[j++] = GetUshort(fs);
            f[k++] = GetFloat(fs);
            f[k++] = GetFloat(fs);
            f[k++] = GetFloat(fs);
            f[k++] = GetFloat(fs);
            f[k++] = GetFloat(fs);
            */
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={ui[1]}");
            sb.AppendLine($"{ui[2]}");
            sb.AppendLine($"{b[1]}");
            sb.AppendLine($"{b[2]}");
            sb.AppendLine($"{us[1]}");
            sb.AppendLine($"{b[3]}");
            sb.AppendLine($"{ui[3]}");
            for (int j = 4; j <= 9; j++)
                sb.AppendLine($"{b[j]}");
            for (int j = 2; j <= 6; j++)
                sb.AppendLine($"{us[j]}");
            for (int j = 1; j <= 5; j++)
                sb.AppendLine($"{f[j]}");

            /*
            sb.AppendLine($"ID={ui[0]}");
            int j;
            for (j = 1; j < 18; j++)
                sb.AppendLine($"{ui[j]}");
            for (int k = 0; k < 5; k++, j++)
                sb.AppendLine($"{f[k]}");
            //for (j = 1; j < 18; j++)
            //    sb.AppendLine($"NUM{j}={i[j]}");
            //for (int k = 0; k < 5; k++, j++)
            //    sb.AppendLine($"NUM{j}={f[k]}");
            */
            // 換行
            sb.AppendLine("");
        }
    }

    public class TbTitleString : SimpleMulitString<uint>
    {
        /*
        "tb_Title_String": [
		    "UInt32",
		    "String",
		    "String",
		    "String"
	    ]
        */
        public TbTitleString()
            : base(3)
        { }
    }

    public class TbTooltipString : SimpleMulitString<uint>
    {
        /*
        "tb_Tooltip_String": [
		    "UInt32",
		    "String",
		    "String"
	    ]
        */
        public TbTooltipString()
            : base(2)
        { }
    }

    public class TbUIString : ResReader
    {
        /*
        "tb_UI_String": [
		    "UInt32",
		    "Byte",
		    "String"
	    ]
        */
        uint ui1;
        byte b1;
        string str1;

        override public void Read(FileStream fs)
        {
            ui1 = GetUint(fs);
            b1 = GetByte(fs);
            str1 = GetString(fs);
        }

        override public void Write(StringBuilder sb)
        {
            sb.AppendLine($"ID={ui1}");
            sb.AppendLine(str1);

            // 換行
            sb.AppendLine("");
        }
    }
}
