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
            FileInfo fo = new FileInfo("out_mail.txt");

            var write = fo.CreateText();

            foreach (var line in EnumLines(fi))
            {
                if (line is null || line.Length == 0) continue;



                var elements = line.Split('&');
                if (elements.Length != 2) continue;

                string email = elements[1];
                SearchMail(ref email);

                if (email.Length > 0)
                {
                    Console.WriteLine($"Добавили : {email}");
                    write.WriteLine(email);
                }
            }

            write.Close();

        }

        public static void SearchMail(ref string s)
        {
            string pattern = "([a-z0-9_-]+)@([a-z0-9_-]+).([a-z.]{2,6})";
            var rez = System.Text.RegularExpressions.Regex.Match(s.ToLower(), pattern);

            s = "";
            if (rez.Success)
            {
                s = rez.Value;
            }
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
