using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Common
{
    /// <summary>
    /// 节点数据
    /// </summary>
    public class TreeWrap<T> where T : class
    {
        public TreeWrap()
        { }

        public TreeWrap(T curNode)
        {
            this.CurNode = curNode;
        }

        public T CurNode { get; set; }

        /// <summary>
        /// 是否存在子节点
        /// </summary>
        public bool IsSub
        {
            get
            {
                if (this.SubNode.Count < 1) { return false; }
                return true;
            }
        }

        /// <summary>
        /// 子节点
        /// </summary>
        private IList<TreeWrap<T>> _subNode;
        public IList<TreeWrap<T>> SubNode
        {
            get
            {
                if (_subNode == null)
                {
                    _subNode = new List<TreeWrap<T>>();
                }
                return _subNode;
            }
            set { _subNode = value; }
        }
        public void AddSubNode(TreeWrap<T> node)
        {
            this.SubNode.Add(node);
        }
    }
}
