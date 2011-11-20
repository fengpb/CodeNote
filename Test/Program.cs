using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using antlr;
using Antlr.StringTemplate;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "$account$您好！<br/> 请点击连接重置您的秘密<br><a href=\"$url$\">$url$</a>";
            StringTemplate st = new StringTemplate(text);
            st.SetAttribute("account", "fengpengbin");
            st.SetAttribute("url", "http://www.aporeboy.com/vail"); 
            Console.WriteLine(st.ToString());
            Console.ReadKey();
        }
    }
}
