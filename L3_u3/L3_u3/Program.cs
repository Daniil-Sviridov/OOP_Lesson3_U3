using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_u3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FileInfo fi = new FileInfo("mail.txt");

            fi.CreateText();

        }
    }
}
