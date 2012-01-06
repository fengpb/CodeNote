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
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszd"));
            

            Console.ReadKey();
        }
        static void TestStringTemplate()
        {
            string text = "$entity.Account$您好！<br/> 请点击连接重置您的秘密<br><a href=\"$url$\">$url$</a>";
            StringTemplate st = new StringTemplate(text);
            st.SetAttribute("entity", new Demo() { Account = "fengpengbin" });
            st.SetAttribute("url", "http://www.aporeboy.com/vail");
            Console.WriteLine(st.ToString());
            
        }
    }
    public class Demo
    {
        public string Account { get; set; }
    }
}
