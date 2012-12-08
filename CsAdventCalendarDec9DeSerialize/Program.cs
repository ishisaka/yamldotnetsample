using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using YamlDotNet;
using YamlDotNet.RepresentationModel;
using YamlDotNet.RepresentationModel.Serialization;


namespace CsAdventCalendarDec9DeSerialize
{
    class Program
    {
        static void Main(string[] args) {
            // YAMLのファイルをUTF-8エンコーディングされたファイルとして読み込む
            var input = new StreamReader("AdventCalendar.yaml", Encoding.UTF8);
            // YAMLのストリームを解析する
            var yaml = new YamlStream();
            yaml.Load(input);
            // ストリームを解析する
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            //Yearノードの値を取得する
            var Year = (YamlScalarNode)mapping.Children[new YamlScalarNode("Year")];
            Console.WriteLine("Year\t{0}", Year.Value);
            //Descriptionノードの値を表示する
            var Description = (YamlScalarNode)mapping.Children[new YamlScalarNode("Description")];
            Console.WriteLine("Desciption\t{0}", Description.Value);
            //Contents以下の内容表示
            Console.WriteLine("Contents:");
            //シーケンス(配列)のノードとしてContentsノードの内容を取り出す
            var items = (YamlSequenceNode)mapping.Children[new YamlScalarNode("Contents")];
            //Contentsの各Contentをマッピングノードとして取り出す
            foreach (YamlMappingNode item in items) {
                //Contentの個別要素を表示させる
                foreach (var child in item) {
                    Console.WriteLine(
                        "{0}\t{1}", 
                        ((YamlScalarNode)child.Key).Value, 
                        ((YamlScalarNode)child.Value).Value);
                }
            }

            // クラスに直接デシリアライズする。
            //YAMLファイルを開き直す
            input.Close();
            input = new StreamReader("AdventCalendar.yaml", Encoding.UTF8);
            //YAMLファイルからContentsオブジェクトに復元するためのYamlSerializer(T)クラスのインスタンスを作る
            //Genericで復元先のクラスを指定する
            var yamlSerializer = new YamlSerializer<AdventCalendar>();
            //C#nのオブジェクトに復元を行う
            var calendar = yamlSerializer.Deserialize(input);
            //復元した結果を表示する。
            Console.WriteLine("Year:{0}", calendar.Year);
            Console.WriteLine("Description:{0}", calendar.Description);
            foreach (var content in calendar.Contents) {
                Console.WriteLine("\tDay:{0}", content.Day);
                Console.WriteLine("\tAuthor:{0}", content.Author);
                Console.WriteLine("\tDescription:{0}", content.Description);
                Console.WriteLine("\tURL:{0}", content.URL);
            }

            input.Close();
            Console.Read();
        }
    }

    public class Content
    {
        public int Day { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

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
