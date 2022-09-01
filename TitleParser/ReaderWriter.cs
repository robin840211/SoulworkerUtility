using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitleParser
{
    public class DecodeParam
    {
        // public static int NumberOfCharacter = 0;
        public static string SelectedRegion = "";
    }

    public interface IMyReader
    {
        void Read(StreamReader sr);
    }

    public abstract class MyReader : IMyReader
    {
        public string id;

        public abstract void Read(StreamReader sr);
    }

    public class TbTitle : MyReader
    {
        public string[] str = new string[3];

        public override void Read(StreamReader sr)
        {
            for (int j = 0; j < 3; j++)
                str[j] = sr.ReadLine();
        }
    }

    public class TbTitleInfo : MyReader
    {
        public string[] str = new string[22];

        public override void Read(StreamReader sr)
        {
            for (int j = 0; j < 22; j++)
                str[j] = sr.ReadLine();
        }
    }

    public interface WriteFormat
    {
        void WriteHead(StreamWriter sw, string title);
        void WriteTail(StreamWriter sw);
        void WriteBegin(StreamWriter sw);
        void WriteEnd(StreamWriter sw);
        void WriteNumber(StreamWriter sw, string number);
        void WriteCharacter(StreamWriter sw, string name);
        void WriteTitle(StreamWriter sw, string title);
        void WriteDescription(StreamWriter sw, string text);
        void WriteObtain(StreamWriter sw, string method);
        void WriteNoEffect(StreamWriter sw);
        void WriteEffect(StreamWriter sw, string[] effects);
        void Write(StreamWriter sw, string str);
    }

    public class WriteText : WriteFormat
    {
        public void WriteHead(StreamWriter sw, string title) { }
        public void WriteTail(StreamWriter sw) { }
        public void WriteBegin(StreamWriter sw) { }
        public void WriteEnd(StreamWriter sw)
        {
            sw.WriteLine($"");
        }

        public void WriteNumber(StreamWriter sw, string number)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"編號：{number}");
            }
            else
            {
                //sw.WriteLine($"No.{number}");
                sw.WriteLine($"No. {number}");
            }
        }

        public void WriteCharacter(StreamWriter sw, string name)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"角色：{name}");
            }
            else
            {
                sw.WriteLine($"Character: {name}");
            }
        }

        public void WriteTitle(StreamWriter sw, string title)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"名稱：{title}");
            }
            else
            {
                sw.WriteLine($"Title Name: {title}");
            }
        }
        
        public void WriteDescription(StreamWriter sw, string text)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"描述：{text}");
            }
            else
            {
                sw.WriteLine($"Description: {text}");
            }
        }

        public void WriteObtain(StreamWriter sw, string method)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"獲得方法：{method}");
            }
            else
            {
                sw.WriteLine($"Acquired from: {method}");
            }
        }

        public void WriteNoEffect(StreamWriter sw)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"效果：無");
            }
            else
            {
                sw.WriteLine($"Effect: None");
            }
        }

        public void WriteEffect(StreamWriter sw, string [] effects)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"效果：");
            }
            else
            {
                sw.WriteLine($"Effect: ");
            }
            foreach (var eff in effects)
                sw.WriteLine(eff);
        }

        public void Write(StreamWriter sw, string str)
        {
            sw.WriteLine(str);
        }
    }
    
    public class WriteCSV : WriteFormat
    {
        public void WriteHead(StreamWriter sw, string title) { }
        public void WriteTail(StreamWriter sw) { }
        public void WriteBegin(StreamWriter sw) { }
        public void WriteEnd(StreamWriter sw)
        {
            sw.WriteLine($"");
        }

        public void WriteNumber(StreamWriter sw, string number)
        {
            sw.Write($"{CheckString(number)},");
        }

        public void WriteCharacter(StreamWriter sw, string name)
        {
            sw.Write($"{CheckString(name)},");
        }

        public void WriteTitle(StreamWriter sw, string title)
        {
            sw.Write($"{CheckString(title)},");
        }

        public void WriteDescription(StreamWriter sw, string text)
        {
            sw.Write($"{CheckString(text)},");
        }

        public void WriteObtain(StreamWriter sw, string method)
        {
            sw.Write($"{CheckString(method)},");
        }

        public void WriteNoEffect(StreamWriter sw)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.Write($"無");
            }
            else
            {
                sw.Write($"None");
            }
        }

        public void WriteEffect(StreamWriter sw, string[] effects)
        {
            sw.Write(CheckString(String.Join("\\n", effects)));
        }

        public string CheckString(string str)
        {
            str = str.Replace("\\n", "\n");
            if (str.Contains(",") || str.Contains("\n"))
            {
                return string.Format("\"{0}\"", str);
            }
            else
                return str;
        }

        public void Write(StreamWriter sw, string str)
        {
            sw.WriteLine(str);
        }
    }

    public class WriteHTML : WriteFormat
    {
        public void WriteHead(StreamWriter sw, string title)
        {
            sw.WriteLine($"<!DOCTYPE html>");
            sw.WriteLine($"<html>");
            sw.WriteLine($"<head>");
            sw.WriteLine($"<title>{title}</title>");
            sw.WriteLine($"</head>");
            sw.WriteLine($"<body>");
            sw.WriteLine($"<table cellpadding=\"3\" border = '1'>");
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.WriteLine($"<tr><td>ID</td><td>角色</td><td>稱號</td><td>描述</td><td>獲得方法</td><td>屬性能力</td></tr>");
            }
            else
            {
                sw.WriteLine($"<tr><td>ID</td><td>Character</td><td>Title</td><td>Description</td><td>Acquired from</td><td>Effect</td></tr>");
            }
        }

        public void WriteTail(StreamWriter sw)
        {
            sw.WriteLine($"</table>");
            sw.WriteLine($"</body>");
            sw.WriteLine($"</html>");
        }

        public void WriteBegin(StreamWriter sw)
        {
            sw.WriteLine($"<tr>");
        }

        public void WriteEnd(StreamWriter sw)
        {
            sw.WriteLine($"</tr>");
        }

        public void WriteNumber(StreamWriter sw, string number)
        {
            sw.Write($"<td>{number}</td>");
        }

        public void WriteCharacter(StreamWriter sw, string name)
        {
            sw.Write($"<td>{name}</td>");
        }

        public void WriteTitle(StreamWriter sw, string title)
        {
            sw.Write($"<td>{title}</td>");
        }

        public void WriteDescription(StreamWriter sw, string text)
        {
            text = text.Replace(@"\n\n", "<br>");
            text = text.Replace(@"\n", "<br>");
            sw.Write($"<td>{text}</td>");
        }

        public void WriteObtain(StreamWriter sw, string method)
        {
            sw.Write($"<td>{method}</td>");
        }

        public void WriteNoEffect(StreamWriter sw)
        {
            if (DecodeParam.SelectedRegion == "_TWN")
            {
                sw.Write($"<td>無</td>");
            }
            else
            {
                sw.Write($"<td>None</td>");
            }
        }

        public void WriteEffect(StreamWriter sw, string[] effects)
        {
            sw.Write($"<td>");
            foreach (var eff in effects)
                sw.Write($"{eff}<br>");
            sw.Write($"</td>");
        }

        public void Write(StreamWriter sw, string str)
        {
            sw.WriteLine(str);
        }
    }

    public struct WritePackage
    {
        public WriteFormat method;
        public string ext;
    }

    public class WritePackageFactory
    {
        public enum Type
        {
            TEXT,
            CSV,
            HTML,
        }

        public static WritePackage GetInstance(Type type)
        {
            switch (type)
            {
                default:
                case Type.TEXT: return new WritePackage { method = new WriteText(), ext = "txt" };
                case Type.CSV: return new WritePackage { method = new WriteCSV(), ext = "csv" };
                case Type.HTML: return new WritePackage { method = new WriteHTML(), ext = "html" };
            }
        }
    }
}
