using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Web.Common
{
    public class DictionaryWrap
    {
        public DictionaryWrap() { }
        private IDictionary<string, object> _dic;
        protected IDictionary<string, object> Dic
        {
            get
            {
                if (_dic == null)
                {
                    _dic = new Dictionary<string, object>();
                }
                return _dic;
            }
        }
        public static DictionaryWrap CreateNew()
        {
            return new DictionaryWrap();
        }
        public DictionaryWrap Add(string key, object value)
        {
            this.Dic.Add(key, value);
            return this;
        }
        public IDictionary<string, Object> Init()
        {
            return this.Dic;
        }
    }
}

