using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet;
using YamlDotNet.RepresentationModel;
using YamlDotNet.RepresentationModel.Serialization;

namespace CsAdventCalendarDec9
{
    class Program
    {
        static void Main(string[] args) {
            //シリアライズするオブジェクトを定義する
            var calendar = new AdventCalendar();
            calendar.Year = new DateTime(2012, 12, 1);
            calendar.Description = "C# Advent Calender 2012";
            calendar.Contents.Add(new Content()  {
                Day = 1,
                Author = "gushwell",
                Description = ".NET Framework4.5 での非同期I/O処理 事始め",
                URL = @"http://gushwell.ldblog.jp/archives/52290230.html"
            });
            calendar.Contents.Add(new Content() {
                Day = 2,
                Author = "KTZ",
                Description = "年末の大掃除",
                URL = @"http://ritalin.github.com/2012/12-02/csharp-advent-2012/"
            });
            calendar.Contents.Add(new Content() {
                Day = 3,
                Author = "neuecc",
                Description = "MemcachedTranscoder – C#のMemcached用シリアライザライブラリ",
                URL = @"http://neue.cc/2012/12/03_389.html"
            });

            //YAMLにシリアライズしてコンソールに表示
            var serializer = new Serializer();
            serializer.Serialize(Console.Out, calendar);

            Console.Read();
        }

    }

    public class Content
    {
        public int Day { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string URL { get; set;}   

    }


    public class AdventCalendar
    {
        public DateTime Year { get; set; }
        public string Description { get; set; }
        public List<Content> Contents { get; set; }

        public AdventCalendar() {
            this.Contents = new List<Content>();
        }

        public AdventCalendar(List<Content> contents) {
            this.Contents = contents;
        }
    }
}
