using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_u3
{
    public class Program
    {
        static void Main(string[] args)
        {

            FileInfo fi = new FileInfo("in_file.txt");

            // fi.CreateText();

            foreach (var line in EnumLines(fi))
            {
                if (line is null || line.Length == 0) continue;

                string email = line;
                SearchMail(ref email);
                Console.WriteLine(email);

                var elements = line.Split(',');
                //if (elements.Length != 5) continue;


            }
            Console.ReadLine();
            }

        public static void SearchMail(ref string s)
        {

            s = s + "1";
        }

        private static IEnumerable<string> EnumLines(FileInfo file)
        {
            //if (!file.Exists)
            //    throw new FileNotFoundException("Файл данных не найден", file.FullName);
            if (!file.Exists || file.Length == 0)
                yield break;

            using var reader = file.OpenText();
                while (!reader.EndOfStream)
                    yield return reader.ReadLine()!;
           
        }
    }
}
