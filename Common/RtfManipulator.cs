using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Common
{
    public class RtfManipulator
    {
        public static string RtfRW(int id, RichTextBox r, bool read)
        {         
            string pathToRtb = "./rtb" + id + ".rtf"; 
            TextRange range = new TextRange(r.Document.ContentStart, r.Document.ContentEnd);
            FileStream fStream;

            if (read)
            {
                fStream = new FileStream(pathToRtb, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Rtf);
                fStream.Close();
            }
            else
            {
                fStream = new FileStream(pathToRtb, FileMode.Create);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();
            }

            return pathToRtb;
        }
    }
}
