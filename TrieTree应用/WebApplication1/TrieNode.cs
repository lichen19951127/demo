using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class TrieNode
    {
        public TrieNode(char ch, int depth)
        {
            this.Character = ch;
            this._depth = depth;
        }


        public char Character;

        int _depth;
        public int Depth
        {
            get { return _depth; }
        }

        TrieNode _parent = null;
        public TrieNode Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public bool WordEnded = false;


        HashSet<TrieNode> _children = null;
        public HashSet<TrieNode> Children
        {
            get { return _children; }
        }

        public TrieNode GetChildNode(char ch)
        {
            if (_children != null)
                return _children.FirstOrDefault(n => n.Character == ch);
            else
                return null;
        }

        public TrieNode AddChild(char ch)
        {
            TrieNode matchedNode = null;
            if (_children != null)
            {
                matchedNode = _children.FirstOrDefault(n => n.Character == ch);
            }
            if (matchedNode != null)    //found the char in the list
            {
                //matchedNode.IncreaseFrequency();
                return matchedNode;
            }
            else
            {   //not found
                TrieNode node = new TrieNode(ch, this.Depth + 1);
                node.Parent = this;
                //node.IncreaseFrequency();
                if (_children == null)
                    _children = new HashSet<TrieNode>();
                _children.Add(node);
                return node;
            }
        }

        int _frequency = 0;
        public int Frequency
        {
            get { return _frequency; }
        }

        public void IncreaseFrequency()
        {
            _frequency++;
        }

        public string GetWord()
        {
            TrieNode tmp = this;
            string result = string.Empty;
            while (tmp.Parent != null) //until root node
            {
                result = tmp.Character + result;
                tmp = tmp.Parent;
            }
            return result;
        }

        public override string ToString()
        {
            return Convert.ToString(this.Character);
        }
    }
}
