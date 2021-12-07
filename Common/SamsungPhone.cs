using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Common
{
    [Serializable]
    public class SamsungPhone
    {
        public string PhoneName { get; set; }
        public string PathToDescription { get; set; } //negde/nesto.rtf

        public DateTime ReleaseDate { get; set; }

        public double AndroidVersion { get; set; }

        public string PathToImage { get; set; } // ./negde/negde/nesto.jpg

        public int ID { get; set; }

        public SamsungPhone() {}

        public SamsungPhone(string name,string desc, DateTime date, double version, string path,int id)
        {
            PhoneName = name;
            PathToDescription = desc;
            ReleaseDate = date;
            AndroidVersion = version;
            PathToImage = path;
            ID = id;
        }
    }
}
