using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Common
{
    /// <summary>
    /// 用于随机生成数字字符等
    /// </summary>
    public class IDentity
    {
        private string range = "ABCDEFJHIJKLMNOPQRSTUVWXYZ1234567890";

        protected Random random = new Random();

        protected StringBuilder output = new StringBuilder();
        public static IDentity CreateNew()
        {
            return new IDentity();
        }
        public IDentity AddDate(string dateExpress)
        {
            this.output.Append(DateTime.Now.ToString(dateExpress));
            return this;
        }
        public IDentity AddStr(string str)
        {
            this.output.Append(str);
            return this;
        }
        public IDentity AddStr(int length = 10)
        {
            for (int i = 0; i < length; i++)
            {
                int index = this.random.Next(range.Length);
                this.output.Append(this.range.Substring(index, 1));
            }
            return this;
        }

        public string StrID()
        {
            return this.output.ToString();
        }
    }
}
